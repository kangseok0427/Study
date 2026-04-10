using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int i = 0;
        public Form1()
        {
            InitializeComponent();

            myButton.Text = "InCode";
            myButton.Width = 600;
            
        }

        private void btn1_Clicked(object sender, EventArgs e)
        {
            maskedTextBox1.Text += "+";
            label1.Text += "+";

            Button btn = new Button();
            Controls.Add(btn);
            btn.Location = new Point(myButton.Location.X, myButton.Location.Y + (100 * (i + 1)));
            btn.Height = 100;
            btn.Width = 200;
            btn.Text = "btnNew" + (i + 1);
            btn.BackColor = Color.LightGreen;
            btn.Font = myButton.Font;
            i++;
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
