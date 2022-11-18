using CsvHelper;
using CsvHelper.Configuration;
using java.io;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using sun.tools.tree;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using SeleniumFirstApp;
using static com.sun.tools.classfile.Dependencies;
using System.Drawing;
using javax.swing.text.html;

namespace SeleniumFirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://network.com.tr");
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            driver.FindElement(By.Id("search")).SendKeys("ceket");
            driver.FindElement(By.Id("search")).SendKeys(Keys.Enter);
            driver.FindElement(By.XPath(".//*[@class='page-wrapper']/div/div/div/div/button")).Click();
            driver.FindElement(By.XPath(".//*[@class='tool__button -sorting']")).Click();
            driver.FindElement(By.XPath(".//*[@class='tool__content -show']/ul/li/span")).Click();
            driver.FindElement(By.Id("product-115346")).Click();
            driver.FindElement(By.XPath(".//*[@class='product__content -sizes']/div[3]")).Click();
            driver.FindElement(By.XPath(".//*[@class='col-12 col-lg-4']/div/div[7]/button[2]")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath(".//*[@class='header__basket js-basket header__basketLink']")).Click();
            driver.FindElement(By.XPath(".//*[@class='header__desktopBasket']/div/div[3]/a")).Click();
            ReadOnlyCollection<IWebElement> anapara = driver.FindElements(By.XPath(".//*[@class='layout__sidebar']/div/div[2]/div[2]/div/div[2]"));
            ReadOnlyCollection<IWebElement> tplpara = driver.FindElements(By.XPath(".//*[@class='layout__sidebar']/div/div[2]/div[3]/div/div[2]"));

            if (anapara != tplpara)
            {
                System.Console.WriteLine("İndirim Gerçekleşti");
                driver.FindElement(By.XPath(".//*[@class='layout__content']/div[2]/div/div[2]/button")).SendKeys(Keys.Enter);
                var records = new List<Bilgi>()
                {
                    new Bilgi { id = 1, email="yasinoncu13@gmail.com", pass="Password1!" },
                };
                using (var reader = new StreamReader("C:\\Users\\Yasin\\source\\repos\\IsMulakat\\Mulakat.csv"))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var record = csv.GetRecord<Bilgi>();
                        // Do something with the record.
                    }
                }
                using (var writer = new StreamWriter("C:\\Users\\Yasin\\source\\repos\\IsMulakat\\Mulakat.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteHeader<Bilgi>();
                    csv.NextRecord();
                    foreach (var record in records)
                    {
                        csv.WriteRecord(record);
                        csv.NextRecord();
                    }
                }
                Bilgi bilgi = new Bilgi();
                bilgi.email = "yasinoncu13@gmail.com";
                bilgi.pass = "Password1!";

                driver.FindElement(By.XPath(".//*[@id='login']/div/div/input")).SendKeys(bilgi.email);
                driver.FindElement(By.XPath(".//*[@id='login']/div[2]/div/input")).SendKeys(bilgi.pass);
                driver.FindElement(By.XPath(".//*[@id='login']/button")).Click();
                Thread.Sleep(5000);
                driver.FindElement(By.XPath(".//*[@class='container']/div/div[2]/a")).Click();
                driver.FindElement(By.XPath(".//*[@class='stickyHeader']/header/div/div/div[3]/div[2]/button")).Click();
                driver.FindElement(By.XPath(".//*[@class='header__desktopBasket']/div/div[2]/div/div[3]/svg/use")).Click();
                driver.FindElement(By.XPath(".//*[@class='o-modal__wrapper']/div[2]/div/div[2]/button[2]")).Click();

            }
            else
            {
                System.Console.WriteLine("Fiyat aynı.İndirim yoktur ! ");
            }
            
        }
        public class BilgiMap : ClassMap<Bilgi>
        {
            public BilgiMap()
            {
                Map(m => m.id).Index(0).Name("id");
                Map(m => m.email).Index(1).Name("E-Posta");
                Map(m => m.pass).Index(2).Name("Sifre");
            }
        }
        public class Bilgi
        {
            public int id { get; set; }
            public string email { get; set; }
            public string pass { get; set; }
        }
    }
}