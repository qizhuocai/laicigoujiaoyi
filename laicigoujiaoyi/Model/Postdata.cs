using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laicigoujiaoyi
{
    class Postdata
    {
        public class PetsOnSaleItem
        {
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string petId { get; set; }
            /// <summary>
            /// 出生类型
            /// </summary>
            public int birthType { get; set; }
            /// <summary>
            /// 突变
            /// </summary>
            public int mutation { get; set; }
            /// <summary>
            /// 代数
            /// </summary>
            public int generation { get; set; }
            /// <summary>
            /// 稀有度
            /// </summary>
            public int rareDegree { get; set; }
            /// <summary>
            /// 小莱
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int petType { get; set; }
            /// <summary>
            /// 价格
            /// </summary>
            public string amount { get; set; }
            /// <summary>
            /// 颜色
            /// </summary>
            public string bgColor { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string petUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string validCode { get; set; }
        }

        public class Data
        {
            /// <summary>
            /// 
            /// </summary>
            public List<PetsOnSaleItem> petsOnSale { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int totalCount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string hasData { get; set; }
        }

        public class Root
        {
            /// <summary>
            /// 
            /// </summary>
            public string errorNo { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string errorMsg { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string timestamp { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Data data { get; set; }
        }
    }
}
