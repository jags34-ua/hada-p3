using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class CADProduct
    {
        private readonly string conString;

        public CADProduct()
        {
            conString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }

        public bool Create(ENProduct en)
        {
            using (var con = new SqlConnection(conString))
            {
                const string query = "INSERT INTO Products (Code, Name, Amount, Price, CreationDate) VALUES (@Code, @Name, @Amount, @Price, @CreationDate)";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", en.Code);
                cmd.Parameters.AddWithValue("@Name", en.Name);
                cmd.Parameters.AddWithValue("@Amount", en.Amount);
                cmd.Parameters.AddWithValue("@Price", en.Price);
                cmd.Parameters.AddWithValue("@CreationDate", en.CreationDate);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Update(ENProduct en)
        {
            using (var con = new SqlConnection(conString))
            {
                const string query = "UPDATE Products SET Name=@Name, Amount=@Amount, Price=@Price, CreationDate=@CreationDate WHERE Code=@Code";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", en.Code);
                cmd.Parameters.AddWithValue("@Name", en.Name);
                cmd.Parameters.AddWithValue("@Amount", en.Amount);
                cmd.Parameters.AddWithValue("@Price", en.Price);
                cmd.Parameters.AddWithValue("@CreationDate", en.CreationDate);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Delete(ENProduct en)
        {
            using (var con = new SqlConnection(conString))
            {
                const string query = "DELETE FROM Products WHERE Code=@Code";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", en.Code);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        public bool Read(ENProduct en)
        {
            using (var con = new SqlConnection(conString))
            {
                const string query = "SELECT Code, Name, Amount, Price, CreationDate FROM Products WHERE Code=@Code";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Code", en.Code);

                try
                {
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            en.Name = reader["Name"].ToString();
                            en.Amount = Convert.ToInt32(reader["Amount"]);
                            en.Price = Convert.ToSingle(reader["Price"]);
                            en.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            return true;
                        }
                        return false;
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return false;
                }
            }
        }

        // Implement ReadFirst, ReadNext, ReadPrev similarly based on your database schema and logic requirements.
    }
}
