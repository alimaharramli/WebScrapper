using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Linq;
using SearchRes;
namespace ClassProj.Selenium{
    
    public class DotNetClassProj{


        public static void Main(string[] args){
            IWebDriver driver = BrowserUtils.StartBrowser();

            string searchbar_xpath="//input[@id='twotabsearchtextbox']";

            driver.Navigate().GoToUrl("https://amazon.com/");

            BrowserUtils.Wait(driver,searchbar_xpath);

            Console.WriteLine("Enter the product you want to search for: ");
            string productName=Console.ReadLine();

            
            IWebElement searchbar = driver.FindElement(By.XPath(searchbar_xpath));
            searchbar.Click();
            searchbar.SendKeys(productName);
            searchbar.Submit();

            List<Product> prodlist = ProductFinder.GetProducts(driver);

            ProductUtils.DisplayProducts(prodlist);
       
            driver.Dispose();
        }
    }
}