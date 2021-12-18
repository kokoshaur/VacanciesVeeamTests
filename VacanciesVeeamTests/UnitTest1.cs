using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//Гринченко Сергей
namespace VacanciesVeeamTests
{
    public class Tests
    {
        IWebDriver page = new ChromeDriver();

        By _departamentsList = By.XPath("//div[@class = 'col-12 col-lg-4']//div[2]//button");
        By _developProductButton = By.XPath("//div[@class = 'col-12 col-lg-4']//div[2]//div[@x-placement = 'bottom-start']/a[6]");

        By _languagesList = By.XPath("//div[@class = 'col-12 col-lg-4']//div[3]//button");
        By _englishButton = By.XPath("//div[@class = 'col-12 col-lg-4']//div[3]//label[@for = 'lang-option-0']");

        By _tableVacancies = By.XPath("//div[@class = 'h-100 d-flex flex-column']/a");
        [SetUp]
        public void Setup()
        {
            page.Manage().Window.Maximize();
            page.Navigate().GoToUrl("https://careers.veeam.ru/vacancies");
        }

        [TestCase(6)]
        public void Test1(int trueCount)
        {
            //Выбор разработки продуктов
            page.FindElement(_departamentsList).Click();
            page.FindElement(_developProductButton).Click();

            //Выбор английского
            page.FindElement(_languagesList).Click();
            page.FindElement(_englishButton).Click();

            //Подcчёт
            int count = page.FindElements(_tableVacancies).Count;

            Assert.AreEqual(count, trueCount, "Wrong resilt, expected " + trueCount + ", prove = " + count);
        }

        [TearDown]
        public void TearDown()
        {
            page.Quit();
        }
    }
}