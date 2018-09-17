
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

namespace UserLogin
{
    public partial class EditEPCInfo : Form
    {
        public static EditEPCInfo editEPCInfo;
        private int fCmdRet = 30;//所有执行命令的返回值
        private int ferrorcode;
        private int frmcomportindex = 4;
        private byte[] fPassWord = new byte[4];
        private byte fComAdr = 0xff;//当前操作的地址
        public string fInventory_EPC_List; //存贮询查列表（如果读取的数据没有变化，则不进行刷新）

        public EditEPCInfo()
        {
            editEPCInfo = this;
            InitializeComponent();
        }

        /// <summary>
        /// 字符串转字节数组
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string accessPwd = textBoxAceessCodes.Text.Trim();
                string writeEPCNum = textBoxWriteEPC.Text.Trim();
                byte[] WriteEPC = new byte[100];
                byte WriteEPCLen;
                byte ENum;
                if (accessPwd.Length < 8)
                {
                    MessageBox.Show("访问密码小于8位!请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((writeEPCNum.Length % 4) != 0)
                {
                    MessageBox.Show("请输入以字为单位的16进制数！'+#13+#10+'例如：1234、12345678!", "信息提示");
                    return;
                }
                WriteEPCLen = Convert.ToByte(writeEPCNum.Length / 2);
                ENum = Convert.ToByte(writeEPCNum.Length / 4);
                byte[] EPC = new byte[ENum];
                EPC = HexStringToByteArray(writeEPCNum);
                fPassWord = HexStringToByteArray(accessPwd);
                fCmdRet = UHFReader18CSharp.WriteEPC_G2(ref fComAdr, fPassWord, EPC, WriteEPCLen, ref ferrorcode, frmcomportindex);
                if (fCmdRet == 0)
                {
                    //int a = StorageMaterials.storageMaterials.text_Rfid.SelectedIndex;
                    //StorageMaterials.storageMaterials.text_Rfid.Items.RemoveAt(a);
                    //StorageMaterials.storageMaterials.text_Rfid.SelectedText = "";
                    //StorageMaterials.storageMaterials.text_Rfid.SelectedText = writeEPCNum;
                    this.curRfidText.Text = writeEPCNum;
                    MessageBox.Show("写入成功!");
                    this.Close();
                }
               
            }
            catch 
            {               
            }        
        }

        /// <summary>
        /// 扫描标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ScanRfid_Click(object sender, EventArgs e)
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
                curRfidText.Text = fInventory_EPC_List;
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




    }
}
