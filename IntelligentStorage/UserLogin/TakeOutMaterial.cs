using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
     public class TakeOutMaterial
    {
        private string m_textRfid;
        private string m_textCounts;

        public string 标签号
        {
            get { return m_textRfid; }
            set { m_textRfid = value; }
        }

        public string 数量
        {
            get { return m_textCounts; }
            set { m_textCounts = value; }
        }
    }
}
