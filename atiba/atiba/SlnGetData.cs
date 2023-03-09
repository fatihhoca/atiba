using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Application = System.Windows.Forms.Application;

namespace atiba
{
    public static class SlnGetData
    {

        private static IWebElement veri;
        public static IWebDriver eokul;
        private static IList<IWebElement> aranan;
        private static Screenshot Photo;
        public static string Result;
        public static string geciciVeri, adsoyad;
        public static string SubSchool;
        public static string School;
        public static int Speed;
        public static bool Src;

        public static string EOkulUrl = "https://e-okul.meb.gov.tr/";
        public static string SrcUrl;
        public static string InfoUrl;
        public static string GeneralInfoUrl;
        public static string PopulationInfoUrl;
        public static string MomUrl;
        public static string DadUrl;
        public static string ExcusedUrl;
        public static string EduStatusId;
        public static string JobId;


        public static void Set_Speed(string rb_speed)
        {
            if (rb_speed == "speed_rb_normal")
            { Speed = 1; }
            else if (rb_speed == "speed_rb_slow")
            { Speed = 2; }
            else if (rb_speed == "speed_rb_slower")
            { Speed = 3; }
            Console.WriteLine(Speed);
        }

        public static void Set_School(string SchoolName)

        {
            School = SchoolName;
            Console.WriteLine(School);
            Console.WriteLine(SubSchool);
            if (School == "IlkOgretim")
            {
                SrcUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG01001.aspx";
                InfoUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02001.aspx";
                GeneralInfoUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/iog02002.aspx";
                PopulationInfoUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02003.aspx";
                MomUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02006.aspx";
                DadUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02005.aspx";
                ExcusedUrl = "https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG02015.aspx";

            }
            else if (School == "OrtaOgretim")
            {
                SrcUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG00001.aspx";
                InfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02001.aspx";
                GeneralInfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02002.aspx";
                PopulationInfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02003.aspx";
                MomUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02006.aspx";
                DadUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02005.aspx";
                ExcusedUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02015.aspx";

            }
            else if (School == "AIHOrtaOgretim")
            {
                SrcUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG01001.aspx";
                InfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02001.aspx";
                GeneralInfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02002.aspx";
                PopulationInfoUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02003.aspx";
                MomUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02006.aspx";
                DadUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02005.aspx";
                ExcusedUrl = "https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG02015.aspx";

            }
            else if (School == "OkulOncesi")
            {
                SrcUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG01001.aspx";
                InfoUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02001.aspx";
                GeneralInfoUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02002.aspx";
                PopulationInfoUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02003.aspx";
                MomUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02006.aspx";
                DadUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02005.aspx";
                ExcusedUrl = "https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG02015.aspx";

            }




        }



        public static void SearchStudent(string number)
        {

            if (School == "IlkOgretim")
            {
                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/IlkOgretim/OGR/IOG01001.aspx");
                Next_Wait(50);
                eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                veri.SendKeys(number);
                eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                Next_Wait(50);
            }




            else if (School == "OrtaOgretim")
            {
                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG00001.aspx");
                Next_Wait(50);
                //eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                aranan = eokul.FindElements(By.Id("OGRMenu1_ddlOkulAltTurYeni"));
                if (aranan.Count > 0)
                {
                    aranan[0].SendKeys(SubSchool);
                    Next_Wait(100);
                }

                veri = eokul.FindElement(By.Id("OGRMenu1_txtTCYeni"));
                veri.SendKeys(number);
                eokul.FindElement(By.Id("btnOgrenciAra")).Click();
                Next_Wait(50);
            }
            else if (School == "AIHOrtaOgretim")
            {
                try
                {
                    veri = eokul.FindElement(By.Id("mdlOOO"));
                    veri.Click();
                }
                catch
                {
                    eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OrtaOgretim/OGR/OOG01001.aspx");
                }

                veri = eokul.FindElement(By.Id("txtOkulNo"));
                veri.SendKeys(number);
                veri = eokul.FindElement(By.Id("btnListele"));
                veri.Click();
                Next_Wait(150);
                eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                Next_Wait(500);
                eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
                Next_Wait(500);
                Application.DoEvents();
                aranan = eokul.FindElements(By.XPath("//i[@class='fas fa-folder']"));
                aranan[0].Click();
                Next_Wait(50);
            }
            else if (School == "OkulOncesi")
            {
                eokul.Navigate().GoToUrl("https://e-okul.meb.gov.tr/OkulOncesi/OGR/AOG01001.aspx");
                Next_Wait(50);
                eokul.FindElement(By.Id("OGRMenu1_rdOkulNo")).Click();

                veri = eokul.FindElement(By.Id("OGRMenu1_txtTC"));
                veri.SendKeys(number);
                eokul.FindElement(By.Id("OGRMenu1_btnAra")).Click();
                Next_Wait(50);
            }



            veri = eokul.FindElement(By.Id("txtAdi"));
            string adSoyad = veri.GetAttribute("value").ToString();

            if (adSoyad.Trim() != "") { Src = true; } else { Src = false; }



        }

        public static string Get_Ogr_Adi()
        {

            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                try
                {
                    veri = eokul.FindElement(By.Id("txtAdi"));
                    Result = veri.GetAttribute("value").ToString();
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }



        public static string Get_Ogr_Soyadi()
        {

            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                try
                {
                    veri = eokul.FindElement(By.Id("txtSoyadi"));
                    Result = veri.GetAttribute("value").ToString(); ;
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Tc_No()
        {

            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                try
                {
                    veri = eokul.FindElement(By.Id("txtKisiTCKimlikNo"));
                    Result = veri.GetAttribute("value").ToString();
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Sinif()
        {

            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                try
                {

                    if (School == "IlkOgretim")
                    {
                        veri = eokul.FindElement(By.Id("IOMPageHeader1_lblSinif"));
                    }
                    else if (School == "OkulOncesi")
                    {
                        veri = eokul.FindElement(By.Id("AOMPageHeader1_lblSinif"));
                    }
                    else
                    { veri = eokul.FindElement(By.Id("OOMPageHeader1_lblSinif")); }

                    Result = veri.Text.ToString();

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Foto()
        {

            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                string StndClass;
                string StndNumber;
                try
                {


                    if (School == "IlkOgretim")
                    {
                        veri = eokul.FindElement(By.Id("IOMPageHeader1_lblSinif"));
                    }
                    else if (School == "OkulOncesi")
                    {
                        veri = eokul.FindElement(By.Id("AOMPageHeader1_lblSinif"));
                    }
                    else
                    { veri = eokul.FindElement(By.Id("OOMPageHeader1_lblSinif")); }

                    Result = veri.Text.ToString();


                    ((IJavaScriptExecutor)eokul).ExecuteScript("document.getElementsByTagName('img')[0].setAttribute('style', 'border-radius:0px;border-style: none;height:171px;width:133px;')");
                    if (School == "IlkOgretim")

                    {
                        veri = eokul.FindElement(By.Id("IOMPageHeader1_lblSinif"));
                        StndClass = veri.Text.ToString();
                        veri = eokul.FindElement(By.Id("IOMPageHeader1_lblNumara"));
                        StndNumber = veri.Text.ToString();

                        veri = eokul.FindElement(By.Id("IOMPageHeader1_imgOgrenciResim"));
                    }

                    else if (School == "OkulOncesi")
                    {
                        veri = eokul.FindElement(By.Id("AOMPageHeader1_lblSinif"));
                        StndClass = veri.Text.ToString();
                        veri = eokul.FindElement(By.Id("AOMPageHeader1_lblNumara"));
                        StndNumber = veri.Text.ToString();
                        veri = eokul.FindElement(By.Id("AOMPageHeader1_imgOgrenciResim"));
                    }

                    else
                    {
                        veri = eokul.FindElement(By.Id("OOMPageHeader1_lblSinif"));
                        StndClass = veri.Text.ToString();
                        veri = eokul.FindElement(By.Id("OOMPageHeader1_lblNumara"));
                        StndNumber = veri.Text.ToString();
                        veri = eokul.FindElement(By.Id("OOMPageHeader1_imgOgrenciResim"));
                    }




                    Photo = ((ITakesScreenshot)veri).GetScreenshot();
                    string yol = Application.StartupPath;
                    Directory.CreateDirectory(yol + "\\" + StndClass);
                    Photo.SaveAsFile(yol + "\\" + StndClass + "\\" + StndNumber + ".jpg", ScreenshotImageFormat.Jpeg);
                    Result = "Ok";
                }
                catch
                { Result = "Hata"; }

            }

            else
            {

                Result = "Bulunamadı";


            }

            return Result;

        }

        public static string Get_Ogr_Veli()
        {
            if (Src)
            {
                if (InfoUrl != eokul.Url) { eokul.Navigate().GoToUrl(InfoUrl); }
                try
                {
                    SelectElement se = new SelectElement(eokul.FindElement(By.Id("ddlVelisi")));

                    Result = se.SelectedOption.Text.ToString();


                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }


        public static string Get_Ogr_Uyruk()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }

                try
                {
                    veri = eokul.FindElement(By.XPath("//*[@id='uyruk']"));
                    Result = veri.Text;

                }
                catch
                { Result = "Hata"; }
            }

            else
            { Result = "Bulunamadı"; }

            return Result;
        }


        public static string Get_Ogr_Cinsiyet()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }

                try
                {
                    veri = eokul.FindElement(By.XPath("//*[@id='cinsiyet']"));
                    Result = veri.Text;

                }
                catch
                { Result = "Hata"; }
            }

            else
            { Result = "Bulunamadı"; }

            return Result;
        }


        public static string Get_Ogr_Dogum_Tarihi()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("dogumTarihi"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Dogum_Yeri()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("dogumYeri"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Nufus_Il()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("nufusIl"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Nufus_Ilce()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("nufusIlce"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Cilt_No()
        {
            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("ciltNo"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);


                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Aile_Sira_No()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("aileSiraNo"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);


                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Ogr_Sira_No()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {

                    veri = eokul.FindElement(By.Id("siraNo"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Mahlle_Köy()
        {

            if (Src)
            {
                if (PopulationInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(PopulationInfoUrl);
                    Next_Wait(50);
                    Open_Eyes(2);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("nufusMahalle"));
                    veri = veri.FindElement(By.TagName("img"));
                    geciciVeri = veri.GetAttribute("outerHTML").ToString();
                    geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf(":") + 7);
                    Result = geciciVeri.Substring(0, geciciVeri.Length - 2);
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Boy()
        {

            if (Src)
            {
                if (GeneralInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(GeneralInfoUrl);
                    Next_Wait(50);
                }
                try
                {

                    veri = eokul.FindElement(By.Id("txtBoy"));
                    Result = veri.GetAttribute("value").ToString();
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;


        }


        public static string Get_Ogr_Kilo()
        {

            if (Src)
            {
                if (GeneralInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(GeneralInfoUrl);
                    Next_Wait(50);
                }
                try
                {

                    veri = eokul.FindElement(By.Id("txtKilo"));
                    Result = veri.GetAttribute("value").ToString();
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Tasima()
        {

            if (Src)
            {
                if (GeneralInfoUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(GeneralInfoUrl);
                    Next_Wait(50);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("chkTasimaPalanDahilmi"));

                    if (veri.Selected == true)
                        Result = "Evet";
                    else
                        Result = "Hayır"; ;

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Ozurlu_Dev()
        {

            if (Src)
            {
                if (ExcusedUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(ExcusedUrl);
                    Next_Wait(50);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("tblOzurluDevamsizlikToplam"));
                    veri = veri.FindElement(By.Id("Table3"));
                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                    Result = tableTD[3].Text.ToString().Replace("gün", "").Trim();

                }
                catch
                { Result = "0"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Ogr_Ozursuz_Dev()
        {

            if (Src)
            {
                if (ExcusedUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(ExcusedUrl);
                    Next_Wait(50);
                }
                try
                {
                    veri = eokul.FindElement(By.Id("tblOzursuzDevamsizlikToplam"));
                    veri = veri.FindElement(By.Id("Table3"));
                    IList<IWebElement> tableRow = veri.FindElements(By.TagName("tr"));
                    IList<IWebElement> tableTD = tableRow[tableRow.Count - 2].FindElements(By.TagName("td"));
                    Result = tableTD[3].Text.ToString().Replace("gün", "").Trim();


                }
                catch
                { Result = "0"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;

        }

        public static string Get_Anne_Adi_Soyadi()
        {

            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[0].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("outerHTML").ToString();
                        geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                        Result = geciciVeri.Substring(0, geciciVeri.IndexOf("\""));
                        veri = aranan[2].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("outerHTML").ToString();
                        geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                        Result += " " + geciciVeri.Substring(0, geciciVeri.IndexOf("\""));
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Name("txtAdi"));
                        Result = veri.GetAttribute("value").ToString();
                        veri = eokul.FindElement(By.Name("txtSoyadi"));
                        Result += " " + veri.GetAttribute("value").ToString();
                    }

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Anne_Tc_No()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.XPath("//*[@id='chartdiv']/div/div[3]/div/div/div/div/div[2]/div/div[2]/div/div[1]/input"));
                        if (aranan.Count == 0)
                        {
                            aranan = eokul.FindElements(By.ClassName("col-6"));
                            veri = aranan[0].FindElement(By.TagName("h4"));
                            Result = veri.Text.ToString();
                        }
                        else
                        {
                            veri = eokul.FindElement(By.XPath("//*[@id='chartdiv']/div/div[3]/div/div/div/div/div[2]/div/div[2]/div/div[1]/input"));
                            Result = veri.GetAttribute("value");
                        }
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Id("txtAileTCKimlikNo"));
                        Result = veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Tel()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {
                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[15].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("src").ToString();
                        Result = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Id("txtTelCep"));
                        Result = veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Sag_Olu()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {
                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[4].FindElement(By.TagName("span"));
                        if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                            Result = veri.Text.ToString();
                    }
                    else
                    {

                        IWebElement radioBtn = eokul.FindElement(By.Id("rdSag"));
                        bool isSelected = radioBtn.Selected;

                        Result = (isSelected) ? "Sağ" : "Ölü";
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Birlikte()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                        veri = veri.FindElement(By.TagName("span"));
                        if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                            Result = veri.Text.ToString();
                    }
                    else
                    {

                        IWebElement radioBtn = eokul.FindElement(By.Id("rdBirlikte"));
                        bool isSelected = radioBtn.Selected;

                        Result = (isSelected) ? "Birlikte" : "Ayrı";

                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Mezuniyet()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                if (School != "OkulOncesi")
                {
                    EduStatusId = "ogrenimDurumu";

                }
                else
                {
                    EduStatusId = "ddlOgrenimDurumu";
                }
                bool hataVar = false;
                do
                {
                    try
                    {
                        Next_Wait(200);
                        SelectElement se = new SelectElement(eokul.FindElement(By.Id(EduStatusId)));
                        Result = se.SelectedOption.Text.ToString();
                        hataVar = false;
                    }
                    catch
                    {
                        Result = "Hata";
                        hataVar = true;
                        eokul.Navigate().Refresh();
                        Next_Wait(500);
                        if (School != "OkulOncesi") Open_Eyes(1);
                    }

                } while (hataVar == true);
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Dogum_Tarihi()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[9].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("src").ToString();
                        geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                        Result = geciciVeri;
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Name("txtDogumTarihi"));
                        Result = veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Anne_Mslk()
        {
            if (Src)
            {
                if (MomUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(MomUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                if (School != "OkulOncesi")
                {
                    JobId = "cmbMeslek";

                }
                else
                {
                    JobId = "ddlMeslegi";
                }

                bool hataVar = false;
                do
                {

                    try
                    {
                        Next_Wait(200);
                        SelectElement se = new SelectElement(eokul.FindElement(By.Id(JobId)));
                        Result = se.SelectedOption.Text.ToString();
                        hataVar = false;
                    }
                    catch
                    {
                        Result = "Hata";
                        hataVar = true;
                        eokul.Navigate().Refresh();
                        Next_Wait(500);
                        if (School != "OkulOncesi") Open_Eyes(1);
                    }

                } while (hataVar == true);
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }



        public static string Get_Baba_Adi_Soyadi()
        {

            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[0].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("outerHTML").ToString();
                        geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                        adsoyad = geciciVeri.Substring(0, geciciVeri.IndexOf("\""));
                        veri = aranan[2].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("outerHTML").ToString();
                        geciciVeri = geciciVeri.Remove(0, geciciVeri.IndexOf("BitMapResim=") + 12);
                        adsoyad += " " + geciciVeri.Substring(0, geciciVeri.IndexOf("\""));

                        Result = adsoyad;
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Name("txtAdi"));
                        Result = veri.GetAttribute("value").ToString();
                        veri = eokul.FindElement(By.Name("txtSoyadi"));
                        Result += " " + veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }

            return Result;
        }

        public static string Get_Baba_Tc_No()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {


                        aranan = eokul.FindElements(By.Id("yeniBabaTc"));
                        if (aranan.Count == 0)
                        {
                            aranan = eokul.FindElements(By.ClassName("col-6"));
                            veri = aranan[0].FindElement(By.TagName("h4"));
                            Result = veri.Text.ToString();
                        }
                        else
                        {
                            veri = eokul.FindElement(By.Id("yeniBabaTc"));
                            Result = veri.GetAttribute("value");
                        }
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Id("txtAileTCKimlikNo"));
                        Result = veri.GetAttribute("value").ToString();
                    }

                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Tel()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }

                try
                {
                    if (School != "OkulOncesi")
                    {





                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[15].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("src").ToString();
                        Result = geciciVeri.Remove(0, geciciVeri.IndexOf("=") + 1);
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Id("txtTelCep"));
                        Result = veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Sag_Olu()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[4].FindElement(By.TagName("span"));
                        if (veri.Text.ToString() == "Sağ" || veri.Text.ToString() == "Ölü")
                            Result = veri.Text.ToString();
                    }
                    else
                    {

                        IWebElement radioBtn = eokul.FindElement(By.Id("rdSag"));
                        bool isSelected = radioBtn.Selected;

                        Result = (isSelected) ? "Sağ" : "Ölü";
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Birlikte()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        veri = eokul.FindElement(By.XPath("//div[@class='form-check form-check-inline']"));
                        veri = veri.FindElement(By.TagName("span"));
                        if (veri.Text.ToString() == "Birlikte" || veri.Text.ToString() == "Ayrı")
                            Result = veri.Text.ToString();
                    }
                    else
                    {

                        IWebElement radioBtn = eokul.FindElement(By.Id("rdBirlikte"));
                        bool isSelected = radioBtn.Selected;

                        Result = (isSelected) ? "Birlikte" : "Ayrı";

                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Mezuniyet()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                if (School != "OkulOncesi")
                {
                    EduStatusId = "ogrenimDurumu";
                }
                else
                {
                    EduStatusId = "ddlOgrenimDurumu";
                }

                bool hataVar = false;
                do
                {
                    try
                    {
                        Next_Wait(200);
                        SelectElement se = new SelectElement(eokul.FindElement(By.Id(EduStatusId)));
                        Result = se.SelectedOption.Text.ToString();
                        hataVar = false;
                    }
                    catch
                    {
                        Result = "Hata";
                        hataVar = true;
                        eokul.Navigate().Refresh();
                        Next_Wait(500);
                        if (School != "OkulOncesi") Open_Eyes(1);
                    }

                } while (hataVar == true);
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Dogum_Tarihi()
        {
            if (Src)
            {
                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(50);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                try
                {
                    if (School != "OkulOncesi")
                    {

                        aranan = eokul.FindElements(By.ClassName("col-sm-4"));
                        veri = aranan[9].FindElement(By.TagName("img"));
                        geciciVeri = veri.GetAttribute("src").ToString();
                        geciciVeri = geciciVeri.Substring(geciciVeri.IndexOf("=") + 1);
                        Result = geciciVeri;
                    }
                    else
                    {
                        veri = eokul.FindElement(By.Name("txtDogumTarihi"));
                        Result = veri.GetAttribute("value").ToString();
                    }
                }
                catch
                { Result = "Hata"; }
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }

        public static string Get_Baba_Mslk()
        {
            if (Src)
            {


                if (DadUrl != eokul.Url)
                {
                    eokul.Navigate().GoToUrl(DadUrl);
                    Next_Wait(500);
                    if (School != "OkulOncesi") Open_Eyes(1);
                }
                if (School != "OkulOncesi")
                {
                    JobId = "cmbMeslek";
                }
                else
                {
                    JobId = "ddlMeslegi";
                }

                bool hataVar = false;
                do
                {

                    try
                    {
                        Next_Wait(200);
                        SelectElement se = new SelectElement(eokul.FindElement(By.Id(JobId)));
                        Result = se.SelectedOption.Text.ToString();
                        hataVar = false;
                    }
                    catch
                    {
                        Result = "Hata";
                        hataVar = true;
                        eokul.Navigate().Refresh();
                        Next_Wait(500);
                        if (School != "OkulOncesi") Open_Eyes(1);
                    }

                } while (hataVar == true);
            }
            else
            { Result = "Bulunamadı"; }
            return Result;
        }







        public static void Baglan()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            eokul = new ChromeDriver(service);
            eokul.Manage().Window.Maximize();
            eokul.Navigate().GoToUrl(EOkulUrl);
        }
        public static void BaglantiKes()
        {
            if (eokul != null)
                eokul.Quit();
        }


        public static string[] Set_List(string prefix)
        {
            var methods = typeof(SlnGetData)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name.StartsWith("Get_" + prefix));
            string[] list = new string[methods.Count()];
            int i = 0;

            foreach (var method in methods)
            {

                list[i] = method.Name.Substring("Get_".Length);

                i++;
            }
            return list;
        }


        private static void Open_Eyes(byte secim)
        {
            ((IJavaScriptExecutor)eokul).ExecuteScript("document.getElementsByClassName('dropdown drp-user')[0].setAttribute('style', 'visibility: hidden;')");

            IList<IWebElement> aranan;
            DateTime start;

            start = DateTime.Now;
            do
            {
                if (secim == 1)
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20']"));
                else
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20 bak']"));

                if (Convert.ToInt32((DateTime.Now - start).TotalSeconds) > 5)
                {
                    eokul.Navigate().Refresh();
                    Next_Wait(100);
                }

            } while (aranan.Count == 0);

            Next_Wait(50);
            eokul.FindElement(By.TagName("body")).SendKeys(OpenQA.Selenium.Keys.End);
            do
            {
                foreach (IWebElement deger in aranan)
                {
                    try
                    {
                        deger.Click();
                        Next_Wait(10);
                    }
                    catch { }
                    finally { Application.DoEvents(); }
                }
                if (secim == 1)
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20']"));
                else
                    aranan = eokul.FindElements(By.XPath("//i[@class='feather icon-eye f-20 bak']"));
            } while (aranan.Count > 0);
            Application.DoEvents();
        }

        private static void Next_Wait(int saniye)
        {


            DateTime start = DateTime.Now;
            while (Convert.ToInt32((DateTime.Now - start).TotalMilliseconds) < saniye * Speed)
            {

            }
        }


    }


}