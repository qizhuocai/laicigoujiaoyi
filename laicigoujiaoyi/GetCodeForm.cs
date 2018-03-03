using laicigoujiaoyi.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace laicigoujiaoyi
{
    public partial class GetCodeForm : Form
    {
        public GetCodeForm()
        {
            InitializeComponent();
        }
        bool Cvod=true ;
        static string seeda;
        static string cha;
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string newret = Dog.buyPet(ExtenModel.Getpetid, ExtenModel.Getvcode, ExtenModel.Getprice_str, seeda, cha);
                string msg = newret.Split(new char[1] { '"' })[7];
                //{"errorNo":"00","errorMsg":"success","timestamp":"2018-03-03 09:17:36","data":1922966431631804975}
                JObject res_j = (JObject)JsonConvert.DeserializeObject(newret);
                string  res_ja = (string)res_j["errorNo"];
                string res_errorMsg = (string)res_j["errorMsg"];

                if (res_ja=="100")
                {
                    Getcvode();
                }
                else
                {
                    MessageBox.Show(msg.ToString());
                    this.Close();
                }
              
            }
            textBox1.Text = "";
        }
        private void GetCodeForm_Load(object sender, EventArgs e)
        {
            if (Cvod)
            {

                if (!string.IsNullOrEmpty(ExtenModel.Getseedaa))
                {
                    seeda = ExtenModel.Getseedaa;
                    cha = ExtenModel.Getchaaa;
                    textBox1.Text = cha;
                }
                else
                {
                    Getcvode();
                    //cha = textBox1.Text;
                } 
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 4)
            {
                cha = textBox1.Text;
                button2_Click(null, null);
            }
        }
        public void Getcvode()
        {
            Cvod = false;
            List<string> newcond = Extension.dogImage();
            pictureBox2.Image = Dog.str2Image(newcond[1]);
            seeda = newcond[0];
          //  cha = textBox1.Text;
        }
    }
}
