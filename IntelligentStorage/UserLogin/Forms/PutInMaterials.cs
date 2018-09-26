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

namespace UserLogin.Forms
{
    public partial class PutInMaterials : Form
    {
        public static PutInMaterials put;
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        public static StorageMaterials storageMaterials;
        private int fCmdRet = 30;//所有执行命令的返回值
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）
        private int frmcomportindex = 4;
        private byte fComAdr = 0xff;//当前操作的地址

        public PutInMaterials()
        {
            put = this;
            InitializeComponent();
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
                textBoxRfid.Text = fInventory_EPC_List;
            }
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
        /// 扫描标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonScan_Click(object sender, EventArgs e)
        {
            Inquiry();
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand sql = new SqlCommand("select materialPos,materialName,materialQuantity from tb_material where materialRfid='" + textBoxRfid.Text + "'", conn);
            sda.SelectCommand = sql;
            DataSet dataSet = new DataSet();
            sda.Fill(dataSet);
            textBoxPos.Text = dataSet.Tables[0].Rows[0]["materialPos"].ToString();
            textBoxMaterialName.Text = dataSet.Tables[0].Rows[0]["materialName"].ToString();
            textBoxCounts.Text = dataSet.Tables[0].Rows[0]["materialQuantity"].ToString();
            dataSet.Dispose();
            conn.Close();
        }

        /// <summary>
        /// 归还物品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveIn_Click(object sender, EventArgs e)
        {
            string curUserName = UserLogin.username;
            string userAction = "归还";
            using(SqlConnection conn1=new SqlConnection(conStr))
            {
                conn1.Open();
                using(SqlCommand cmd1 = conn1.CreateCommand())
                {
                    int returnCounts = Convert.ToInt32(textBoxCounts.Text);
                    cmd1.CommandText = "insert into tb_InquiryRecords(UserName,UserBehaviour,MaterialName,MaterialCounts,Time,MaterialRfid) values('" + curUserName + "','" + userAction + "','" + textBoxMaterialName.Text + "','" + returnCounts + "','" + DateTime.Now.ToString() + "','"+textBoxRfid.Text+"')";
                    cmd1.ExecuteNonQuery();
                }
            }


            using(SqlConnection conn=new SqlConnection(conStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    int counts = Convert.ToInt32(textBoxCounts.Text);
                    cmd.CommandText = "update tb_material set materialQuantity=materialQuantity+'"+counts+ "' where materialName='"+textBoxMaterialName.Text+"'";
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("存放成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }     
    }
}
