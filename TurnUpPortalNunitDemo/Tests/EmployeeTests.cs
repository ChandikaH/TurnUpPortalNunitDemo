using TurnUpPortalNunitDemo.Pages;
using TurnUpPortalNunitDemo.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace TurnUpPortalNunitDemo.Tests
{
    [Parallelizable]
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
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
            webDriver = new ChromeDriver();


            loginPageObj.LoginActions(webDriver, "hari", "123123");
            Console.WriteLine("User logged in successfully - EmployeeTests");
            homePageObj.VerifyLoggedInUser(webDriver);
            Console.WriteLine("User logged in successfully - EmployeeTests");
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
