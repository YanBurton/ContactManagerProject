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
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        DB db = DB.getInstance();

        //get id from selected contact
        private int id { get; set; }

        public Update(Contact contactSelected)
        {
            InitializeComponent();

            //Show contact
            fName.Text = contactSelected.f_name;
            lName.Text = contactSelected.l_name;
            phone.Text = contactSelected.phone;
            address.Text = contactSelected.address;
            state.Text = contactSelected.state;
            zip.Text = contactSelected.zip;

            id = contactSelected.id;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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
                Contact updatedContact = new Contact(id, fName.Text, lName.Text, phone.Text, address.Text, state.Text, zip.Text);
                db.UpdateContact(updatedContact);
            }        
        }
    }
}
