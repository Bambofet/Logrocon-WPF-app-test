using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer.Utilities;
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
using Test_Logrocon.Model;
using Test_Logrocon.ViewModel;
using Test_Logrocon.Views;

namespace Test_Logrocon
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Database1Entities dataEntities = new Database1Entities();


        private CustomersViewModel viewModel;


        public MainWindow()
        {
            InitializeComponent();
            viewModel = new CustomersViewModel();
            this.DataContext = viewModel;
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Load all customers from database to DataGrid
            viewModel.LoadCustomers();
        }

        private void CustomersList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            //Load Orders for selected customer
            viewModel.LoadOrders();
        }


        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow wind = new AddCustomerWindow();
            //Delegate for updating DataGrid after customer was added to Data Base
            wind.DataChanged += AddCustomerWindow_DataChanged;
            wind.ShowDialog();
        }

        //Delegate for updating DataGrid after customer was added to Data Base
        private void AddCustomerWindow_DataChanged(object sender, EventArgs e)
        {
            viewModel.LoadCustomers();
        }

        #region Delete Customer
        //Delete selectd Customer by Button click
        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteCustomer();
        }
        //Delete selected Customer by pressing "Delete' Key
        private void DeleteCustomer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteCustomer();
            }
        }
        //Delete Selected Customer
        private void DeleteCustomer()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this customer?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.DeleteCustomer();
        }
#endregion

        #region Delete Order 

        //Delete selected Order by bpressing button
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder();
        }
        //Delete seleceted Order By pressing "Delete" Key
        private void DeleteOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DeleteOrder();
            }
        }
        //Delete selected order
        private void DeleteOrder()
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this order?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.DeleteOrder();
        }
#endregion


        //Add New Order
        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow wind = new OrderWindow(true)
            {
                DataContext = this.DataContext
            };
            wind.ShowDialog();
        }


        #region Edit Oreder 

        //Edit Selected order Order by pressing button
        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            EditOrder();
        }
        //Edit Selected order Order by double click
        private void OrdersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try { EditOrder();}
            catch { }
        }
        //Edit selected Order
        private void EditOrder()
        {
            OrderWindow wind = new OrderWindow(false)
            {
                DataContext = this.DataContext

            };
            wind.ShowDialog();
        }
        #endregion

    }
      
    
}
