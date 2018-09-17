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
using UserLogin;

namespace UserLogin
{
    public partial class TakeMatelrials : Form
    {
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        public static TakeMatelrials takeMatelrials;

        private int fCmdRet = 30;//所有执行命令的返回值
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex = 4;
        private byte fComAdr = 0xff;//当前操作的地址


        public TakeMatelrials()
        {
            takeMatelrials = this;
            InitializeComponent();
            FindMaterial();
        }

        /// <summary>
        /// 查找物品
        /// </summary>
        private void FindMaterial()
        {
            try
            {          
                    List<MaterialInfo> materialInfoList = new List<MaterialInfo>();
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "select * from tb_material";
                            using (SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    MaterialInfo materialInfo = new MaterialInfo();
                                    materialInfo.物品ID = Convert.ToInt32(r["materialId"]);
                                    materialInfo.物品标签 = r["materialRfid"].ToString();
                                    materialInfo.物品存放位置 = r["materialPos"].ToString();
                                    materialInfo.物品名称 = r["materialName"].ToString();
                                    materialInfo.库存余量 = Convert.ToInt32(r["materialQuantity"]);
                                    materialInfoList.Add(materialInfo);
                                }
                                dataGridView_Materlial.DataSource = materialInfoList;
                                r.Close();
                            }
                        }
                    }              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 查找要取出的物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Take_Click(object sender, EventArgs e)
        {
            try
            {
                if (textTakeName.Text == "")
                {
                    MessageBox.Show("请输入要查找的物品!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    string materialName = textTakeName.Text.Trim();
                    List<MaterialInfo> materialInfoList = new List<MaterialInfo>();
                    using (SqlConnection conn = new SqlConnection(conStr))
                    {
                        conn.Open();
                        using(SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "select * from tb_material where materialName='" + materialName + "'";
                            using(SqlDataReader r = cmd.ExecuteReader())
                            {
                                while (r.Read())
                                {
                                    MaterialInfo materialInfo = new MaterialInfo();
                                    materialInfo.物品ID = Convert.ToInt32(r["materialId"]);
                                    materialInfo.物品标签 = r["materialRfid"].ToString();
                                    materialInfo.物品存放位置 = r["materialPos"].ToString();
                                    materialInfo.物品名称 = r["materialName"].ToString();
                                    materialInfo.库存余量 = Convert.ToInt32(r["materialQuantity"]);
                                    materialInfoList.Add(materialInfo);
                                }
                                dataGridView_Materlial.DataSource = materialInfoList;
                                r.Close();
                            }
                            
                        }
                    }
                }
               
            }
            catch 
            {

            }
           
        }

        private void timer_TimeShow_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabelTime.Text = DateTime.Now.ToString();
        }

        /// <summary>
        /// 取出物品并扫描RFID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGetMaterials_Click(object sender, EventArgs e)
        {         
            //timerScanRFID.Tick += TimerScanRFID_Tick;
            UpDateDataGrid();
        }

        /// <summary>
        /// 扫描标签
        /// </summary>
        public string Inquiry()
        {
            int CardNum = 0;
            int Totallen = 0;
            byte[] EPC = new byte[5000];
            string temps;
            byte AdrTID = 0;
            byte LenTID = 0;
            byte TIDFlag = 0;
            bool TIDInquiry = false;
            if (TIDInquiry == true)
            {
                AdrTID = Convert.ToByte("0", 16);
                LenTID = Convert.ToByte("3", 16);
                TIDFlag = 1;
            }
            else
            {
                AdrTID = 0;
                LenTID = 0;
                TIDFlag = 0;
            }
            fCmdRet = UHFReader18CSharp.Inventory_G2(ref fComAdr, AdrTID, LenTID, TIDFlag, EPC, ref Totallen, ref CardNum, frmcomportindex);
            if (fCmdRet == 1 | (fCmdRet == 2) | (fCmdRet == 3) | (fCmdRet == 4) | (fCmdRet == 0xFB))//代表查找结束
            {
                byte[] daw = new byte[Totallen];
                Array.Copy(EPC, daw, Totallen);
                temps = ByteArrayToHexString(daw);
                fInventory_EPC_List = temps;//存储标签记录
            }
            return fInventory_EPC_List;
        }

        /// <summary>
        /// 字节数组转字符串
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
            return sb.ToString().ToUpper();
        }


        private void UpDateDataGrid()
        {
            List<MaterialInfo> materialInfoList = new List<MaterialInfo>();
            string curUserName = UserLogin.username;
            string userAction = "取出";
            using(SqlConnection conn1=new SqlConnection(conStr))
            {
                conn1.Open();
                using(SqlCommand cmd1 = conn1.CreateCommand())
                {
                    int takeCounts = Convert.ToInt32(textCounts.Text);
                    cmd1.CommandText = "insert into tb_InquiryRecords(UserName,UserBehaviour,MaterialName,MaterialCounts,Time) values('" + curUserName + "','" + userAction + "','" + textTakeName.Text + "','" + takeCounts + "','" + DateTime.Now.ToString() + "')";
                    cmd1.ExecuteNonQuery();
                }
            }

            using (SqlConnection conn=new SqlConnection(conStr))
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    string targetRfid = Inquiry();
                    string targetName = textTakeName.Text;
                    int counts = Convert.ToInt32(textCounts.Text);
                    cmd.CommandText = "update tb_material set materialQuantity=materialQuantity-'" + counts + "' where materialRfid='" + targetRfid + "'";
                    cmd.ExecuteNonQuery();
                    SqlCommand sqlCommand = new SqlCommand("select * from tb_material where materialName='" + targetName + "'",conn);
                    using (SqlDataReader r = sqlCommand.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            MaterialInfo materialInfo = new MaterialInfo();
                            materialInfo.物品ID = Convert.ToInt32(r["materialId"]);
                            materialInfo.物品标签 = r["materialRfid"].ToString();
                            materialInfo.物品存放位置 = r["materialPos"].ToString();
                            materialInfo.物品名称 = r["materialName"].ToString();
                            materialInfo.库存余量 = Convert.ToInt32(r["materialQuantity"]);
                            materialInfoList.Add(materialInfo);
                        }
                        dataGridView_Materlial.DataSource = materialInfoList;
                        r.Close();

                    }
                }
            }
        }

        public bool IfIsEmpty(string str1,string str2)
        {
            if (str1 != "" && str2 != "")
            {
                timerScanRFID.Enabled = true;
            }
            return timerScanRFID.Enabled;

        }



        /// <summary>
        /// 取走物品后点击可以显示物品剩余数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //UpDateDataGrid();
        }

        private void TakeMatelrials_Load(object sender, EventArgs e)
        {
            //timerScanRFID.Enabled = true;
        }

        private void timerScanRFID_Tick_1(object sender, EventArgs e)
        {
             UpDateDataGrid();         
        }

        private void textCounts_TextChanged(object sender, EventArgs e)
        {
            timerScanRFID.Enabled = true;
        }
    }
}
