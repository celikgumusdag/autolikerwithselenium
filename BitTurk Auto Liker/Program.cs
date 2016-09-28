using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebDriverTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();

            //Linki dışardan almak için console.readline yapılmalıdır
            //Console.WriteLine("Hangi Url Gidelim");
            //string link = Console.ReadLine();
            //Şimdilik static veriyorum bu kısmı isterseniz excelden okut istersen dbden
            //Loopa sok excel bitene kadar oradaki linklere bu işlemi yapsın vs vs.
            string link = "http://www.bitturk.net/?p=forums&pid=11&fid=15&tid=37751";

            //Linke Git
            webDriver.Navigate().GoToUrl(link);

            //Username Yaz
            webDriver.FindElement(By.CssSelector("#loginbox_membername")).SendKeys("lompolo");

            //Şifre Yaz
            webDriver.FindElement(By.CssSelector("#loginbox_password")).SendKeys("+4351304");

            //Login Butonuna Bas
            webDriver.FindElement(By.CssSelector("#loginbox-buttons>input:nth-of-type(1)")).Click();

            //Like butonu hemen gelmediği için beklemek gerekiyor
            //Alttaki şekilde static zaman beklemektense sayfayı yenilerim daha iyi
            //System.Threading.Thread.Sleep(10000);
            webDriver.Navigate().GoToUrl(link);

            //Like tuşuna bas
            webDriver.FindElement(By.CssSelector(".showPost:nth-of-type(1) #like")).Click();

            //Copyright © Çelik Gümüşdağ

        }
    }

}
