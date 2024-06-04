using AngelicaTester.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AngelicaTester.Pages
{
    internal class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Click on Create New Button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            //Select Material from TypeCode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();

            Thread.Sleep(1000);

            IWebElement materialOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            materialOption.Click();

            // Identify the code textbox and input a code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("AngelicaTester");

            // Identify the description textbox and input a description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("AngelicaTester");

            //Identify the price textbox and input price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // Click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 2);

            // Click on go to last page button
            IWebElement goToLastButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastButton.Click();
            Thread.Sleep(1000);

            // Check if record is present in the table and has expected value
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (actualCode.Text == "AngelicaTester")
            {
                Console.WriteLine("Material record created successffully, test passed.");
            }
            else
            {
                Console.WriteLine("Teste failed.");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            
        }

        internal void DeleteTM(IWebDriver driver)
        {
            throw new NotImplementedException();
        }
    }
}
