using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Timers;
using System.Windows.Forms;

namespace UserLogin
{
    public class Sqloperate
    {
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        /// <summary>
        /// 创建操作数据库的SQL语句方法
        /// </summary>
        /// <param name="sqlcommand"></param>
        public void SqlCommands(string sqlcommand)
        {           
            SqlConnection conn = new SqlConnection(conStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlcommand,conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
    }
}
