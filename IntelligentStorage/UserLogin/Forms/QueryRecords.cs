using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserLogin.Forms
{
    public partial class QueryRecords : Form
    {
        public static QueryRecords queryRecords;
        public string startTime;
        public string endTime;
        public static string userPower;

        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";

        public QueryRecords()
        {
            queryRecords = this;
            InitializeComponent();
            userPower = UserCenter.userPower;
        }

        /// <summary>
        /// 按时间查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_QueryTime_Click(object sender, EventArgs e)
        {
            startTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            endTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (userPower == "管理员")
            {
                List<Records> records = new List<Records>();
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from tb_InquiryRecords where Time between'"+startTime+"' and '"+endTime+"'";
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                Records re = new Records();
                                re.查询ID = Convert.ToInt32(r["InquireID"]);
                                re.用户姓名 = r["UserName"].ToString();
                                re.用户行为 = r["UserBehaviour"].ToString();
                                re.物品名称 = r["MaterialName"].ToString();
                                re.物品数量 = Convert.ToInt32(r["MaterialCounts"]);
                                re.时间 = r["Time"].ToString();
                                records.Add(re);
                            }
                            dataRecords.DataSource = records;
                            r.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("您没有权限查看记录,请联系管理员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_QueryAll_Click(object sender, EventArgs e)
        {
            if (userPower == "管理员")
            {
                List<Records> records = new List<Records>();
                using (SqlConnection conn = new SqlConnection(conStr))
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "select * from tb_InquiryRecords";
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                Records re = new Records();
                                re.查询ID = Convert.ToInt32(r["InquireID"]);
                                re.用户姓名 = r["UserName"].ToString();
                                re.用户行为 = r["UserBehaviour"].ToString();
                                re.物品名称 = r["MaterialName"].ToString();
                                re.物品数量 = Convert.ToInt32(r["MaterialCounts"]);
                                re.时间 = r["Time"].ToString();
                                re.标签号 = r["MaterialRfid"].ToString();
                                records.Add(re);
                            }
                            dataRecords.DataSource = records;
                            r.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("您没有权限查看记录,请联系管理员", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
