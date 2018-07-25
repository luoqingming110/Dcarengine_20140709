using CCWin;
using Dcarengine.Function_Class;
using Dcarengine.refactor;
using Dcarengine.serialPort;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dcarengine.UIForm
{
    public partial class DebugForm : CCSkinMain
    {

        /// <summary>
        /// DebugShow
        /// </summary>
        /// <param name="DebugShow"></param>
        public delegate void MaifTextEdit(string MainfShow);

        private MaifTextEdit maifText;

        public DebugForm()
        {
            maifText = new MaifTextEdit(RichBoxTextShow);
            InitializeComponent();
        }

        private void DebugForm_Load(object sender, EventArgs e)
        {
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;　//设置ScrollBars属性实现只显示垂直滚动
            this.DoubleBuffered = true;//设置本窗体
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {

            CommonConstant.mode = "1085";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);


        }

        private void mode84_Click(object sender, EventArgs e)
        {

            if (EcuConnectionF.ECULINKStatus1 == false) {

                return;
            }
           //初始化数据值
            CommonConstant.mode = "1084";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);
        }

        private void mode81_Click(object sender, EventArgs e)
        {

            GobalSerialPort.WriteByMessage(DebugMode.startMode84, 0, DebugMode.startMode84.Length);      //22222/         


        }

        private void send_Click(object sender, EventArgs e)
        {
           
            String  sendText = this.skinChatRichTextBox2.Text.Trim();

            Byte[] sendCmd = StringToSendBytes.bytesToSend(sendText + "\n");

            GobalSerialPort.WriteByMessage(sendCmd,0,sendCmd.Length);

            String backString = GobalSerialPort.ResultBackString;

            //if (backString.Contains("10") && backString.Contains("78"))
            //{
            //    GobalSerialPort.WriteByMessage(CommonCmd.ATSTD6, 0, CommonCmd.ATSTD6.Length);

            //    GobalSerialPort.WriteByMessage(CommonCmd._830300D610140A, 0, CommonCmd._830300D610140A.Length);

            //    GobalSerialPort.WriteByMessage(CommonCmd.ATSW00, 0, CommonCmd.ATSW00.Length);
            //}
            //  backString = GobalSerialPort.ResultBackString;
            //释放
            this.richTextBox1.Invoke(maifText,backString);
            
            // this.skinChatRichTextBox1.Text = GobalSerialPort.ResultBackString;
        }

        private void clear_Click(object sender, EventArgs e)
        {

            this.skinChatRichTextBox2.Text = "";
        }

        public void RichBoxTextShow(String text) {

            if(!"".Equals(text) && text!=null){

               // String[] subtext = text.Split('\r');
                this.richTextBox1.AppendText("\n" + text);

            }
        }

        private void mode86_Click(object sender, EventArgs e)
        {


            CommonConstant.mode = "1086";

            Tp_KeyMethodFuntion.Con();

           // Tp_KeyMethodFuntion tp_s = new Tp_KeyMethodFuntion();
           // tp_s.ConThread();


            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);


        }

        private void mode87_Click(object sender, EventArgs e)
        {
            CommonConstant.mode = "1087";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);

        }

        private void mode90_Click(object sender, EventArgs e)
        {

            CommonConstant.mode = "1090";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);

        }

        private void mode91_Click(object sender, EventArgs e)
        {

            CommonConstant.mode = "1091";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);

        }

        private void mode92_Click(object sender, EventArgs e)
        {

            CommonConstant.mode = "1092";
            Tp_KeyMethodFuntion.Con();
            String backString = GobalSerialPort.ResultBackString;

           

            this.richTextBox1.Invoke(maifText, backString);

        }

        private void mode93_Click(object sender, EventArgs e)
        {
            CommonConstant.mode = "1093";

            Tp_KeyMethodFuntion.Con();

            String backString = GobalSerialPort.ResultBackString;

            this.richTextBox1.Invoke(maifText, backString);

        }
    }
}
