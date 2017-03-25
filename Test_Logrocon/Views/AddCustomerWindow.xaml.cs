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
using Test_Logrocon.ViewModel;

namespace Test_Logrocon.Views
{
    /// <summary>
    /// Логика взаимодействия для AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        private AddCustomerViewModel viewModel;


        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        public AddCustomerWindow()
        {
            InitializeComponent();
        
            viewModel = new AddCustomerViewModel();
            this.DataContext = viewModel;


        }

       

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.AddCustomer();

            // C//ustomersViewModel cus = new CustomersViewModel();
            // cus.LoadCustomers();
            DataChangedEventHandler handler = DataChanged;
            if(handler!=null)
            {
                handler(this, new EventArgs());
            }
            this.Close();
        }
    }
}
