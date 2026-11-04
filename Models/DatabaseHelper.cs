using System.Data;
using Microsoft.Data.SqlClient;

namespace KisiselAjandaWeb.Models
{
    public class DatabaseHelper
    {
        // SQL Server bağlantı adresimiz (TrustServerCertificate=True kısmı yeni .NET güvenlik kuralları için kritiktir)
        private readonly string _connectionString = @"Server=localhost;Database=KisiselAjandaDB;Integrated Security=True;TrustServerCertificate=True;";

        // SELECT (Veri Okuma) işlemleri için kullanacağımız metot
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // INSERT, UPDATE, DELETE (Veri Yazma/Düzenleme/Silme) işlemleri için kullanacağımız metot
        public int ExecuteNonQuery(string query)
        {
            int affectedRows = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                }
            }
            return affectedRows;
        }
    }
}