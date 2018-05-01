using System;
using System.Data.SqlClient;

namespace MiniUserRestApi.Utilities
{
    public class Utils
    {
        public static bool CheckDbConnection(string connection)
        {
            using (var conn = new SqlConnection(connection))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
