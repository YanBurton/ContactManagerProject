using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactManagerProject
{
    class DB
    {
        private static DB db = new DB();
        private DB() { }
        public static DB getInstance()
        {
            return db;
        }
        private string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        //method that returns ALL contacts
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
                        MessageBox.Show("No records found.");
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

        //method that returns selected contact
        public Contact GetSelected(int id)
        {
            Contact c = null;

            using (var con = new SqlConnection(conString))
            {
                SqlCommand cm = new SqlCommand("Select * from contacts where id = @id", con);

                //for variables in query, use parameters
                cm.Parameters.AddWithValue("@id", id);

                con.Open();
                using (SqlDataReader sdr = cm.ExecuteReader())
                {
                    if (!sdr.HasRows)
                    {
                        MessageBox.Show("No records found.");
                    }
                    else
                    {
                        sdr.Read();
                        c = new Contact((int)sdr["id"], (string)sdr["f_name"], (string)sdr["l_name"], (string)sdr["phone"], (string)sdr["address"], (string)sdr["state"], (string)sdr["zip"]);
                    }
                }
            }
            return c;
        }

        //method that adds new contact
        public void AddContact(Contact contact)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "insert into contacts (f_name, l_name, phone, address, state, zip) VALUES(@fName, @lName, @phone, @address, @state, @zip)";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@fName", contact.f_name);
                cmd.Parameters.AddWithValue("@lName", contact.l_name);
                cmd.Parameters.AddWithValue("@phone", contact.phone);
                cmd.Parameters.AddWithValue("@address", contact.address);
                cmd.Parameters.AddWithValue("@state", contact.state);
                cmd.Parameters.AddWithValue("@zip", contact.zip);

                try
                {
                    con.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted Successfully");
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error: " + e.ToString());
                }
            }
        }

        //method to update selected contact
        public void UpdateContact(Contact contact)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "update contacts set f_name = @fName, l_name = @lName, phone = @phone, address = @address, state = @state, zip = @zip where id = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", contact.id);
                cmd.Parameters.AddWithValue("@fName", contact.f_name);
                cmd.Parameters.AddWithValue("@lName", contact.l_name);
                cmd.Parameters.AddWithValue("@phone", contact.phone);
                cmd.Parameters.AddWithValue("@address", contact.address);
                cmd.Parameters.AddWithValue("@state", contact.state);
                cmd.Parameters.AddWithValue("@zip", contact.zip);

                try
                {
                    con.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error: " + e.ToString());
                }
            }
        }

        //method to delete selected contact
        public void DeleteContact(int id)
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string query = "delete from contacts where id = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    con.Open();
                    var rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Deleted Successfully");
                }
                catch (SqlException e)
                {
                    MessageBox.Show("Error: " + e.ToString());
                }
            }
        }

    }
}
