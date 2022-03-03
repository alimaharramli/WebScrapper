using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using SeleniumExtras.WaitHelpers;
namespace SearchRes;

public static class BrowserUtils{
    public static IWebDriver StartBrowser(){
        var opts = new ChromeOptions();
        // opts.AddArguments("--headless");
        // opts.AddArguments("--disable-gpu");
        opts.AddExcludedArgument("enable-logging");
        
        ChromeDriverService service = ChromeDriverService.CreateDefaultService();
        service.SuppressInitialDiagnosticInformation = true;
        service.HideCommandPromptWindow = true;
        
        var driver = new ChromeDriver(service, opts);
        return driver;
    }


    public static void Wait(IWebDriver driver, string xpath){
        WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(30));
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(xpath)));    
    }
}