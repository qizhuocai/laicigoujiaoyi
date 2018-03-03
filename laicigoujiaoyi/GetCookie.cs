using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;

namespace laicigoujiaoyi
{
    public partial class GetCookie : Form
    {
        public GetCookie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1  .Url = new Uri("https://passport.baidu.com/");
         
        }
        private static string GetCookies(string url)
        {
            uint datasize = 256;
            StringBuilder cookieData = new StringBuilder((int)datasize);
            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x2000, IntPtr.Zero))
            {
                if (datasize < 0)
                    return null;


                cookieData = new StringBuilder((int)datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, IntPtr.Zero))
                    return null;
            }
            return cookieData.ToString();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            CookieContainer myCookieContainer = new CookieContainer();
            if (webBrowser1.Document.Cookie != null)
            {
               
                string cookieStr = webBrowser1.Document.Cookie;
                string[] cookstr = cookieStr.Split(';');
                foreach (string str in cookstr)
                {
                    string[] cookieNameValue = str.Split('=');
                    Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                    ck.Domain = "www.baidu.com";
                    myCookieContainer.Add(ck);
                }
            }
        }

   
        private void button4_Click(object sender, EventArgs e)
        {
            CookieContainer cookieContainer = new CookieContainer();

            //得到cookie
            CookieCollection cookies = cookieContainer.GetCookies(new Uri("http://baidu.com"));
            //遍历得到cookie
            if (cookies != null)
            {
                foreach (System.Net.Cookie cookie in cookies)
                {
                    //每一个cookie
                }
            }

            //得到cookie的头
            string cookieHeader = cookieContainer.GetCookieHeader(new Uri("http://baidu.com"));
        }

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref System.UInt32 pcchCookieData, int dwFlags, IntPtr lpReserved);

        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int InternetSetCookieEx(string lpszURL, string lpszCookieName, string lpszCookieData, int dwFlags, IntPtr dwReserved);

        private void button5_Click(object sender, EventArgs e)
        {
            string papa = Application.StartupPath; 
            try
            {
                // var cookieString = GetCookies("https://passport.baidu.com");
                //CookieContainer myCookieContainer = new CookieContainer();
                string cookieStr = GetCookies("https://passport.baidu.com");
                string[] cookstr = cookieStr.Split(';');
                Dictionary<string, string> strlist = new Dictionary<string, string>();
                foreach (string str in cookstr)
                {
                    string[] cookieNameValue = str.Split('=');
                    //  Cookie ck = new Cookie(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                    strlist.Add(cookieNameValue[0].Trim().ToString(), cookieNameValue[1].Trim().ToString());
                    ///   ck.Domain = "www.baidu.com";
                    /// myCookieContainer.Add(ck);
                }
                string BDUSS = strlist["BDUSS"];
                //获取根节点对象
                XDocument document = new XDocument();
                XElement root = new XElement("Cookie");
                //  XElement book = new XElement("BOOK");
                root.SetElementValue("BDUSS", BDUSS);
               // root.Add(root);
                root.Save(papa+ "\\Cookie.xml");
                MessageBox.Show("获取成功");
                //Console.ReadKey();
            }
            catch (Exception)
            {

              
            }
        }

        private void GetCookie_Load(object sender, EventArgs e)
        {

        }
    }
    
}
