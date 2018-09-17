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
using System.Threading;
using UserLogin.Forms;

namespace UserLogin
{
    public delegate void UpDateUI();
    public partial class MaterialManagement : Form
    {
        private string tempport;
        private int portnum;
        private static byte fComAdr = 0xff;//当前操作的地址
        private byte fBaud;
        private int frmcomportindex;
        public bool hasopen;
        private int fCmdRet = 30;//所有执行命令的返回值
        private string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）

        public static string userPower;

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";

        public static MaterialManagement materialManagement;

        public MaterialManagement()
        {
            materialManagement = this;
            InitializeComponent();
        }

        private void MaterialManagement_Load(object sender, EventArgs e)
        {
            OpenPort();
            //WriteReaderAddress();
            //SetWorkModelParamter();
            //SetWorkModus();

            Thread thread1 = new Thread(WriteReaderAddress);
            thread1.IsBackground = true;
            thread1.Start();

            Thread thread2 = new Thread(SetWorkModelParamter);
            thread2.IsBackground = true;
            thread2.Start();

            Thread thread3 = new Thread(SetWorkModus);
            thread3.IsBackground = true;
            thread3.Start();

        }

        private void 物品查询ToolStripMenuItem_Click(object sender, EventArgs e)
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
                        dataGridView1.DataSource = materialInfoList;
                        r.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 打开指定的端口
        /// </summary>
        public bool OpenPort()
        {
            int openresult;
            tempport = UHFReaderConfigurations.UHFReader.COM.Trim();
            portnum = Convert.ToInt32(tempport.Substring(3, tempport.Length - 3));
            fComAdr = Convert.ToByte("FF", 16);
            frmcomportindex = portnum;
            for (int i = 6; i >= 0; i--)
            {
                fBaud = Convert.ToByte(i);
                if (fBaud == 3)
                    continue;
                frmcomportindex = portnum;
                openresult = UHFReader18CSharp.OpenComPort(portnum, ref fComAdr, fBaud, ref frmcomportindex);
                if (openresult == 0)
                {
                    MessageBox.Show("串口打开成功");
                    hasopen = true;
                    break;
                }
            }
            return hasopen;
        }

        /// <summary>
        /// 写入读写器地址 设置读写器功率
        /// </summary>
        public void WriteReaderAddress()
        {
            try
            {
                int a;//记录读写器地址写入返回值            
                int b;//记录读写器功率设置返回值
                int c;//记录读写器工作频率设置返回值
                int d;//记录读写器串口波特率设置返回值
                int e;//记录读写器询查命令最大响应时间设置返回值
                byte newComAdr;
                byte powerDbm;
                byte scantime;
                byte dminfre;
                byte dmaxfre;
                byte band = 0;
                int dminIndex = 0;
                int dmaxIndex = 62;
                string address = UHFReaderConfigurations.UHFReader.Address.Trim();
                newComAdr = Convert.ToByte(address);
                int power = Convert.ToInt32(UHFReaderConfigurations.UHFReader.Power.Trim());
                int tempTime = Convert.ToInt32(UHFReaderConfigurations.UHFReader.MaximumResponseTime);
                int innquirtTime = tempTime / 100;
                scantime = Convert.ToByte(innquirtTime);
                powerDbm = Convert.ToByte(power);
                dminfre = Convert.ToByte(((band & 3) << 6) | (dminIndex & 0x3F));
                dmaxfre = Convert.ToByte(((band & 0x0c) << 4) | (dmaxIndex & 0x3F));
                if (hasopen)
                {
                    a = UHFReader18CSharp.WriteComAdr(ref fComAdr, ref newComAdr, frmcomportindex);
                    if (a == 0)
                    {
                        MessageBox.Show("读写器地址写入成功");
                    }
                    b = UHFReader18CSharp.SetPowerDbm(ref fComAdr, powerDbm, frmcomportindex);
                    if (b == 0)
                    {
                        MessageBox.Show("功率设置成功");
                    }
                    c = UHFReader18CSharp.Writedfre(ref fComAdr, ref dmaxfre, ref dminfre, frmcomportindex);
                    if (c == 0)
                    {
                        MessageBox.Show("读写器工作频率设置成功");
                    }
                    d = UHFReader18CSharp.Writebaud(ref fComAdr, ref fBaud, frmcomportindex);
                    if (d == 0)
                    {
                        MessageBox.Show("波特率设置成功");
                    }
                    e = UHFReader18CSharp.WriteScanTime(ref fComAdr, ref scantime, frmcomportindex);
                    if (e == 0)
                    {
                        MessageBox.Show("询查命令最大响应时间设置成功");
                    }
                }
            }
            catch (Exception)
            {

            }
                    
        }

        /// <summary>
        /// 设置工作模式参数
        /// </summary>
        public void SetWorkModelParamter()
        {
            byte Wg_mode = 0;
            byte Wg_Data_Inteval;
            byte Wg_Pulse_Width;
            byte Wg_Pulse_Inteval;
            try
            {
                if (hasopen)
                {
                    string wiegandOupt = UHFReaderConfigurations.UHFReader.WiegandOutputMode.Trim();
                    string wiegand = UHFReaderConfigurations.UHFReader.Wiegand.Trim();
                    string dataOutputInterval = UHFReaderConfigurations.UHFReader.DataOutputInterval.Trim();
                    string pulseInterval = UHFReaderConfigurations.UHFReader.PulseInterval;
                    string pulseWidth = UHFReaderConfigurations.UHFReader.PulseWidth;
                    int data_Inteval = Convert.ToInt32(dataOutputInterval);
                    int pulse_Width = Convert.ToInt32(pulseWidth);
                    int pulse_Inteval = Convert.ToInt32(pulseInterval);
                    int dataIntervalIndex = 30;
                    int pulseIntervalIndex = 15;
                    int pulseWidthIndex = 10;
                    if (wiegand == "韦根26" && wiegandOupt == "韦根输出低字节在前")
                    {
                        Wg_mode = 2;
                    }
                    else
                    {
                        Wg_mode = 0;
                    }
                    if (wiegand == "韦根34" && wiegandOupt == "韦根输出低字节在前")
                    {
                        Wg_mode = 3;
                    }
                    else
                    {
                        Wg_mode = 1;
                    }
                    Wg_Data_Inteval = Convert.ToByte(dataIntervalIndex);
                    Wg_Pulse_Inteval = Convert.ToByte(pulseIntervalIndex);
                    Wg_Pulse_Width = Convert.ToByte(pulseWidthIndex);
                    int d = UHFReader18CSharp.SetWGParameter(ref fComAdr, Wg_mode, Wg_Data_Inteval, Wg_Pulse_Width, Wg_Pulse_Inteval, frmcomportindex);
                    if (d == 0)
                    {
                        MessageBox.Show("韦根参数设置成功");
                    }
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
        }

        /// <summary>
        /// 设置工作模式为应答模式
        /// </summary>
        public void SetWorkModus()
        {
            try
            {
                if (hasopen)
                {
                    byte[] parameter = new byte[6];
                    parameter[0] = Convert.ToByte(0);
                    int e = UHFReader18CSharp.SetWorkMode(ref fComAdr, parameter, frmcomportindex);
                    if (e == 0)
                    {
                        MessageBox.Show("应答模式设置成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
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

        private void 物品录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult=  MessageBox.Show("物品是否是第一次入库?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult ==DialogResult.Yes)
            {
                StorageMaterials storageMaterials = new StorageMaterials();
                StorageMaterials.storageMaterials.Show();
            }
            else
            {
                PutInMaterials putInMaterials = new PutInMaterials();
                PutInMaterials.put.Show();
            }
        }

        private void 取物品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeMatelrials takeMatelrials = new TakeMatelrials();
            TakeMatelrials.takeMatelrials.Show();
        }

        private void Timer_Test_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabelTime.Text = DateTime.Now.ToString();
        }
      
        private void 物品删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            try
            {
                if (dataGridView1.SelectedRows != null)
                {
                    DialogResult dialogResult = MessageBox.Show("是否删除物品" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (userPower == "管理员")
                        {
                            using (SqlConnection conn = new SqlConnection(conStr))
                            {
                                conn.Open();
                                using (SqlCommand cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = "delete from tb_material where materialId='" + dataGridView1.SelectedRows[0].Cells[0].Value + "'";
                                    cmd.ExecuteNonQuery();
                                }
                                UpDateUI upDateUI = new UpDateUI(UpdateDataGrid);
                                upDateUI.Invoke();
                            }
                        }
                        else
                        {
                            MessageBox.Show("您没有权限删除物品!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }               
            }
            catch 
            {

            }
           
        }

        /// <summary>
        /// 更新DataGridView
        /// </summary>
        public void UpdateDataGrid()
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
                        dataGridView1.DataSource = materialInfoList;
                        r.Close();
                    }
                }
            }
        }

        private void 记录查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryRecords queryRecords = new QueryRecords();
            QueryRecords.queryRecords.Show();          
        }

        private void 修改标签号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditEPCInfo editEPCInfo = new EditEPCInfo();
            EditEPCInfo.editEPCInfo.Show();
        }
    }
}
