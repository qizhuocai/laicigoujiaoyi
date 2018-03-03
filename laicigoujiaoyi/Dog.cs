using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Drawing;

namespace laicigoujiaoyi
{
    class Dog
    {
        private static  string  cookie;
        public static  string GetCookieva
        {
            get { return cookie; }
            set { cookie = value; }
        }
        /// <summary>
        /// 刷新列表
        /// </summary>
        /// <returns></returns>
        public static string queryPetsOnSale(string pageNo,string pageSize ,string querySortType)
        {
            //第几页，
            //几个一页，
            //，RAREDEGREE_DESC 稀有度高 RAREDEGREE_ASC 稀有度低编码低 ，AMOUNT_ASC价格低， AMOUNT_DESC 价格高
            //
            //pageNo: 1, pageSize: 10, querySortType: "RAREDEGREE_ASC", petIds: [], lastAmount: null,
          
            string data_in = "{\"pageNo\":"+(pageNo)+ ",\"pageSize\":" + (pageSize) + ",\"querySortType\":\"" + (querySortType) + "\",\"petIds\":[],\"lastRareDegree\":null,\"requestId\":" + (Timenum ()) + ",\"appId\":1,\"tpl\":\"\"}";
            string post_url = "https://pet-chain.baidu.com/data/market/queryPetsOnSale";
            string res_str = HttpPost(data_in, post_url);
            return res_str;
        }
        /// <summary>
        /// 狗属性
        /// </summary>
        /// <returns></returns>
        public static string queryPetById(string petId)
        {
         //   HttpWebRequest request;
            //petId = "1882327725953129096";
            string data_in = "{\"petId\":\"" + petId + "\"," +
             "\"requestId\":" + (Timenum()) + "," +
             "\"appId\":1," +
             "\"tpl\":\"" +
             "\"}";
            string post_url = "https://pet-chain.baidu.com/data/pet/queryPetById";
            string res_str = HttpPost(data_in, post_url);
            return res_str;
          
        }
        /// <summary>
        /// 买狗
        /// </summary>
        /// <param name="petid"></param>
        /// <param name="vcode"></param>
        /// <param name="cookie"></param>
        /// <param name="price"></param>
        /// <param name="seed"></param>
        /// <param name="cha"></param>
        /// <returns></returns>
        public static string buyPet(string petid, string vcode, string price, string seed, string cha)
        {
            string data_in = "{\"petId\":\"" + petid +
                "\",\"amount\":\"" + price +
                "\",\"seed\":\"" + seed +
                "\",\"captcha\":\"" + cha +
                "\",\"validCode\":\"" + vcode +
                "\",\"requestId\":" + (Timenum ()) + ",\"appId\":1,\"tpl\":\"\"}";
             string post_url = "https://pet-chain.baidu.com/data/txn/create";
            return HttpPost( data_in, post_url);
        }
        public static string getgift(string seed, string cha, string shareCode, int b, string c)
        {
            string data_in = "{\"seed\":\"" + seed +
                "\",\"captcha\":\"" + cha +
                "\",\"shareCode\":\"" + shareCode +
                "\",\"requestId\":" + (Timenum ()) + ",\"appId\":" + (b) + ",\"tpl\":\"\"}";
            string post_url = "https://pet-chain.baidu.com/data/user/gift";
            return HttpPost( data_in, post_url);
        }
        public static string getCha()
        {
            string data_in = "{\"requestId\":" + (Timenum ()) + ",\"appId\":1,\"tpl\":\"\"}";
            string post_url = "https://pet-chain.baidu.com/data/captcha/gen";
            return HttpPost( data_in, post_url);
        }
        public static Image str2Image(string str)
        {
            byte[] b = Convert.FromBase64String(str);
            MemoryStream ms = new MemoryStream(b);
            Bitmap bitmap = new Bitmap(ms);
            return bitmap;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string showUser()
        {
            string data_in = "{\"requestId\":" + (Timenum()) + ",\"appId\":2,\"tpl\":\"\"}";
            string post_url = "https://pet-chain.baidu.com/data/user/get";
            return HttpPost( data_in, post_url);
        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string getMyOrder()
        {
            string data_in = "{\"pageNo\":1,\"pageSize\":10,\"pageTotal\":-1,\"requestId\":" + (Timenum()) + ",\"appId\":1,\"tpl\":\"\"}";
            string post_url = "https://pet-chain.baidu.com/data/user/order/list";
            string res_str= HttpPost( data_in, post_url);
            return res_str;
        }
        /// <summary>
        /// POst
        /// </summary>
        /// <param name="cookie"></param>
        /// <param name="data_in"></param>
        /// <param name="post_url"></param>
        /// <returns></returns>
        public static string HttpPost( string data_in, string post_url)
        {
            HttpWebRequest request;
            request = (HttpWebRequest)WebRequest.Create(post_url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.CookieContainer = new CookieContainer();
            request.CookieContainer.Add(new Cookie("BDUSS", cookie, "/", ".baidu.com"));
            request.ContentLength = Encoding.UTF8.GetByteCount(data_in);
            byte[] data = (Encoding.GetEncoding("utf-8")).GetBytes(data_in);
            request.GetRequestStream().Write(data, 0, data.Length);
            HttpWebResponse res = (HttpWebResponse)request.GetResponse();
            Stream st = res.GetResponseStream();
            Encoding en = Encoding.GetEncoding("utf-8");
            StreamReader st_r = new StreamReader(st, en);
            string res_str = st_r.ReadToEnd();
            st.Close();
            st_r.Close();
            return res_str;
        }
        public static int  Timenum()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(DateTime.Now - startTime).TotalSeconds;
        }
    }
}
