using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Globalization;

namespace library
{
    public class CADProduct
    {
<<<<<<< HEAD
        private string constring;

        public CADProduct()
        {
            this.constring = ConfigurationManager.ConnectionStrings["baseDatos"].ToString();
=======
        private readonly string conString;

        public CADProduct()
        {
            conString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Create(ENProduct en)
        {
<<<<<<< HEAD
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                // Hay que cambiar el query?
                string query = "Insert INTO Products (name, code, amount, price, category, creationDate) VALUES ('" + en.Name + "', '" + en.Code + "', '" + en.Amount + "', '" + en.Price + "', '" + en.Category + "', '" + en.CreationDate + "')";
                SqlCommand consulta = new SqlCommand(query, connect);
                consulta.ExecuteNonQuery();
                confirmation = true;
                connect.Close();
            }
            catch(SqlException e)
            {
                confirmation = false;
                Console.WriteLine("La creación del producto falla.");
                Console.WriteLine("Create operation has failed.Error: {0}", e.Message);
            }
            catch(Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Create operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
=======
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
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Update(ENProduct en)
        {
<<<<<<< HEAD
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "UPDATE Products SET name = '" + en.Name + "', code = '" + en.Code + "', amount = '" + en.Amount + "', price = '" + en.Price + "', category = '" + en.Category + "', creationDate = '" + en.CreationDate + "' WHERE code = '" + en.Code + "'";

                SqlCommand consulta = new SqlCommand(query, connect);
                consulta.ExecuteNonQuery();
                confirmation = true;
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Update operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Update operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
=======
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
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Delete(ENProduct en)
        {
<<<<<<< HEAD
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "DELETE FROM Products WHERE code = '" + en.Code + "'";


                SqlCommand consulta = new SqlCommand(query, connect);
                consulta.ExecuteNonQuery();
                confirmation = true;
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Delete operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Delete operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
=======
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
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
        }

        public bool Read(ENProduct en)
        {
<<<<<<< HEAD
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "Select * FROM Products where code = '" + en.Code + "' ";
                SqlCommand consulta = new SqlCommand(query, connect);
                SqlDataReader dr = consulta.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["code"].ToString() == en.Code)
                    {
                        en.Code = dr["code"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        en.Name = dr["name"].ToString();
                        en.Category = int.Parse(dr["category"].ToString());

                        confirmation = true;
                    }
                    else
                    {
                        confirmation = false;
                    }
                }
                else
                {
                    confirmation = false;                }

                dr.Close();
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Read operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Read operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }

        public bool ReadFirst(ENProduct en)
        {
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "Select * FROM Products";
                SqlCommand consulta = new SqlCommand(query, connect);
                SqlDataReader dr = consulta.ExecuteReader();

                if (dr.Read())
                {
                    en.Code = dr["code"].ToString();
                    en.Amount = int.Parse(dr["amount"].ToString());
                    en.Price = float.Parse(dr["price"].ToString());
                    en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    en.Name = dr["name"].ToString();
                    en.Category = int.Parse(dr["category"].ToString());

                    confirmation = true;
                }
                else
                {
                    confirmation = false;
                }

                dr.Close();
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Read first operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Read first operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }

        public bool ReadNext(ENProduct en)
        {
            bool confirmation = false;
            bool found = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "Select * FROM Products";
                SqlCommand consulta = new SqlCommand(query, connect);
                SqlDataReader dr = consulta.ExecuteReader();

                
                while (dr.Read())
                {
                    if (found)
                    {
                        en.Code = dr["code"].ToString();
                        en.Amount = int.Parse(dr["amount"].ToString());
                        en.Price = float.Parse(dr["price"].ToString());
                        en.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                        en.Name = dr["name"].ToString();
                        en.Category = int.Parse(dr["category"].ToString());
                        confirmation = true;
                        break;
                    }
                    else if (dr["code"].ToString() == en.Code) {
                        found = true;
                    }
                }
                dr.Close();
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Read next operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Read next operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }

        public bool ReadPrev(ENProduct en)
        {
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "Select * FROM Products";
                SqlCommand consulta = new SqlCommand(query, connect);
                SqlDataReader dr = consulta.ExecuteReader();

                dr.Read();
                ENProduct pivote = new ENProduct();
                pivote.Code = dr["code"].ToString();
                pivote.Amount = int.Parse(dr["amount"].ToString());
                pivote.Price = float.Parse(dr["price"].ToString());
                pivote.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                pivote.Name = dr["name"].ToString();
                pivote.Category = int.Parse(dr["category"].ToString());

                while (dr.Read() && !confirmation)
                {
                    if (dr["code"].ToString() == en.Code)
                    {
                        confirmation = true;
                        break;
                    }

                    pivote.Code = dr["code"].ToString();
                    pivote.Amount = int.Parse(dr["amount"].ToString());
                    pivote.Price = float.Parse(dr["price"].ToString());
                    pivote.CreationDate = DateTime.Parse(dr["creationDate"].ToString());
                    pivote.Name = dr["name"].ToString();
                    pivote.Category = int.Parse(dr["category"].ToString());
                }

                en.Code = pivote.Code;
                en.Name = pivote.Name;
                en.Amount = pivote.Amount;
                en.Category = pivote.Category;
                en.CreationDate = pivote.CreationDate;
                en.Price = pivote.Price;

                dr.Close();
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("Read next operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Read next operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }
=======
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
>>>>>>> 091ba6e90ccf442e8190160ec6bc658ffc963baf
    }
}
