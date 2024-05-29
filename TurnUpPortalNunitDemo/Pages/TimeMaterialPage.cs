using NUnit.Framework;
using OpenQA.Selenium;
using TurnUpPortalNunitDemo.Utilities;

namespace TurnUpPortalNunitDemo.Pages
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
            /*if (newCode.Text == "ICMarch")
            {
                Assert.Pass("New Time record has been created successfully");
            }
            else
            {
                Assert.Fail("New Time record has not been created");
            }*/

            Assert.That(newCode.Text == "ICMarch2024", "New Time record has not been created");
        }

        public void EditNewlyCreatedTMRecord(IWebDriver webDriver)
        {
            //Code for Edit Time Record
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on Edit Button
            IWebElement editButton = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);

            //Edit Code in Code Textbox
            IWebElement editCodeTextbox = webDriver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("IC2024Edited");

            //Edit Description in Description Textbox
            IWebElement editDescriptionTextBox = webDriver.FindElement(By.Id("Description"));
            editDescriptionTextBox.Clear();
            editDescriptionTextBox.SendKeys("IC2024Edited");

            //Edit Price in Price Textbox
            WaitUtils.WaitToBeVisible(webDriver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 3);
            IWebElement editPriceOverlappingTag = webDriver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceTextBox = webDriver.FindElement(By.Id("Price"));
            editPriceOverlappingTag.Click();
            editPriceTextBox.Clear();
            editPriceOverlappingTag.Click();
            editPriceTextBox.SendKeys("500");

            //Click on save button
            IWebElement editSaveButton = webDriver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(4000);

            // Clock on goToLastPage Button
            IWebElement editGoToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement editedCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement EditedDescription = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            Assert.That((editedCode.Text == "IC2024Edited"), "Time Record has not been updated");
        }

        public void DeleteTMRecord(IWebDriver webDriver)
        {
            //Code for Delete Time Record
            WaitUtils.WaitToBeVisible(webDriver, "Xpath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 5);
            IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on delete button
            IWebElement deleteButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            IAlert simpleAlert = webDriver.SwitchTo().Alert();
            simpleAlert.Accept();

            IWebElement lastCodeInTable = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That((lastCodeInTable.Text.Equals("IC2024Edited")), "Time Record has not been deleted");
        }
    }
}
