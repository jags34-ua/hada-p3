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

                string query = "Insert INTO Products (id, name, code, amount, price, category, creationDate) VALUES ('" + en.Code + "', '" + en.Name + "', '" + en.Code + "', '" + en.Amount + "', '" + en.Price + "', '" + en.Category + "', '" + en.CreationDate + "')";
                SqlCommand consulta = new SqlCommand(query, connect);
                consulta.ExecuteNonQuery();
                confirmation = true;
                connect.Close();
            }
            catch(SqlException e)
            {
                confirmation = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch(Exception ex)
            {
                confirmation = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
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

                string query = "Insert INTO Products (id, name, code, amount, price, category, creationDate) VALUES ('" + en.Code + "', '" + en.Name + "', '" + en.Code + "', '" + en.Amount + "', '" + en.Price + "', '" + en.Category + "', '" + en.CreationDate + "')";
                SqlCommand consulta = new SqlCommand(query, connect);
                consulta.ExecuteNonQuery();
                confirmation = true;
                connect.Close();
            }
            catch (SqlException e)
            {
                confirmation = false;
                Console.WriteLine("User operation has failed.Error: {0}", e.Message);
            }
            catch (Exception ex)
            {
                confirmation = false;
                Console.WriteLine("User operation has failed.Error: {0}", ex.Message);
            }
            return confirmation;
        }

        public bool Delete(ENProduct en)
        {

        }

        public bool Read(ENProduct en)
        {

        }

        public bool ReadFirst(ENProduct en)
        {

        }

        public bool ReadNext(ENProduct en)
        {

        }

        public bool ReadPrev(ENProduct en)
        {

        }
    }
}
