using March2024.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace March2024.Pages
{
    public class TimeMaterialPage
    {
        public void CreateTimeRecord(IWebDriver webDriver)
        {
            //Create a new Time/Material record

            //Click on the Create New Button
            IWebElement createNewButton = webDriver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            WaitUtils.WaitToBeVisible(webDriver, "Xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]", 5);

            //Select Time from dropdown
            IWebElement typeCodeMainDropdown = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeMainDropdown.Click();
            IWebElement timeTypeCode = webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']/li[2]"));
            timeTypeCode.Click();

            //Enter Code
            IWebElement codeTextbox = webDriver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("ICMarch2024");

            //Enter Description
            IWebElement descriptionTextbox = webDriver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("ICMarch2024 Description");

            WaitUtils.WaitToBeVisible(webDriver, "Xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 5);

            //Enter Price
            IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("250.00");

            //Click on Select File button and select a file

            //Click on save button
            WaitUtils.WaitToBeVisible(webDriver, "Id", "SaveButton", 5);
            IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(5000);

            //Check if a new Time/Material record has been created successfully
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            VerifyRecordCreated(webDriver);
        }

        public void VerifyRecordCreated(IWebDriver webDriver)
        {
            IWebElement newCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newCode.Text == "ICMarch2024")
            {
                Console.WriteLine("New Time record has been created successfully");
            }
            else
            {
                Console.WriteLine("New Time record has not been created");
            }
        }

        public void EditNewlyCreatedTMRecord(IWebDriver webDriver)
        {

        }
        public void DeleteTMRecord(IWebDriver webDriver)
        {

        }
    }
}
