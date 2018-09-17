using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class UserManager
    {
        //用户ID;
        public int m_userId;
        //用户姓名
        public string m_userName;
        //登录时间
        public string m_dateTime;
        //用户权限
        public string m_userPower;

        public int 用户ID
        {
            get { return m_userId; }
            set { m_userId = value; }
        }

        public string 用户姓名
        {
            get { return m_userName; }
            set { m_userName = value; }
        }

        public string 登录时间
        {
            get { return m_dateTime; }
            set { m_dateTime=value;}
        }

        public string 用户权限
        {
            get { return m_userPower; }
            set { m_userPower = value; }
        }

    }
}
