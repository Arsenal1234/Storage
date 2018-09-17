using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using AicUI.Desktop.Utilities;
using System.Windows.Forms;

namespace UserLogin
{
    public class UHFReaderConfiguration
    {
        public UHFReaderConfiguration()
        {

        }

        //端口号
        [XmlElement("COM")]
        public string COM { get; set; }
        //波特率
        [XmlElement("BaudRate")]
        public string BaudRate { get; set; }
        //读写器地址
        [XmlElement("Address")]
        public string Address { get; set; }
        //读写器型号
        [XmlElement("Type")]
        public string Type { get; set; }
        //读写器版本号
        [XmlElement("Version")]
        public string Version { get; set; }
        //读写器功率
        [XmlElement("Power")]
        public string Power { get; set; }
        //读写器最低频率
        [XmlElement("LowestFrequency")]
        public string LowestFrequency { get; set; }
        //读写器最高频率
        [XmlElement("HighestFrequency")]
        public string HighestFrequency { get; set; }
        //韦根
        [XmlElement("Wiegand")]
        public string Wiegand { get; set; }
        //询查命令最大响应时间
        [XmlElement("MaximumResponseTime")]
        public string MaximumResponseTime { get; set; }
        //询查标签间隔时间
        [XmlElement("InquiryTagInterval")]
        public string InquiryTagInterval { get; set; }
        //数据输出间隔
        [XmlElement("DataOutputInterval")]
        public string DataOutputInterval { get; set; }    
        //脉冲间隔
        [XmlElement("PulseInterval")]
        public string PulseInterval { get; set; }
        //脉冲宽度
        [XmlElement("PulseWidth")]
        public string PulseWidth { get; set; }    
        //韦根输出模式
        [XmlElement("WiegandOutputMode")]
        public string WiegandOutputMode { get; set; }
    }

    public class UHFReaderConfigurations
    {
        private static List<UHFReaderConfiguration> m_uhfreaderconfiglist;
        public static UHFReaderConfiguration UHFReader;
        //static UHFReaderConfigurations()
        //{
        //    if (m_uhfreaderconfiglist == null)
        //    {
        //        LoadConfigurations();
        //    }
        //}

        public static void LoadConfigurations()
        {
            try
            {
                var currentPath = AssemblyHelper.GetCurrentExecutingDirectory();
                var filePath = currentPath + "\\UHFReaderConfig.xml";
                XmlSerializer serializer = new XmlSerializer(typeof(List<UHFReaderConfiguration>));
                TextReader textReader = new StreamReader(filePath);
                m_uhfreaderconfiglist = (List<UHFReaderConfiguration>)serializer.Deserialize(textReader);
                textReader.Close();
                UHFReader = m_uhfreaderconfiglist.FirstOrDefault();
                MessageBox.Show("文件读取成功", "提示,", MessageBoxButtons.OK, MessageBoxIcon.Information);           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }
    }



}
