using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    class DB
    {
        private string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            //using will automatically close
            using (var con = new SqlConnection(conString))
            {
                SqlCommand cm = new SqlCommand("Select * from contacts", con);

                con.Open();
                using (SqlDataReader sdr = cm.ExecuteReader())
                {
                    if (!sdr.HasRows)
                    {
                        Console.WriteLine("No records found.");
                    }
                    else
                    {
                        while (sdr.Read())
                        {
                            Contact i = new Contact((int)sdr["id"], (string)sdr["f_name"], (string)sdr["l_name"], (string)sdr["phone"], (string)sdr["address"], (string)sdr["state"], (string)sdr["zip"]);
                            contacts.Add(i);
                        }
                    }
                }
            }
            return contacts;
        }
    }
}
