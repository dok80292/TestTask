using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test_Task
{
    public partial class AddCottagerForm : Form
    {
        public AddCottagerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm main = this.Owner as MainForm;
            try
            {
                int number = Convert.ToInt32(textBox1.Text);
                double area = Convert.ToDouble(textBox2.Text);
                main.CottagerAdd(number, area);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
