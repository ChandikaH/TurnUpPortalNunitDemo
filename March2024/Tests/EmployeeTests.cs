using log4net;
using log4net.Config;
using March2024.Pages;
using March2024.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace March2024.Tests
{
    [Parallelizable]
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(EmployeeTests));
        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        //Home page object initialization and definition
        HomePage homePageObj = new HomePage();
        //Employee page object initialization and definition
        EmployeePage employeePageObj = new EmployeePage();

        [SetUp]
        public void SetUp()
        {
            //Open Chrome Browser
            try
            {
                XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error configuring log4net: " + ex.Message);
            }

            webDriver = new ChromeDriver();


            loginPageObj.LoginActions(webDriver, "hari", "123123");
            log.Info("User logged in successfully - EmployeeTests");
            homePageObj.VerifyLoggedInUser(webDriver);
            log.Info("User logged in successfully - EmployeeTests");
            homePageObj.NavigateToEmployeePage(webDriver);
        }

        [Test, Order(1), Description("This test create a Employee record with valid details")]
        public void TestCreateEmployeeRecord()
        {
            employeePageObj.CreateEmployeeRecord(webDriver);
        }

        [Test, Order(2), Description("This test update the Employee record with valid details")]
        public void TestUpdateEmployeeRecord()
        {
            employeePageObj.EditEmployeeRecord(webDriver);
        }

        [Test, Order(3), Description("This test delete the last Employee record")]
        public void TestDeleteEmployeeRecord()
        {
            employeePageObj.DeleteEmployeeRecord(webDriver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            webDriver.Quit();
        }
    }
}
