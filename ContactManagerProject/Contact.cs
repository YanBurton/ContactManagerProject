using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerProject
{
    public class Contact
    {
        public int id { get; set; }
        public string f_name { get; set; }
        public string l_name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        //constructor 1, where id is needed
        public Contact(int id, string f_name, string l_name, string phone, string address, string state, string zip)
        {
            this.id = id;
            this.f_name = f_name;
            this.l_name = l_name;
            this.phone = phone;
            this.address = address;
            this.state = state;
            this.zip = zip;
        }

        //constructor 2, where id is not needed (like when adding new objects)
        public Contact(string f_name, string l_name, string phone, string address, string state, string zip)
        {
            this.f_name = f_name;
            this.l_name = l_name;
            this.phone = phone;
            this.address = address;
            this.state = state;
            this.zip = zip;
        }
    }
}
