using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string path = @"C:\Users\Зажравшийся Буржуй\Desktop\words1.txt";
        static int width = 4;
        static int height1 = 0;
        List<Tor> ListBay = Tor.ReadArray(path);

        private void Form1_Load_1(object sender, EventArgs e)
        {
            dataGridView1.RowHeadersWidth = 50;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnCount = width;
            dataGridView1.RowCount = ListBay.Capacity;
            label1.Text = "Общее кол-во " + Convert.ToString(ListBay.Capacity);
            for (int j = 0; j <= ListBay.Capacity - 1; ++j)
            {
                dataGridView1[0, j].Value = ListBay[j].x1;
                dataGridView1[1, j].Value = ListBay[j].x2;
                dataGridView1[2, j].Value = ListBay[j].y1;
                dataGridView1[3, j].Value = ListBay[j].y2;
            }
            List<Tor> ListAfter = Tor.ChoosingTriangles(ListBay, out height1);
            dataGridView2.RowHeadersWidth = 50;
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.ColumnHeadersHeight = 40;
            dataGridView2.ColumnCount = width;
            dataGridView2.RowCount = height1;
            label2.Text = "Кол-во непересекающихся " + Convert.ToString(height1);
            for (int j = 0; j <= ListBay.Capacity - 1; ++j)
            {
                dataGridView2[0, j].Value = ListAfter[j].x1;
                dataGridView2[1, j].Value = ListAfter[j].x2;
                dataGridView2[2, j].Value = ListAfter[j].y1;
                dataGridView2[3, j].Value = ListAfter[j].y2;
            }
        }
    }
}