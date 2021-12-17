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

            //test for add contact (works)
            /*
            Contact myContact = new Contact("Thomas", "Pepin", "4502163542", "8975 Exciting Place avenue", "QC", "h7u1a2");
            db.AddContact(myContact);*/

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

            }

            
        }

        //For Thomas 2
        private void btnExportCsv_Click(object sender, RoutedEventArgs e)
        {

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
