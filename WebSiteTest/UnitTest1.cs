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

            // Пауза перед началом работы
            Thread.Sleep(2000);

            // Заполнение полей типа text
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

            Thread.Sleep(2000); // Пауза после заполнения полей text

            // Заполнение полей типа email
            var emailFields = driver.FindElements(By.XPath("//input[@type='email']"));
            foreach (var emailField in emailFields)
            {
                try
                {
                    emailField.Click();
                    emailField.Clear();
                    emailField.SendKeys("example@example.com"); // Вводим адрес электронной почты
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in email input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после заполнения полей email

            // Заполнение полей типа password
            var passwordFields = driver.FindElements(By.XPath("//input[@type='password']"));
            foreach (var passwordField in passwordFields)
            {
                try
                {
                    passwordField.Click();
                    passwordField.Clear();
                    passwordField.SendKeys("Password123"); // Вводим пароль
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in password input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после заполнения полей password

            // Заполнение полей типа tel
            var telFields = driver.FindElements(By.XPath("//input[@type='tel']"));
            foreach (var telField in telFields)
            {
                try
                {
                    telField.Click();
                    telField.Clear();
                    telField.SendKeys("+1234567890"); // Вводим телефонный номер
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in tel input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после заполнения полей tel

            // Выбор случайной радиокнопки
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

            Thread.Sleep(2000); // Пауза после выбора радиокнопки

            // Заполнение чекбоксов
            var checkboxes = driver.FindElements(By.XPath("//input[@type='checkbox']"));
            foreach (var checkbox in checkboxes)
            {
                try { checkbox.Click(); }
                catch (Exception ex) { Console.WriteLine($"Error, unable to click checkbox: {ex.Message}"); }
            }

            Thread.Sleep(2000); // Пауза после заполнения чекбоксов

            // Выбор опций из выпадающих списков
            var selectElements = driver.FindElements(By.XPath("//select"));
            foreach (var select in selectElements)
            {
                try
                {
                    select.Click();
                    select.FindElements(By.XPath(".//*"))[2].Click(); // Выбор третьего элемента
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to select from dropdown: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после выбора из выпадающих списков

            // Заполнение поля даты
            var dateFields = driver.FindElements(By.XPath("//input[@type='date']"));
            foreach (var dateField in dateFields)
            {
                try
                {
                    dateField.Clear();
                    dateField.SendKeys("2024-10-10"); // Вводим нужную дату
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Error: Unable to fill in date input field - {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после заполнения поля даты

            // Заполнение полей типа number
            var numberFields = driver.FindElements(By.XPath("//input[@type='number']"));
            foreach (var numberField in numberFields)
            {
                try
                {
                    numberField.Click();
                    numberField.SendKeys("30"); // Вводим число 30
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error, unable to fill in number input field: {ex.Message}");
                }
            }

            Thread.Sleep(2000); // Пауза после заполнения полей number

            // Нажатие на кнопку
            var submitButton = driver.FindElement(By.XPath("//input[@type='button']"));
            try { submitButton.Click(); }
            catch (Exception ex) { Console.WriteLine($"Error, unable to click submit button: {ex.Message}"); }

            Thread.Sleep(2000); // Пауза после нажатия кнопки

            // Сброс формы
            var resetButton = driver.FindElement(By.XPath("//input[@type='reset']"));
            resetButton.Click();

            Thread.Sleep(2000); // Пауза после сброса формы

            driver.SwitchTo().DefaultContent();
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}
