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
        private string constring;

        public CADProduct()
        {
            this.constring = ConfigurationManager.ConnectionStrings["baseDatos"].ToString();
        }

        public bool Create(ENProduct en)
        {
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
        }

        public bool Update(ENProduct en)
        {
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
        }

        public bool Delete(ENProduct en)
        {
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
        }

        public bool Read(ENProduct en)
        {
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
            return true;
        }
    }
}
