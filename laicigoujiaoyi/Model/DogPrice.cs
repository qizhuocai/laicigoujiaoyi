using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laicigoujiaoyi
{
    class DogPrice
    {
        
        private static int interval;
        /// <summary>
        /// 时间
        /// </summary>
        public static int Getinterval
        {
            get { return interval; }
            set { interval = value; }

        }
       
        private static string common;
        /// <summary>
        /// 普通
        /// </summary>
        public static string Getcommon
        {
            get { return common; }
            set { common = value; }
        }
        private static string rare;
        /// <summary>
        /// 稀有
        /// </summary>
        public static string Getrare
        {
            get { return rare; }
            set { rare = value; }
        }
        private static string excellence;
        /// <summary>
        /// 卓越
        /// </summary>
        public static string Getexcellence
        {
            get { return excellence; }
            set { excellence = value; }
        }
        private static string epic;
        /// <summary>
        /// 史诗
        /// </summary>
        public static string Getepic
        {
            get { return epic; }
            set { epic = value; }
        }
        private static string mythical;
        /// <summary>
        /// 神话
        /// </summary>
        public static string Getmythical
        {
            get { return mythical; }
            set { mythical = value; }
        }
        private static string Legend;
        /// <summary>
        /// 传说
        /// </summary>
        public static string GetLegend
        {
            get { return Legend; }
            set { Legend = value; }
        }
    }
}
