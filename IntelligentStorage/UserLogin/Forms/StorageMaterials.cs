using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserLogin;
using System.Data.SqlClient;

namespace UserLogin
{
    public partial class StorageMaterials : Form
    {
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        public static StorageMaterials storageMaterials;
        private int fCmdRet = 30;//所有执行命令的返回值
        public string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex = 4;
        private byte fComAdr = 0xff;//当前操作的地址
        //RFID是否被注册
        public bool hasRegisted;

        public StorageMaterials()
        {
            storageMaterials = this;
            InitializeComponent();
        }

        /// <summary>
        /// 询查标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Scan_Click(object sender, EventArgs e)
        {
            Inquiry();
        }

        /// <summary>
        /// 询查标签
        /// </summary>
        public void Inquiry()
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
                string[] newArray = SplitArry(fInventory_EPC_List);
                for (int i = 0; i < newArray.Length; i++)
                {
                    text_Rfid.Items.Add(newArray[i]);
                }
                //text_Rfid.Text = fInventory_EPC_List;
            }
        }

        /// <summary>
        /// 分割标签号
        /// </summary>
        /// <returns></returns>
        public string[] SplitArry(string textrfid)
        {
            string[] a1 = new string[textrfid.Length / 6];
            for (int i = 0; i < textrfid.Length/6; i++)
            {
                a1[i] = textrfid.Substring(i * 6, 6);
            }
            string a2 = string.Join(" ", a1);
            string[] a3 = a2.Split(' ');
            return a3;
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

        /// <summary>
        /// 存入物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_SaveIn_Click(object sender, EventArgs e)
        {
            string currentUserName = UserLogin.username;
            string userBehaviour = "存入";
            if (text_Rfid.Text == "")
            {
                MessageBox.Show("标签号不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
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
                                if (text_Rfid.Text == r["materialRfid"].ToString())
                                {
                                    MessageBox.Show("标签号已被注册!请重新修改标签号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    hasRegisted = true;
                                    break;
                                }
                                else
                                {
                                    hasRegisted = false;
                                }

                            }
                        }
                    }
                }
            }

                if (!hasRegisted&&text_Rfid.Text!="")
                {
                    using(SqlConnection conn1=new SqlConnection(conStr))
                    {
                       conn1.Open();
                       using(SqlCommand cmd1 = conn1.CreateCommand())
                       {
                          cmd1.CommandText = "insert into tb_InquiryRecords(UserName,UserBehaviour,MaterialName,MaterialCounts,Time) values('" + currentUserName + "','" + userBehaviour + "','" + text_MaterialName.Text + "','" + text_MaterialNum.Text + "','" + DateTime.Now.ToString() + "')";
                          cmd1.ExecuteNonQuery();
                       }
                    }

                    using (SqlConnection conn=new SqlConnection(conStr))
                    {
                        conn.Open();
                        using(SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into tb_material (materialRfid,materialPos,materialName,materialQuantity) values ('" + text_Rfid.Text + "','" + text_SavePos.Text + "','" + text_MaterialName.Text + "','" + text_MaterialNum.Text + "')";
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("存放成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }                     
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            MaterialManagement materialManagement = new MaterialManagement();
            MaterialManagement.materialManagement.Show();
        }

        /// <summary>
        /// 写EPC号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonWrite_EPC_Click(object sender, EventArgs e)
        {
            //EditEPCInfo editEPCInfo = new EditEPCInfo();
            //EditEPCInfo.editEPCInfo.Show();
        }

        private void StorageMaterials_Load(object sender, EventArgs e)
        {
            this.text_Rfid.Items.Clear();
        }

        private void text_Rfid_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.text_SavePos.Text = "";
            this.text_MaterialName.Text = "";
            this.text_MaterialNum.Text = "";
        }
    }
}
