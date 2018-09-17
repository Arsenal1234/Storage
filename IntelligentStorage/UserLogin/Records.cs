using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class Records
    {
        //查询ID
        public int m_inquireId;
        //用户姓名
        public string m_userName;
        //用户行为
        public string m_userBehaviour;
        //物品名称
        public string m_materialName;
        //物品数量
        public int m_materialCounts;
        //时间
        public string m_datetime;


        public int 查询ID
        {
            get { return m_inquireId; }
            set { m_inquireId = value; }
        }

        public string 用户姓名
        {
            get { return m_userName; }
            set { m_userName = value; }
        }

        public string 用户行为
        {
            get { return m_userBehaviour; }
            set { m_userBehaviour = value; }
        }

        public string 物品名称
        {
            get { return m_materialName; }
            set { m_materialName = value; }
        }

        public int 物品数量
        {
            get { return m_materialCounts; }
            set { m_materialCounts = value; }
        }

        public string 时间
        {
            get { return m_datetime; }
            set { m_datetime = value; }
        }
    }
}
