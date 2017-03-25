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

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void columnHeader_Click(object sender, RoutedEventArgs e)
        {

            //ColorVIP();
        }

        private void ColorVIP()
        {

            var itemSource = CustomersList.ItemsSource as IEnumerable;


            Color color;
            color = (Color)ColorConverter.ConvertFromString("#ffd700");


            int i = 0;

            foreach (var item in itemSource)
            {
                CustomersList.UpdateLayout();
                 CustomersList.ScrollIntoView(CustomersList.Items);


                var row = CustomersList.ItemContainerGenerator.ContainerFromIndex(i) as DataGridRow;
               
                if (row != null)
                {
                    try
                    {
                        CheckBox x = CustomersList.Columns[3].GetCellContent(CustomersList.Items[i]) as CheckBox;
                        
                        if (x != null)
                            if (x.IsChecked.HasValue ? x.IsChecked.Value : false)
                                row.Background = new SolidColorBrush(color);
                        row = null;
                    }

                    catch
                    {

                    }
                }
                i++;
            }
        }

        private void Row_Click(object sender, MouseButtonEventArgs e)
        {
            ColorVIP();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
   
            viewModel.LoadCustomers();
      
        }

        private void CustomersList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
            viewModel.LoadOrders();

        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow wind = new AddCustomerWindow();
            wind.DataChanged += AddCustomerWindow_DataChanged;
            wind.ShowDialog();
            
        }

        private void AddCustomerWindow_DataChanged(object sender, EventArgs e)
        {
            viewModel.LoadCustomers();
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this customer?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.DeleteCustomer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to delete this order?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
                viewModel.DeleteOrder();
        }


        //Add Order
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OrderWindow wind = new OrderWindow(true)
            {
                DataContext = this.DataContext
            };
            wind.ShowDialog();
        }

        //Edit Order
        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow wind = new OrderWindow(false)
            {
                DataContext = this.DataContext
                
            };
            wind.ShowDialog();
        }

        private void OrdersList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OrderWindow wind = new OrderWindow(false)
                {
                    DataContext = this.DataContext

                };
                wind.ShowDialog();
            }
            catch { }
        }
    }
}
