using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open Chrome Browser
IWebDriver webDriver = new ChromeDriver();
webDriver.Manage().Window.Maximize();

//Launch turnUp Portal and navigate to login page
webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login");

//Identify username textbox and enter valid username
IWebElement usernameTextbox = webDriver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify password textbox and enter valid password
IWebElement passwordTextbox = webDriver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify login button and click on the button
IWebElement loginButton = webDriver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();

//Check if user has logged in successfully
IWebElement helloHariLink = webDriver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if (helloHariLink.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in.");
}


//Create a new Time/Material record

//Navigate to Time and Material module (Click Administration button -> Select Time & Material Option)
IWebElement administrationDropdown = webDriver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
administrationDropdown.Click();
IWebElement tmOption = webDriver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();

//Click on the Create New Button
IWebElement createNewButton = webDriver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

Thread.Sleep(5000);

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

//Enter Price
IWebElement priceTextbox = webDriver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("250.00");

//Click on Select File button and select a file

//Click on save button
IWebElement saveButton = webDriver.FindElement(By.Id("SaveButton"));
saveButton.Click();

Thread.Sleep(5000);

//Check if a new Time/Material record has been created successfully
IWebElement goToLastPageButton = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton.Click();

IWebElement newCode = webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (newCode.Text == "ICMarch2024")
{
    Console.WriteLine("New Time record has been created successfully");
}
else
{
    Console.WriteLine("New Time record has not been created");
}

