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
        DB db = new DB();
        public MainWindow()
        {
            InitializeComponent();
            List<Contact> myList = db.GetAllContacts();

            foreach (Contact c in myList)
            {
                lbl1.Content = c.id + " " + c.f_name + " " + c.l_name;
                //lbl1.Content = "hi";
            }
        }
    }
}
