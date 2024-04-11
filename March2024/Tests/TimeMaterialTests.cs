using March2024.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using March2024.Utilities;

namespace March2024.Tests
{
    [Parallelizable]
    [TestFixture]
    public class TimeMaterialTests : CommonDriver
    {
        TimeMaterialPage tmPageObj = new TimeMaterialPage();

        [SetUp]
        public void SetUpTimeMaterial()
        {
            //Open Chrome Browser
            webDriver = new ChromeDriver();

            //Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(webDriver, "hari", "123123");

            //Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.VerifyLoggedInUser(webDriver);
            homePageObj.NavigateToTimeMaterialPage(webDriver);
        }

        /*
         *This test is for testing the Time record creation
         *these are the test data used for the test
         *Type = IC2024March
         */
        [Test, Order(1), Description("This test create a new Time/Material record with valid details")]
        public void TestCreateTimeMaterialRecord()
        {
            tmPageObj.CreateTimeRecord(webDriver);
        }

        [Test, Order(2), Description("This test update the Time/Material record with valid details")]
        public void TestUpdateTimeMaterialRecord()
        {
            tmPageObj.EditNewlyCreatedTMRecord(webDriver);
        }

        [Test, Order(3), Description("This test delete the last Time/Material record")]
        public void TestDeleteTimeMaterialRecord()
        {
            tmPageObj.DeleteTMRecord(webDriver);
        }

        [TearDown]
        public void CloseTestRun()
        { 
            webDriver.Quit();
        }

    }
}
