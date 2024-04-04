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
