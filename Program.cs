using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;



namespace WebDriverTest
{

    class Program
    {
        public static IWebDriver WebDriver = new ChromeDriver();

        static void Main(string[] args)
        {

            string link;
            var fileStream = new FileStream(@"c:\file.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                link = streamReader.ReadToEnd();
                Console.WriteLine(link + " likelanıyor.");
                AutoLiker(link);
            }
            System.Threading.Thread.Sleep(5000);
            WebDriver.Dispose();
        }

        protected static void AutoLiker(string link)
        {

            //System.Threading.Thread.Sleep(5000);
            WebDriver.Manage().Window.Maximize();

            //Linki dışardan almak için console.readline yapılmalıdır
            //Console.WriteLine("Hangi Url Gidelim");
            //string link = Console.ReadLine();
            //Şimdilik static veriyorum bu kısmı isterseniz excelden okut istersen dbden
            //Loopa sok excel bitene kadar oradaki linklere bu işlemi yapsın vs vs.

            //Linke Git
            WebDriver.Navigate().GoToUrl(link);

            //Username Yaz
            WebDriver.FindElement(By.CssSelector("#loginbox_membername")).SendKeys("lompolo");

            //Şifre Yaz
            WebDriver.FindElement(By.CssSelector("#loginbox_password")).SendKeys("+4351304");

            //Login Butonuna Bas
            WebDriver.FindElement(By.CssSelector("#loginbox-buttons>input:nth-of-type(1)")).Click();

            //Like butonu hemen gelmediği için beklemek gerekiyor
            //Alttaki şekilde static zaman beklemektense sayfayı yenilerim daha iyi
            //System.Threading.Thread.Sleep(10000);
            WebDriver.Navigate().GoToUrl(link);

            //Like tuşuna bas

            for (int i = 1; i < CountWebElements(".showPost #like"); i++)
            {
                WebDriver.FindElement(By.CssSelector(".showPost:nth-of-type(" + i + ") #like")).Click();
            }

        }

        protected static int CountWebElements(String htmlText)
        {
            //List<IWebElement> forms = driver.FindElements(By.CssSelector(htmlText)).ToList();
            var forms = WebDriver.FindElements(By.CssSelector(htmlText));
            int counter = forms.Count;
            return counter;
        }
    }

}
