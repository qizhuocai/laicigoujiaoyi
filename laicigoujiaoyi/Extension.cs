using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laicigoujiaoyi
{
    class Extension
    {
        public static List<string> dogImage()
        {
          
           List<string > newimg = new List<string> ()  ;
            try
            {
                string ret = Dog.getCha();
                JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
                newimg.Add  ( (string)res_j["data"]["seed"]);
                newimg.Add ( (string)res_j["data"]["img"]);
                // pictureBox2.Image = Dog.str2Image(img);
            }
            catch (Exception) { }
            return newimg;
        }
    }
}
