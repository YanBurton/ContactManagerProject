using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DB db = DB.getInstance();
        public MainWindow()
        {
            InitializeComponent();

            //Initialize list
            List<Contact> contactList = db.GetAllContacts();
            selectList.ItemsSource = contactList;
            selectList.SelectedItem = 0;
            selectList.Focus();

            //test for delete contact (works)
            //db.DeleteContact(3);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.ShowDialog();
            Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Contact i = (Contact)selectList.SelectedItem;
            Update update = new Update(i);
            update.ShowDialog();
            Refresh();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Contact i = (Contact)selectList.SelectedItem;         
            db.DeleteContact(i.id);
            Refresh();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Contact i = (Contact)selectList.SelectedItem;
            View view = new View(i);
            view.ShowDialog();
            Refresh();
        }

        //For Thomas
        private void btnAddCsv_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Office files |*.csv";

            if (openFileDialog.ShowDialog() == true) {

                string path = openFileDialog.FileName;
                using (TextFieldParser csvParser = new TextFieldParser(path))
                {
                    csvParser.CommentTokens = new string[] { "#" };
                    csvParser.SetDelimiters(new string[] { "," });
                    csvParser.HasFieldsEnclosedInQuotes = true;

                    // Skip the row with the column names
                    csvParser.ReadLine();

                    while (!csvParser.EndOfData)
                    {
                        // Read current line fields, pointer moves to the next line.
                        string[] fields = csvParser.ReadFields();
                        string fName = fields[0];
                        string lName = fields[1];
                        string phone = fields[2];
                        string address = fields[3];
                        string state = fields[4];
                        string zip = fields[5];
                        Contact newContact = new Contact(fName, lName, phone, address, state, zip);
                        db.AddContact(newContact);

                    }
                }
            }

            Refresh();
        }

        //For Thomas 2
        private void btnExportCsv_Click(object sender, RoutedEventArgs e)
        {
            //Change for your own path 
            string filePath = @"C:\Users\thoma\source\repos\ContactManagerProject\ContactManagerProject\Contact.csv";
            
            var csv = new StringBuilder();
            List<Contact> contacts = db.GetAllContacts();
            foreach (Contact contact in contacts)
            {
                string fName = contact.f_name;
                string lName = contact.l_name;
                string phone = contact.phone;
                string address = contact.address;
                string states = contact.state;
                string zip = contact.zip;


                var newLine = string.Format("{0},{1},{2},{3},{4},{5}", fName, lName, phone, address, states, zip );
                csv.AppendLine( newLine );
            }
        File.WriteAllText( filePath, csv.ToString() );
        }
        
        private void Refresh()
        {
            List<Contact> contactList = db.GetAllContacts();
            selectList.ItemsSource = contactList;
            selectList.SelectedItem = 0;
            selectList.Focus();
        }
    }
}
