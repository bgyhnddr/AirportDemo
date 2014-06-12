using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AirportDemo
{
    public partial class Form1 : Form
    {
        private BindingList<msg> list = new BindingList<msg>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var row = new msg();
            row.img = Image.FromFile("H:\\Airport\\AirportDemo\\icon1.png");
            row.Flight = "CZ3915";
            row.TOVIA = "海口";
            row.Counter = "52-53";
            row.STD = "11:30";
            row.Gate = "6";
            row.Remark = "正在办理CHECK-IN";

            var row2 = new msg();
            row2.img = Image.FromFile("H:\\Airport\\AirportDemo\\icon1.png");
            row2.Flight = "CZ1234";
            row2.TOVIA = "北京";
            row2.Counter = "52-53";
            row2.STD = "11:30";
            row2.Gate = "6";
            row2.Remark = "正在办理CHECK-IN";
            list.Add(row);
            list.Add(row2);
            dataGridView1.DataSource = list;
            
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Rectangle newRect = new Rectangle(e.CellBounds.X, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);              
                Brush backColorBrush = new SolidBrush(e.CellStyle.BackColor);//非选中的背景色
                e.Graphics.FillRectangle(backColorBrush, e.CellBounds);//用背景色填充单元格


                if (e.ColumnIndex == 0)
                {
                    ControlPaint.DrawBorder(e.Graphics, newRect,
                    Color.FromArgb(40, 40, 40), 0, ButtonBorderStyle.None,
                    Color.FromArgb(40, 40, 40), 10, ButtonBorderStyle.Solid,
                    Color.FromArgb(40, 40, 40), 0, ButtonBorderStyle.None,
                    Color.FromArgb(40, 40, 40), 0, ButtonBorderStyle.None);
                }

                else
                {
                    ControlPaint.DrawBorder(e.Graphics, newRect,
                        Color.FromArgb(40, 40, 40), 0, ButtonBorderStyle.None,
                        Color.FromArgb(40, 40, 40), 10, ButtonBorderStyle.Solid,
                        Color.FromArgb(40, 40, 40), 10, ButtonBorderStyle.Solid,
                        Color.FromArgb(40, 40, 40), 0, ButtonBorderStyle.None);
                }




                if (e.Value != null)
                {
                    if (e.ColumnIndex == 0)
                    {
                        newRect.Offset(100, 100);

                        Rectangle newRect2 = new Rectangle(0, 0, 100, 100);
                        e.PaintContent(newRect2);//画内容
                    }
                    e.PaintContent(newRect);//画内容
                }
                e.Handled = true;
            }
        }


       
    }

    public class msg
    {
        public Image img { get; set; }
        public string Flight { get; set; }
        public string TOVIA { get; set; }
        public string Counter { get; set; }
        public string STD { get; set; }
        public string Gate { get; set; }
        public string Remark { get; set; }
       
    }
}
