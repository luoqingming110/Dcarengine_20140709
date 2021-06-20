using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace mode
{
    public partial class mode : Form
    {
        public mode()
        {
            InitializeComponent();
        }

        private void ami_TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ami_Button_11_Click(object sender, EventArgs e)
        {
            string  value    =this.input.Text.Trim();
            string ecuVersion = this.ecubox.Text.Trim();
            string mode = this.modebox.Text.Trim();
            string  result =  Dcarengine.Function_Class.Tp_KeyMethodFuntion.Con(value,ecuVersion,mode);

            this.emi_RichTextBox1.Text = result;

        }
    }
}
