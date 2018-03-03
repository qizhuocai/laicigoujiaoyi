using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.OleDb;
using System.Data.SQLite;
using System.IO;
using Tesseract;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Threading;
using laicigoujiaoyi.Model;
using static laicigoujiaoyi.Model.DogAttributes;
using Microsoft.VisualBasic;

namespace laicigoujiaoyi
{
    public partial class Form1 : Form
    {
        bool isrunning = false;
        string cookie = "";
        string cha = "";
        string seed = "";
        string newseed = "";
        string puimg = "";
        static string papa = Application.StartupPath;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        /// <summary>
        /// 加载配置
        /// </summary>
        public void GetConfigure()
        {
            try
            {
                // string papa = Application.StartupPath;
                XDocument document = XDocument.Load(papa + "\\Configure.xml");
                //获取到XML的根元素进行操作
                XElement root = document.Root;
                //XElement ele = root.Element("BDUSS");
                IEnumerable<XElement> enumerable = root.Elements();
                foreach (XElement item in enumerable)
                {
                    if (item.Name == "common")
                    {
                        DogPrice.Getcommon = item.Value.ToString();
                        textBox1.Text = DogPrice.Getcommon;
                    }
                    else if (item.Name == "rare")
                    {
                        DogPrice.Getrare = item.Value.ToString();
                        textBox2.Text = DogPrice.Getrare;
                    }
                    else if (item.Name == "excellence")
                    {
                        DogPrice.Getexcellence  = item.Value.ToString();
                        textBox3.Text = DogPrice.Getexcellence;

                    }
                    else if (item.Name == "epic")
                    {
                        DogPrice.Getepic  = item.Value.ToString();
                        textBox4.Text = DogPrice.Getepic;

                    }
                    else if (item.Name == "mythical")
                    {
                        DogPrice.Getmythical  = item.Value.ToString();
                        textBox5.Text = DogPrice.Getmythical;

                    }
                    else if (item.Name == "Legend")
                    {
                        DogPrice.GetLegend  = item.Value.ToString();
                        textBox5.Text = DogPrice.GetLegend;

                    }
                    else if (item.Name == "interval")
                    {
                        DogPrice.Getinterval = Convert .ToInt32 ( item.Value)*1000;
                        textBox6.Text = item.Value.ToString ();
                    }

                }

            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 加载百度cookie
        /// </summary>
        public void GetcookieTXT()
        {
            try
            {
                ///string papa = Application.StartupPath;
                XDocument document = XDocument.Load(papa + "\\Cookie.xml");
                //获取到XML的根元素进行操作
                XElement root = document.Root;
                XElement ele = root.Element("BDUSS");
                //获取name标签的值
                cookie = ele.Value.ToString();
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// 开始启动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            GetcookieTXT();
            GetConfigure();
            Dog.GetCookieva = cookie;
          //  dogImage();
            Getuser();
        }
        /// <summary>
        /// 开始刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_refresh_Click(object sender, EventArgs e)
        {
            isrunning = !isrunning;
            if (isrunning)
            {
                button_refresh.Text = "停止";
                timer1.Interval = DogPrice.Getinterval ;
                timer1.Start();
            }
            else
            {
                button_refresh.Text = "开始";
                timer1.Stop();
            }
        }
        /// <summary>  
        /// 将json数据转换成实体类     
        /// </summary>  
        /// <returns></returns>  
        private static List<Postdata.PetsOnSaleItem> getObjectByJson(string jsonString)
        {
            // 实例化DataContractJsonSerializer对象，需要待序列化的对象类型  
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Postdata.PetsOnSaleItem>));
            //把Json传入内存流中保存  
            jsonString = "[" + jsonString + "]";
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            // 使用ReadObject方法反序列化成对象  
            object ob = serializer.ReadObject(stream);
            List<Postdata.PetsOnSaleItem> ls = (List<Postdata.PetsOnSaleItem>)ob;
            return ls;
        }
        /// <summary>
        /// 判断价格是否比配置少
        /// </summary>
        /// <param name="rareDegree"></param>
        /// <param name="amount"></param>
        /// <param name="petid"></param>
        /// <param name="vcode"></param>
        public void GetContrast(string rareDegree,string amount,string petid,string vcode)
        {
            if (rareDegree.ToString ().Trim ()== "普通" && (Convert.ToDouble (DogPrice.Getcommon ) >= Convert.ToDouble(amount)))
            {
              textBox7.Text += rareDegree + ": " + amount + "\r\n";
              Putdogg(petid, amount, vcode,"","");
            }
            else if(rareDegree == "稀有" && (Convert.ToDouble(DogPrice.Getrare) >= Convert.ToDouble(amount)))
            {
                textBox7.Text += rareDegree + ": " + amount + "\r\n";
                Putdogg(petid, amount, vcode, "", "");
            }
            else if (rareDegree == "卓越" && (Convert.ToDouble(DogPrice.Getexcellence) >= Convert.ToDouble(amount)))
            {
                textBox7.Text += rareDegree + ": " + amount + "\r\n";
                Putdogg(petid, amount, vcode, "", "");
            }
            else if (rareDegree == "神话" && (Convert.ToDouble(DogPrice.Getmythical) >= Convert.ToDouble(amount)))
            {
                textBox7.Text += rareDegree + ": " + amount + "\r\n";
                Putdogg(petid, amount, vcode, "", "");
            }
            else if (rareDegree == "传说" && (Convert.ToDouble(DogPrice.GetLegend) >= Convert.ToDouble(amount)))
            {
                textBox7.Text += rareDegree + ": " + amount + "\r\n";
                Putdogg(petid, amount, vcode, "", "");
            }
        }
        /// <summary>
        /// 直接购买
        /// </summary>
        /// <param name="petid"></param>
        /// <param name="price_str"></param>
        /// <param name="vcode">validCode</param>
        /// <param name="seedaa"></param>
        /// <param name="chaaa"></param>
        public void Putdogg(string petid, string price_str,string vcode,string seed,string cha)
        {
            if (!string.IsNullOrEmpty(textBox9.Text))
            {
                string str = textBox9.Text;
                str= str.Replace("\r\n", "\n");
                string[] strArr = str.Split('\n');
                string[] temp1 = strArr[0].ToString().Split(',');
                seed = temp1[1].ToString();
                cha = temp1[0].ToString();
                string text = "";
                for (int i = 1; i < strArr.Length  ; i++)
                {
                    text += strArr[i] + (i == strArr.Length  - 1 ? "" : "\r\n"); //最后一行不添加换行符
                }
                textBox9.Text  = text;
            }
            ExtenModel.Getseedaa = seed;
            ExtenModel.Getchaaa = cha;
            ExtenModel.Getpetid = petid;
            ExtenModel.Getprice_str = price_str;
            ExtenModel.Getvcode = vcode;
            GetCodeForm getform = new GetCodeForm();
            getform.ShowDialog();
        }
        /// <summary>
        /// 获取排序规则
        /// </summary>
        /// <returns></returns>
        public string Getsort()
        {
            // RAREDEGREE_DESC 稀有度高 RAREDEGREE_ASC 稀有度低编码低 ，AMOUNT_ASC价格低， AMOUNT_DESC 价格高 CREATETIME_ASC
            string ret = "";
           string a= toolStripComboBox2.Text;
            if (a=="价格最低")
            {
                ret = "AMOUNT_ASC";
            }
            else if (a=="价格最高")
            {
                ret = "AMOUNT_DESC";
            }
            else if (a == "稀有度最低")
            {
                ret = "RAREDEGREE_ASC";
            }
            else if (a == "稀有度最高")
            {
                ret = "RAREDEGREE_DESC";
            }
            else if (a == "创建时间早")
            {
                ret = "CREATETIME_ASC";
            }
            else if (a == "创建时间晚")
            {
                ret = "CREATETIME_DESC";
            }
            return ret;
        }
        /// <summary>
        /// 根据界面配置获取价格
        /// </summary>
        public void GetDogpr()
        {
            string ret = "";
            string a = toolStripComboBox1.Text;
            if (a == "所有狗狗")
            {
                ret = "allprices";
            }
            else if (a == "普通")
            {
                ret = DogPrice.Getcommon;
            }
            else if (a == "稀有")
            {
                ret = DogPrice.Getrare ;
            }
            else if (a == "卓越")
            {
                ret = DogPrice.Getexcellence ;
            }
            else if (a == "史诗")
            {
                ret = DogPrice.Getepic;
            }
            else if (a == "神话")
            {
                ret = DogPrice.Getmythical;
            }
            else if (a == "传说")
            {
                ret = DogPrice.GetLegend;
            }
        }
        /// <summary>
        /// 实时刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetDog();
           
        }
        /// <summary>
        /// 单次请求
        /// </summary>
        public void GetDog()
        {
            string ret = "";
            try
            {
                ret = Dog.queryPetsOnSale("1", "20", Getsort());
                JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
                JArray res_ja = (JArray)res_j["data"]["petsOnSale"];
                JObject apet = (JObject)res_ja[0];
                string apettt = res_ja.ToString();
                var arry = JsonConvert.DeserializeObject<object[]>(apettt);
                Thread.Sleep(DogPrice.Getinterval);
                listView1.Items.Clear();
                textBox7.Text = "";
                string petid = (string)apet["petId"];
                string vcode = (string)apet["validCode"];
                string price_str = (string)apet["amount"];
                string birthType = Convert.ToString(apet["birthType"]);
                for (var i = 0; i < arry.Length; i++)
                {
                    List<AttributesItem> attri = new List<AttributesItem>();
                    StringBuilder DograreDegree = new StringBuilder();//稀有
                    StringBuilder DograreDegreep = new StringBuilder();//稀有
                    Postdata.PetsOnSaleItem PostOnSaleItem = (Postdata.PetsOnSaleItem)JsonConvert.DeserializeObject(arry[i].ToString(), typeof(Postdata.PetsOnSaleItem));
                    string petby=  Dog.queryPetById(PostOnSaleItem.petId);
                    JObject petby_j = (JObject)JsonConvert.DeserializeObject(petby);
                    string petby_ja = (string)petby_j["data"].ToString ();
                    AttributesData petby_OnSaleItem = (AttributesData)JsonConvert.DeserializeObject(petby_ja.ToString(), typeof(AttributesData));
                    for (int ia = 0; ia < petby_OnSaleItem.attributes.Count; ia++)
                    {
                        if (petby_OnSaleItem.attributes[ia].rareDegree=="稀有")
                        {
                            DograreDegree.Append(petby_OnSaleItem.attributes[ia].name +":"+ petby_OnSaleItem.attributes[ia].value+",  ");
                        }
                        else
                        {
                            DograreDegreep.Append(petby_OnSaleItem.attributes[ia].name + ":" + petby_OnSaleItem.attributes[ia].value + ",  ");
                        }

                    }
                    GetContrast(petby_OnSaleItem.rareDegree.ToString(), petby_OnSaleItem.amount.ToString(), petid, vcode);
                    this.listView1.BeginUpdate();
                    listView1.Items.Add(new ListViewItem(new string[] { petby_OnSaleItem.id.ToString(),
                        petby_OnSaleItem .amount.ToString(), petby_OnSaleItem .rareDegree.ToString(), petby_OnSaleItem .petId .ToString()
                        ,DograreDegree.ToString (),DograreDegreep.ToString (),PostOnSaleItem.validCode}));
                    this.listView1.EndUpdate();
                }

            }
            catch (Exception )
            {
            }
        }
        public string  dogImage()
        {
            string a = "";
            try
            {
                string ret = Dog.getCha();
                JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
                //MessageBox.Show(ret);
                newseed = (string)res_j["data"]["seed"];
                string img = (string)res_j["data"]["img"];
                puimg = img;
                a = newseed;
                pictureBox2.Image = Dog.str2Image(img);
            }
            catch (Exception) { }
            return a;
        }
        /// <summary>
        /// 回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_cha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && textBox_cha.Text.Length == 4)
            {
                try
                {
                    //推这次的参数上去
                   // cha = textBox_cha.Text.Trim();
                 //   seed = newseed;
                    dogImage();
                    //清空自己
                    textBox_cha.Clear();
                    label_chaused.ForeColor = Color.Green;
                    label_chaused.Text = "new cha";

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        public void Getuser()
        {
            string ret = Dog.showUser();
            JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
            //MessageBox.Show(ret);
            string u_name = (string)res_j["data"]["userName"];
            string u_amount = (string)res_j["data"]["amount"];
            toolStripTextBox1.Text = "微积分：" + u_amount;
            toolStripTextBox2.Text = "用户名：" + u_name;
        }
       /// <summary>
       /// 获取订单信息
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void button_getorderlist_Click(object sender, EventArgs e)
        {
            string ret = Dog.getMyOrder();
            JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
            JArray res_ja = (JArray)res_j["data"]["dataList"];
            textBox_orderlist.Clear();

            for (int i = 0; i < res_ja.Count; i++)
            {
                JObject apet = (JObject)res_ja[i];
                string amount = (string)apet["amount"];
                int status = (int)apet["status"];
                int txnstatus = (int)apet["txnStatus"];
                string strput = txnstatus == 1 ? "上链中...\r\n" : "" + (status == 1 ? ("+" + amount) : ("-" + amount)) + "\r\n";
                textBox_orderlist.AppendText(strput);
            }
        }
 
        public static string GetUrlsq(string a, string b)
        {
            string rolename = "";
            SQLiteConnection conn = null;
            try
            {
                string dbPath = "Data Source =" + papa + "\\laicigou.db";
                conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
                conn.Open();//打开数据库，若文件不存在会自动创建  
                string sql = "CREATE TABLE IF NOT EXISTS nameurl(id integer PRIMARY KEY AUTOINCREMENT , name varchar(250), url varchar(8000));";//建表语句  
                SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
                cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  
                                                 //  b = sqliteEscape(b);
                b = @b.ToString();
                SQLiteCommand cmdInsert = new SQLiteCommand(conn);
                cmdInsert.CommandText = @"INSERT INTO nameurl (name,url) VALUES( '" + (a) + "','" + (b) + "')";//插入几条数据  
                cmdInsert.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Gettxt(papa, DateTime.Now.ToString() + "  插入语句报错 " + e.Message.ToString() + "\r\n");
                //throw;
            }
            return rolename;
        }
        public static void Gettxt(string path, string content)
        {
            //  FileInfo fi = new FileInfo(filename);
            string aas = path + "\\" + DateTime.Parse(DateTime.Now.ToString()).ToString("yyyy-MM-dd") + ".txt";
            FileStream fsa = new FileStream(aas, FileMode.Append);
            StreamWriter swa = new StreamWriter(fsa);
            swa.WriteLine(content);
            swa.Flush();
            swa.Close();
            fsa.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //推这次的参数上去
                cha = textBox_cha.Text.Trim();
                seed = newseed;
                //拿下次的码&显示，seed存newseed   
                string ret = "";
                if (checkBox1.Checked == true)
                {
                    ret = Dog.getgift(seed, cha, "", Convert.ToInt32(comboBox1.Text), comboBox2.Text);
                }
                else
                {
                    ret = Dog.getgift(seed, cha, "4bdc93d315ace017", Convert.ToInt32(comboBox1.Text), comboBox2.Text);

                }
                JObject res_j = (JObject)JsonConvert.DeserializeObject(ret);
                //MessageBox.Show(ret); {{  "errorNo": "20005",  "errorMsg": "狗狗正在生产中,请稍后再领",  "timestamp": "2018-02-25 13:11:44",  "data": null}}
                string data = (string)res_j["data"];
                if (string.IsNullOrEmpty(data))
                {
                    string errorNo = (string)res_j["errorNo"];
                    string errorMsg = (string)res_j["errorMsg"];
                    label_chaused.Text = errorNo + errorMsg;
                    if (errorNo != "100")
                    {
                        GetUrlsq(cha, puimg);
                    }

                }
                else
                {
                    MessageBox.Show(ret.ToString());
                }
                dogImage();

                //清空自己
                textBox_cha.Clear();
                //  label_chaused.Text = "new cha";
                label_chaused.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

        }
        private void textBox_cha_TextChanged(object sender, EventArgs e)
        {
            if (textBox_cha.Text.Length == 4 && checkBox1.Checked == true)
            {
                button1_Click(null, null);
            }
        }
        public string StartOCR(Image numImage)
        {
            string txt = "";
            string defaultList = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string language = "eng";

            //Nuget安装的Tessract版本为3.02，tessdata的版本必须与其匹配，另外路径最后必须以"\"或者"/"结尾
           // const string TessractData = @"K:\Working\百度莱茨狗\1.1\laicigoujiaoyi\bin\Debug\";
            const string TessractData = @"K:\Working\百度莱茨狗\1.1\laicigoujiaoyi\bin\Debug\";

            Tesseract.TesseractEngine test = new Tesseract.TesseractEngine(TessractData, language);

            test.SetVariable("tessedit_char_whitelist", defaultList);

            Bitmap tmpVal = (Bitmap)numImage;
            Page tmpPage = test.Process(tmpVal, pageSegMode: test.DefaultPageSegMode);

            txt = tmpPage.GetText();


            return txt;
        }
        private void 获取CookieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCookie getcoo = new GetCookie();
            getcoo.Show();
        }
        private void 开始查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isrunning = !isrunning;
            if (isrunning)
            {
              
                开始查询ToolStripMenuItem.Text = "停止抢狗模式";
                timer1.Interval = 1000;
                timer1.Start();
            }
            else
            {
                开始查询ToolStripMenuItem.Text = "开始抢狗模式";
                timer1.Stop();
            }
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        public void Saveconfiguration()
        {
            try
            {
                //获取根节点对象
                XDocument document = new XDocument();
                XElement root = new XElement("Cookie");
                //  XElement book = new XElement("BOOK");
                root.SetElementValue("common", textBox1.Text);
                root.SetElementValue("rare", textBox2.Text);
                root.SetElementValue("excellence", textBox3.Text);
                root.SetElementValue("epic", textBox4.Text);
                root.SetElementValue("mythical", textBox5.Text);
                root.SetElementValue("Legend", textBox10.Text);
                root.SetElementValue("interval", textBox6.Text);
                root.Save(papa + "\\Configure.xml");

            }
            catch (Exception)
            {
                MessageBox.Show("保存错误");

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Saveconfiguration();
            GetConfigure();
            MessageBox.Show("保存成功");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button_refresh_Click(null,null);
        }
        private void button5_Click(object sender, EventArgs e)
        {
           Dog. queryPetById("1922974231292584223");
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetDog();
        }
        List<string> GetCode = new List<string>();
        int CodeNum = 0;
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8  .Text.Length == 4 && checkBox3.Checked == true)
            {
                GetCode.Add(textBox8.Text+","+newseed );

                textBox9.Text +=( textBox8.Text.ToString ().Trim () + "," + newseed.ToString ().Trim ()+"\r\n");
                CodeNum ++;
                dogImage();
                textBox8.Text = "";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
                GetCodeForm aa = new GetCodeForm();
            aa.ShowDialog();
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            textBox9.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem myItem = new ListViewItem();
                myItem = listView1.SelectedItems[0];//获取选中行  
                ExtenModel.Getpetid = myItem.SubItems[3].Text;
                ExtenModel.Getprice_str = myItem.SubItems[1].Text;
                ExtenModel.Getvcode = myItem.SubItems[6].Text;

            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Dog.buyPet(listpet, listvcode, listprice,"","");
            Putdogg(ExtenModel.Getpetid, ExtenModel.Getprice_str, ExtenModel.Getvcode,"","");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                dogImage();
            }
        }
    }
}
