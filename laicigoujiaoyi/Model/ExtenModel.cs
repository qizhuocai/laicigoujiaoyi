using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laicigoujiaoyi.Model
{
    class ExtenModel
    {
        /// <summary>
        /// petid, string price_str, string vcodestring seedaa, string chaaa
        /// </summary>
        private static string petid;
        /// <summary>
        /// petid
        /// </summary>
        public static string Getpetid
        {
            get { return petid; }
            set { petid = value; }

        }
        private static string price_str;
        /// <summary>
        /// 价格
        /// </summary>
        public static string Getprice_str
        {
            get { return price_str; }
            set { price_str = value; }
        }
        private static string vcode;
        /// <summary>
        /// vcode
        /// </summary>
        public static string Getvcode
        {
            get { return vcode; }
            set { vcode = value; }
        }
        private static string seedaa;
        /// <summary>
        /// seed
        /// </summary>
        public static string Getseedaa
        {
            get { return seedaa; }
            set { seedaa = value; }
        }
        private static string chaaa;
        /// <summary>
        /// cha
        /// </summary>
        public static string Getchaaa
        {
            get { return chaaa; }
            set { chaaa = value; }
        }
    }
}
