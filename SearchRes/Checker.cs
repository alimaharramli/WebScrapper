using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace SearchRes;

public static class Checker{
    public static string SearchCheck(IWebDriver driver,string xpath,int type=0){
        try{
            var arr = driver.FindElements(By.XPath(xpath));
            string tmp="";
            foreach(var elem in arr){
                tmp+=elem.Text+" ";
                if(type==1) tmp+='\n'+elem.FindElement(By.XPath("./..")).GetAttribute("href")+" ";
            }
            return tmp;
        }catch{
            return "";
        }
    }
}