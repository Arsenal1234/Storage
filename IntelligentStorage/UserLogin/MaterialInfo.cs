using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public  class MaterialInfo
    {
        //物品ID
        public int m_materialId;
        //物品标签
        public string m_materialRfid;
        //物品存放位置
        public string m_materialPos;
        //物品名称
        public string m_materialName;
        //库存余量
        public int m_materialNum;

        public int 物品ID
        {
            get { return m_materialId; }
            set { m_materialId = value; }
        }

        public string 物品标签
        {
            get { return m_materialRfid; }
            set { m_materialRfid = value; }
        }

        public string 物品存放位置
        {
            get { return m_materialPos; }
            set { m_materialPos = value; }
        }

        public string 物品名称
        {
            get { return m_materialName; }
            set { m_materialName = value; }
        }

        public int 库存余量
        {
            get { return m_materialNum; }
            set { m_materialNum = value; }
        }

    }
}
