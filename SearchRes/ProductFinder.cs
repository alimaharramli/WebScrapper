namespace SearchRes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.WaitHelpers;
using System.Linq;

public static class ProductFinder{
       public static List<Product> GetProducts(IWebDriver driver)
        {
        List<Product> prodlist = new List<Product>();
        int currentIndex = 0;
        int currentProductCount = 0;
        while (currentProductCount != 10)
        {
            string prod_xpath = "";
            try
            {
                prod_xpath = $"//div[@data-cel-widget='search_result_{currentIndex}'][@data-uuid]";
                driver.FindElement(By.XPath(prod_xpath));
            }
            catch
            {
                currentIndex++;
                continue;
            }
            if (prod_xpath == "")
            {
                currentIndex++;
                continue;
            }
            BrowserUtils.Wait(driver, prod_xpath);

            string title = Checker.SearchCheck(driver, $"{prod_xpath}//span[@class='a-size-medium a-color-base a-text-normal']", 0);
            if(String.IsNullOrEmpty(title)||String.IsNullOrWhiteSpace(title)) title = Checker.SearchCheck(driver, $"{prod_xpath}//span[@class='a-size-base-plus a-color-base a-text-normal']", 0);
            string price = GetPrice(driver,prod_xpath);
            string star = GetStar(driver, prod_xpath) ;
            
            
            string seller = Checker.SearchCheck(driver, $"{prod_xpath}//div[@class='a-row a-size-base a-color-secondary']//span");
            prodlist.Add(new Product(title, star, price, seller));
            currentProductCount++; currentIndex++;
        }
        return prodlist;
    }

    private static string GetStar(IWebDriver driver, string xPath) 
    {
        string star = "";
        try
        {
            star = driver.FindElement(By.XPath($"{xPath}//span[@class='a-icon-alt']")).GetAttribute("innerHTML");
        }
        catch
        {
            star = "The rating is not defined";
        }
        
        return star;
    }
    private static string GetPrice(IWebDriver driver, string xPath)
    {

        string price = "";
        try
        {
            price = driver.FindElement(By.XPath($"{xPath}//span[@class='a-price']//span[@class='a-offscreen']")).GetAttribute("innerHTML");
        }
        catch
        {
            price = "The price is not defined";
        }
        return price;
    }   

} 