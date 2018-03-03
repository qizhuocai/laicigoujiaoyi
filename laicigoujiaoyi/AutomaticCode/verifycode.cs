using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
namespace laicigoujiaoyi
{
    class verifycode
    {
        public void xianshi(string zimo)
        {
            var data = zimo.Select(x => x == '1').Concat(Enumerable.Repeat(false, 256))

        .Take(256).ToArray();

          //  Graphics g = pictureBox1.CreateGraphics();



            for (int i = 0; i < 16; i++)

            {

                for (int j = 0; j < 16; j++)

                {

                    Brush brush = data[j * 16 + i] ? Brushes.Blue : Brushes.White;

                   // g.FillRectangle(brush, new Rectangle() { X = i * 16, Y = j * 16, Width = 16, Height = 16 });

                }

            }
        }
    }
}