using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*DialogResult result;

            result = MessageBox.Show("내용", "제목", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes) MessageBox.Show("Yes를 클릭");
            else if (result == DialogResult.No) MessageBox.Show("No를 클릭");
            else if (result == DialogResult.Cancel) MessageBox.Show("Cancel을 클릭");*/

            Form2 child = new Form2();

            child.setTB(textBox1);
            child.SetMyTextBoxText("Form1에서 수정됨");
            child.ShowDialog();
            MessageBox.Show("Test");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
