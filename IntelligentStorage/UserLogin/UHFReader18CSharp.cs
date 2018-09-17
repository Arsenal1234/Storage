using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace UserLogin
{
    public class UHFReader18CSharp
    {

        //自动连接串口
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int AutoOpenComPort(ref int Port, ref byte ComAddr, byte Baud, ref int PortHandle);

        //连接到指定串口
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int OpenComPort(int Port, ref byte ComAddr, byte Baud, ref int PortHandle);

        //关闭串口连接
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseComPort();

        //关闭指定串口
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int CloseSpecComPort(int Port);

        //获得读写器信息
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetReaderInformation(ref byte ConAddr, byte[] VersionInfo, ref byte ReaderType, byte[] TrType, ref byte dmaxfre, ref byte dminfre, ref byte powerdBm, ref byte ScanTime, int PortHandle);

        //写入读写器地址
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteComAdr(ref byte ConAddr, ref byte ComAdrData, int PortHandle);

        //设置询查命令最大响应时间
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteScanTime(ref byte ConAddr, ref byte ScanTime, int PortHandle);

        //设置读写器功率
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetPowerDbm(ref byte ConAddr, byte powerDbm, int PortHandle);

        //设置读写器工作频率
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Writedfre(ref byte ConAddr, ref byte dmaxfre, ref byte dminfre, int PortHandle);

        //设置串口波特率
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Writebaud(ref byte ConAddr, ref byte baud, int PortHandle);

        //设置韦根参数
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWGParameter(ref byte ConAddr, byte Wg_mode, byte Wg_Data_Inteval, byte Wg_Pulse_Width, byte Wg_Pulse_Inteval, int PortHandle);

        //设置工作模式
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWorkMode(ref byte ConAddr, byte[] Parameter, int PortHandle);

        //读取工作模式参数
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetWorkModeParameter(ref byte ConAddr, byte[] Parameter, int PortHandle);

        //EAS检测精度测试
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetAccuracy(ref byte ConAddr, byte Accuracy, int PortHandle);

        //设置Syris命令响应偏置时间
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int SetOffsetTime(ref byte ConAddr, byte OffsetTime, int PortHandle);

        //G2询查命令
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Inventory_G2(ref byte ConAddr, byte AdrTID, byte LenTID, byte TIDFlag, byte[] EPClenandEPC, ref int Totallen, ref int CardNum, int PortHandle);

        //写EPC号命令
        [DllImport("Basic.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int WriteEPC_G2(ref byte ConAddr, byte[] Password, byte[] WriteEPC, byte WriteEPClen, ref int errorcode, int PortHandle);
    }



}
