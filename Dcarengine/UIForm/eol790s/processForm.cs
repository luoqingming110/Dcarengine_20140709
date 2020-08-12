using EASkins;
using EASkins.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dcarengine.UIForm.eol790s
{
    public partial class 写入进度 : EASkins.Controls.MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;

        public 写入进度(BackgroundWorker bgWork)
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey200, Primary.BlueGrey200, Primary.BlueGrey200,
            Accent.Blue200, TextShade.BLACK);

            this.backgroundWorker1 = bgWork;
            //绑定进度条改变事件
            this.backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            //绑定后台操作完成，取消，异常时的事件
            this.backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);

        }


        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;  //获取异步任务的进度百分比
            this.ami_Label1.Text = e.ProgressPercentage + "";
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();  //执行完之后，直接关闭页面
        }


        private void ami_Button_21_Click(object sender, EventArgs e)
        {
            this.backgroundWorker1.CancelAsync(); //请求取消挂起的后台操作
            this.Close();
        }


    }
}
