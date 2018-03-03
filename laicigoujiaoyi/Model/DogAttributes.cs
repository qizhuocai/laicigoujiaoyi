using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laicigoujiaoyi.Model
{
    class DogAttributes
    {
        public class AttributesItem
        {
            /// <summary>
            /// 体型
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 角鲸
            /// </summary>
            public string value { get; set; }
            /// <summary>
            /// 稀有
            /// </summary>
            public string rareDegree { get; set; }
        }

        public class AttributesData
        {
            /// <summary>
            /// 
            /// </summary>
            public string id { get; set; }
            /// <summary>
            /// 小莱
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string petId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int generation { get; set; }
            /// <summary>
            /// 稀有
            /// </summary>
            public string rareDegree { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<AttributesItem> attributes { get; set; }
            /// <summary>
            /// 小莱
            /// </summary>
            public string desc { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string amount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int selfStatus { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string faterId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string motherId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string isOnChain { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string bgColor { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string headIcon { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string userName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string petUrl { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string onChain { get; set; }
        }

        public class AttributesRoot
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
            public AttributesData data { get; set; }
        }
    }
}
