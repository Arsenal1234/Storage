using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace InquireRecords
{
    /// <summary>
    /// InquireDatas 的摘要说明
    /// </summary>
    public class InquireDatas : IHttpHandler
    {
        string conStr = "Data Source='101.200.210.193'; Initial Catalog=db_WMS;User ID=sa;Password=1010";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            using (SqlConnection conn = new SqlConnection(conStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from tb_InquiryRecords", conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                context.Response.Write(DataTableToJson(ds.Tables[0]));
                ds.Dispose();
                sda.Dispose();
            }
        }

        public string DataTableToJson(DataTable ds)
        {
            string jsonData = JsonConvert.SerializeObject(ds);
            return jsonData;
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}