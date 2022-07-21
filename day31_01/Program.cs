
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day31_01
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn;
            //서버 연결                       
            conn = new SqlConnection();
            conn.ConnectionString = "server=.\\SQLEXPRESS;database=test;user id=sa;" + "pwd=alencia;";
            conn.Open();


            Console.WriteLine("추가한 상태: ");
            string sqlRead = "SELECT * FROM testTable01";
            string strcmd01 = "INSERT INTO testTable01 VALUES(201978001, '김목자', 'MALE', '성남시')";
            string strcmd02 = "INSERT INTO testTable01 VALUES(201789001, '뉴비장', 'FEMALE', '하남시')";
            SqlCommand sqlcmd = new SqlCommand(strcmd01, conn);
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = strcmd02;
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = sqlRead;
            SqlDataReader Reader = sqlcmd.ExecuteReader();
            while (Reader.Read())
            {
                Console.WriteLine($"{Reader["Nid"]}\t{Reader[1]}\t{Reader[2]}\t{Reader[3]}");
            }
            Reader.Close();


            Console.WriteLine("\n\nDelete 문 실행 후:");
            string strcmd03 = "DELETE FROM [testTable01] WHERE Nid = 201978001";
            string strcmd04 = "DELETE FROM [testTable01] WHERE Nid = 201789001";
            sqlcmd.CommandText = strcmd03;
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = strcmd04;
            sqlcmd.ExecuteNonQuery();
            sqlcmd.CommandText = sqlRead;
            SqlDataReader Reader2 = sqlcmd.ExecuteReader();
            while (Reader2.Read())
            {
                Console.WriteLine($"{Reader2["Nid"]}\t{Reader2[1]}\t{Reader2[2]}\t{Reader2[3]}");
            }

            Reader2.Close();

            conn.Close();
        }
    }
}
