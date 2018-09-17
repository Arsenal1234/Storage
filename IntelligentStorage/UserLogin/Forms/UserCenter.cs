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
using UserLogin.Forms;
using System.Threading;

namespace UserLogin
{
    public partial class UserCenter : Form
    {
        public delegate void UpdateGrid();
        public static UserCenter userCenter;
        /// <summary>
        /// 连接数据库的字符串
        /// </summary>
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        //定义登录时间字符串
        public string Logintime;
        public static string userPower;

        public UserCenter()
        {
            userCenter = this;
            InitializeComponent();
        }

        public string GetLoginTime()
        {
            using(SqlConnection conn=new SqlConnection(conStr))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select LoginTime from tb_user where UserName='" + UserLogin.username + "'";
                    using(SqlDataReader r = cmd.ExecuteReader())
                    {
                        r.Read();
                        if (r.HasRows)
                        {
                            this.Logintime = r["LoginTime"].ToString();
                        }
                        r.Close();
                        return this.Logintime;
                    }
                }
            }
            
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 注册用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRegister userRegister = new UserRegister();
            UserRegister.userRegister.Show();
        }

        /// <summary>
        /// 显示全部用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 显示用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<UserManager> users = new List<UserManager>();
            using(SqlConnection conn=new SqlConnection(conStr))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select UserId,UserName,LoginTime,UserPower from tb_user";
                    using(SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            UserManager userManager = new UserManager();
                            userManager.用户ID = Convert.ToInt32(r["UserId"]);
                            userManager.用户姓名 = r["UserName"].ToString();
                            userManager.登录时间 = r["LoginTime"].ToString();
                            userManager.用户权限 = r["UserPower"].ToString();
                            users.Add(userManager);
                        }
                        dataGridView1.DataSource = users;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        r.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 显示用户权限
        /// </summary>
        private string ShowUserPower()
        {
            using(SqlConnection conn=new SqlConnection(conStr))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select UserPower from tb_user where UserName='" + UserLogin.username + "'";
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        toolStripStatusLabelPower.Text = reader["UserPower"].ToString();
                        userPower = toolStripStatusLabelPower.Text;
                    }
                    return userPower;
                }
            }
        }


        private void UserCenter_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = UserLogin.username;
            toolStripStatusLabel4.Text = GetLoginTime();
            ShowUserPower();
        }

        private void 物品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaterialManagement materialManagement = new MaterialManagement();
            MaterialManagement.userPower = ShowUserPower();
            MaterialManagement.materialManagement.Show();
            //MaterialManagement.materialManagement.StartPosition = FormStartPosition.CenterScreen;
            materialManagement.StartPosition = FormStartPosition.CenterScreen;
        }

        private void 删除用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows != null)
                {
                    DialogResult dialogResult = MessageBox.Show("是否删除用户" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (dataGridView1.SelectedRows[0].Cells[3].Value.ToString() == "管理员")
                        {
                            MessageBox.Show("无法删除管理员!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {

                            Sqloperate sqloperate = new Sqloperate();
                            //sqloperate.SqlCommands("delete from tb_user where UserName='" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "' and where UserPwd='"+dataGridView1.SelectedRows[0].Cells[1].Value.ToString()+"' and where LoginTime='"+dataGridView1.SelectedRows[0].Cells[2].Value.ToString()+"' and where UserPower='"+dataGridView1.SelectedRows[0].Cells[3].Value.ToString()+"'");
                            sqloperate.SqlCommands("delete from tb_user where UserId='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'");                           
                            UpdateGrid ug = new UpdateGrid(UpDateGridView);
                            ug.Invoke();
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 更新DataGridView
        /// </summary>
        public void UpDateGridView()
        {
            List<UserManager> users = new List<UserManager>();
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select UserId,UserName,LoginTime,UserPower from tb_user";
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            UserManager userManager = new UserManager();
                            userManager.用户ID = Convert.ToInt32(r["UserId"]);
                            userManager.用户姓名 = r["UserName"].ToString();
                            userManager.登录时间 = r["LoginTime"].ToString();
                            userManager.用户权限 = r["UserPower"].ToString();
                            users.Add(userManager);
                        }
                        dataGridView1.DataSource = users;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        r.Close();
                    }
                }
            }
        }

        private void 用户注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            UserLogin userLogin = new UserLogin();
            userLogin.Show();
        }

        private void timerTimeShow_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabelTime.Text = DateTime.Now.ToString();
        }
    }
}
