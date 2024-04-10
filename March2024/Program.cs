using March2024.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver webDriver = new ChromeDriver();

        //Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(webDriver, "hari", "123123");

        //Home page object initialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.VerifyLoggedInUser(webDriver);
        homePageObj.NavigateToTimeMaterialPage(webDriver);

        //TMPage object initiation and definition
        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        tmPageObj.CreateTimeRecord(webDriver);
        tmPageObj.EditNewlyCreatedTMRecord(webDriver);
        tmPageObj.DeleteTMRecord(webDriver);
    }
}