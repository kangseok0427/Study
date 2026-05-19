using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ProductSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductSource.Add(new Product { Name = "갈비탕", Price = 4000 });
            int i = 4000 + int.Parse(label2.Text);
            label2.Text = i.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductSource.Add(new Product { Name = "쪽갈비", Price = 7000 });
            int i = 7000 + int.Parse(label2.Text);
            label2.Text = i.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductSource.Add(new Product { Name = "삼겹살", Price = 2000 });
            int i = 2000 + int.Parse(label2.Text);
            label2.Text = i.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductSource.Add(new Product { Name = "음료", Price = 1500 });
            int i = 1500 + int.Parse(label2.Text);
            label2.Text = i.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;

            Product item = dataGridView1.Rows[index].DataBoundItem as Product;

            int i = int.Parse(label2.Text) - item.Price;
            label2.Text = i.ToString();

            dataGridView1.Rows.RemoveAt(index);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(int.Parse(label2.Text) + "원 결제 하시겠습니까?", "확인", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
                label2.Text = "0000";
            }
        }
    }
}
