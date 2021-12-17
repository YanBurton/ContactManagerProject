using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

            //test for update contact (works)
            /*
            Contact contactUpdated = db.GetSelected(2);
            contactUpdated.f_name = "Alex";
            contactUpdated.l_name = "Ssuto";
            contactUpdated.phone = "4506798454";
            contactUpdated.address = "305 Red Goose road";
            contactUpdated.state = "QC";
            contactUpdated.zip = "f2w6r7";
            db.UpdateContact(contactUpdated);*/

            //test for delete contact (works)
            //db.DeleteContact(3);

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContact = new AddContact();
            addContact.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            update.ShowDialog();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Contact i = (Contact)selectList.SelectedItem;
            View view = new View(i);
            view.ShowDialog();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
