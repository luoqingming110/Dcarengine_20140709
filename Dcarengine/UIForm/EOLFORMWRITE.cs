using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Dcarengine.Function_Class;
using Dcarengine.UIForm.EOL;

namespace Dcarengine.UIForm
{
    public partial class EOLFORMWRITE : Form
    {
        public EOLFORMWRITE()
        {
            InitializeComponent();
        }

        private void EOLFORMWRITE_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            EolFunction.writeFunction(null,10,"10");
            
         

        }

        private void button2_Click(object sender, EventArgs e)
        {

            EolFunction.readFunction(null, 10);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Controls.Clear();      
            Form1 allTrip = new Form1();
            allTrip.TopLevel = false;
            //allTrip.FormBorderStyle = FormBorderStyle.None;
            allTrip.Parent = this.splitContainer1.Panel2;
            this.splitContainer1.Panel2.Controls.Add(allTrip); //add the fs form to the panel2
            allTrip.Dock = DockStyle.Fill;
            allTrip.Show();    
        }




    }
}
