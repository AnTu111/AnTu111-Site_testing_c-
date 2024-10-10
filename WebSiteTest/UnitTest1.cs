using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace WebSiteTest
{
    public class Tests
    {
        IWebDriver driver;
        String test_url = "https://andreitupits23.thkit.ee/phpAndreiTupits/index.php?veebileht=vormid.php";
        private readonly Random _random = new Random();

        [SetUp]
        public void start_browser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void test_page1()
        {
            driver.Url = test_url;
            driver.SwitchTo().DefaultContent();

            // ����� ����� ������� ������
            Thread.Sleep(2000);

            // ���������� ����� ���� text
            var textFields = driver.FindElements(By.XPath("//input[@type='text']"));
            foreach (var field in textFields)
            {
                try
                {
                    field.Click();
                    field.Clear();
                    field.SendKeys("Andrei");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in text input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ����� text

            // ���������� ����� ���� email
            var emailFields = driver.FindElements(By.XPath("//input[@type='email']"));
            foreach (var emailField in emailFields)
            {
                try
                {
                    emailField.Click();
                    emailField.Clear();
                    emailField.SendKeys("example@example.com"); // ������ ����� ����������� �����
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in email input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ����� email

            // ���������� ����� ���� password
            var passwordFields = driver.FindElements(By.XPath("//input[@type='password']"));
            foreach (var passwordField in passwordFields)
            {
                try
                {
                    passwordField.Click();
                    passwordField.Clear();
                    passwordField.SendKeys("Password123"); // ������ ������
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in password input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ����� password

            // ���������� ����� ���� tel
            var telFields = driver.FindElements(By.XPath("//input[@type='tel']"));
            foreach (var telField in telFields)
            {
                try
                {
                    telField.Click();
                    telField.Clear();
                    telField.SendKeys("+1234567890"); // ������ ���������� �����
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in tel input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ����� tel

            // ����� ��������� �����������
            var radioButtons = driver.FindElements(By.XPath(".//input[@type='radio']"));
            var randomIndex = _random.Next(0, radioButtons.Count);
            var selectedRadio = radioButtons[randomIndex];
            if (selectedRadio.Enabled)
            {
                try { selectedRadio.Click(); }
                catch (Exception ex) { Console.WriteLine($"Error, unable to click radio button: {ex.Message}"); }
            }
            else
            {
                Console.WriteLine("Error, radio button is disabled");
            }

            Thread.Sleep(2000); // ����� ����� ������ �����������

            // ���������� ���������
            var checkboxes = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            foreach (var checkbox in checkboxes)
            {
                try { checkbox.Click(); }
                catch (Exception ex) { Console.WriteLine($"Error, unable to click checkbox: {ex.Message}"); }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ���������

            // ����� ����� �� ���������� �������
            var selectElements = driver.FindElements(By.XPath("//select"));
            foreach (var select in selectElements)
            {
                try
                {
                    select.Click();
                    select.FindElements(By.XPath(".//*"))[2].Click(); // ����� �������� ��������
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to select from dropdown: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ������ �� ���������� �������

            // ���������� ���� ����
            var dateFields = driver.FindElements(By.XPath("//input[@type='date']"));
            foreach (var dateField in dateFields)
            {
                try
                {
                    dateField.Clear();
                    dateField.SendKeys("2024-10-10"); // ������ ������ ����
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Error: Unable to fill in date input field - {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ���� ����

            // ���������� ����� ���� number
            var numberFields = driver.FindElements(By.XPath("//input[@type='number']"));
            foreach (var numberField in numberFields)
            {
                try
                {
                    numberField.Click();
                    numberField.SendKeys("30"); // ������ ����� 30
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in number input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // ����� ����� ���������� ����� number

            // ������� �� ������
            var submitButton = driver.FindElement(By.XPath("//input[@type='button']"));
            try { submitButton.Click(); }
            catch (Exception ex) { Console.WriteLine($"Error, unable to click submit button: {ex.Message}"); }

            Thread.Sleep(2000); // ����� ����� ������� ������

            // ����� �����
            var resetButton = driver.FindElement(By.XPath("//input[@type='reset']"));
            resetButton.Click();

            Thread.Sleep(2000); // ����� ����� ������ �����

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
