using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Codecademy;

public class Tests
{
    private ChromeDriver driver;
    private readonly string CATALOG = ".//button[@title='Catalog']";
    private readonly string CATALOG_MENU_ITEM = ".//div[(contains(text(), 'Python'))]";

    [OneTimeSetUp]
    public void BasicSetup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        driver.Manage().Window.Maximize();
    }

    [SetUp]
    public void Setup()
    {
        driver.Navigate().GoToUrl("https://codecademy.com");
    }

    [Test]
    public void Test1()
    {
        Thread.Sleep(2000);
        driver.FindElement(By.XPath(CATALOG)).Click();
        var isCatalogMenuItemPresented = driver.FindElement(By.XPath(CATALOG_MENU_ITEM)).Displayed;
        Assert.That(isCatalogMenuItemPresented, Is.True);
        Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
        screenShot.SaveAsFile("Screnshot");
        Thread.Sleep(2000);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}
