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
    public class CADCategory
    {
        private string constring;

        public CADCategory()
        {
            this.constring = ConfigurationManager.ConnectionStrings["baseDatos"].ToString();
        }

        public bool Read(ENCategory en)
        {
            bool confirmation = false;
            try
            {
                SqlConnection connect = null;
                connect = new SqlConnection(constring);
                connect.Open();
                string query = "Select * FROM Products where code = '" + en.Id + "' ";
                SqlCommand consulta = new SqlCommand(query, connect);
                SqlDataReader dr = consulta.ExecuteReader();

                if (dr.Read())
                {
                    if (int.Parse(dr["id"].ToString()) == en.Id)
                    {
                        en.Id = int.Parse(dr["id"].ToString());
                        en.Name = dr["name"].ToString();

                        confirmation = true;
                    }
                    else
                    {
                        confirmation = false;
                    }
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
                Console.WriteLine("Read operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("Read operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }

        public List<ENCategory> ReadAll()
        {
            List<ENCategory> categories = new List<ENCategory>();

            try
            {
                SqlConnection connect = new SqlConnection(constring);
                connect.Open();

                string query = "SELECT id, name FROM Categories";
                SqlCommand command = new SqlCommand(query, connect);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string name = reader["name"].ToString();
                    ENCategory category = new ENCategory(id, name);
                    categories.Add(category);
                }

                connect.Close();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("An error occurred while reading categories: " + ex.Message);
            }

            return categories;
        }
    }
}
