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
using System.Windows.Shapes;

namespace ContactManagerProject
{
    /// <summary>
    /// Interaction logic for AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        DB db = DB.getInstance();
        public AddContact()
        {
            InitializeComponent();
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (fName.Text == "")
            {
                requiredF.Visibility = Visibility.Visible;
            }
            else if (lName.Text == "")
            {
                requiredL.Visibility = Visibility.Visible;
            } 
            else if (phone.Text == "")
            {
                requiredP.Visibility = Visibility.Visible;
            }
            else
            {
                requiredF.Visibility = Visibility.Hidden;
                requiredL.Visibility = Visibility.Hidden;
                requiredP.Visibility = Visibility.Hidden;
                Contact newContact = new Contact(fName.Text, lName.Text, phone.Text, address.Text, state.Text, zip.Text);
                db.AddContact(newContact);
            }          
        }
    }
}
