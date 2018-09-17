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
using System.Text.RegularExpressions;

namespace UserLogin.Forms
{
    public partial class UserRegister : Form
    {
        public static UserRegister userRegister;

        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        //用户名是否被注册
        public bool hasRegisted = false;
        //输入的用户名是否合理
        public bool reasonable;
        //用户权限
        public string userpower;
        public UserRegister()
        {
            userRegister = this;
            InitializeComponent();
        }

        /// <summary>
        /// 注册新用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddUser_Click(object sender, EventArgs e)
        {
            //用于匹配用户输入是否正确的正则表达式
            string username = txtRegistUser.Text.Trim();
            string patt = @"^[\u4e00-\u9af5]+$";
            Regex regex = new Regex(patt);
            reasonable = regex.IsMatch(username);
            try
            {
                if (txtUserPwd.Text == "" || txtUserPwd.Text == "")
                {
                    MessageBox.Show("用户名或密码不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    using(SqlConnection conn=new SqlConnection(conStr))
                    {
                        conn.Open();
                        using(SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "select UserName from tb_user";
                            using(SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    if (txtRegistUser.Text == r["UserName"].ToString())
                                    {
                                        MessageBox.Show("用户名已被注册!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        hasRegisted = true;
                                        break;
                                    }
                                }
                            }
                        }

                    }
                }
                if (!hasRegisted&&!reasonable)
                {
                    MessageBox.Show("用户名只能为汉字!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!hasRegisted&&txtConfirmPwd.Text==txtUserPwd.Text)
                {             
                    if (radioButton1.Checked == true)
                    {
                        userpower = radioButton1.Text;
                    }
                    if (radioButton2.Checked == true)
                    {
                        userpower = radioButton2.Text;
                    }
                    using (SqlConnection conn=new SqlConnection(conStr))
                    {
                        conn.Open();
                        using(SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into tb_user(UserName,UserPwd,UserPower) values('" + txtRegistUser.Text + "','" + txtUserPwd.Text + "','" + userpower + "')";
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("注册成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
