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
    /// Interaction logic for View.xaml
    /// </summary>
    public partial class View : Window
    {
        DB db = DB.getInstance();
        public View(Contact contactSelected)
        {
            InitializeComponent();

            selectContactID.Text = contactSelected.id.ToString();
            selectContactFName.Text = contactSelected.f_name;
            selectContactLName.Text = contactSelected.l_name;
            selectContactPhone.Text = contactSelected.phone;
            selectContactAddress.Text = contactSelected.address;
            selectContactState.Text = contactSelected.state;
            selectContactZip.Text = contactSelected.zip;
        }
    }
}
