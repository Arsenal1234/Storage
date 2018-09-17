using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using AicUI.Desktop.Utilities;

namespace UserLogin
{
    public partial class UserLogin : Form
    {
        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        public static UserLogin userLoin;
        public static string username;
        public string userpwd;

        private System.Diagnostics.Process softKey;

        public UserLogin()
        {
            //this.WindowState = FormWindowState.Maximized;
            //ShowKey();
            InitializeComponent();
        }

        /// <summary>
        /// 密码登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passwordbtn_Click(object sender, EventArgs e)
        {       
            try
            {
                if (txtUserName.Text == "" || txtPassWord.Text == "")
                {
                    MessageBox.Show("用户名或密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    //输入用户名
                     username = txtUserName.Text.Trim();
                    //输入密码
                     userpwd = txtPassWord.Text.Trim();
                    //定义连接数据库的字符串
                    string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
                    SqlConnection conn = new SqlConnection(conStr);
                    conn.Open();
                    //创建数据库命令对象
                    SqlCommand command = new SqlCommand("select * from tb_user where UserName='" + username + "' and UserPwd='" + userpwd + "'",conn);
                    //创建数据库读取器对象
                    SqlDataReader reader = command.ExecuteReader();
                    //读取一条记录
                    reader.Read();
                    if (reader.HasRows)//判断是否包含数据
                    {
                        string time = DateTime.Now.ToString();
                        string sql = "update tb_user set LoginTime='" + time + "' where UserName='" + username + "'";
                        Sqloperate sqloperate = new Sqloperate();
                        sqloperate.SqlCommands(sql);
                        conn.Close();
                        this.Hide();
                        UserCenter userCenter = new UserCenter();
                        UserCenter.userCenter.Show();
                    }
                    else
                    {
                        txtUserName.Text = "";
                        txtPassWord.Text = "";
                        MessageBox.Show("用户名或密码错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 启用系统软键盘
        /// </summary>
        private void ShowKey()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("软件盘可执行文件不存在！");
                    return;
                }
                //if (!System.IO.File.Exists(Environment.CurrentDirectory + "\\osk.exe"))
                //{
                //    MessageBox.Show("软件盘可执行文件不存在！");
                //    return;
                //}

                softKey = System.Diagnostics.Process.Start("C:\\Windows\\System32\\osk.exe");

                //softKey = System.Diagnostics.Process.Start("D:\\项目资料\\IntelligentStorage\\UserLogin\\bin\\Debug\\osk.exe");            
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



    }
}
