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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        CustomersViewModel viewModel;

        //If true - act as New Order/ Faclse - act as Edit Order
        bool isAddWindow = true;

        public OrderWindow(bool _isAddWindow)
        {
            InitializeComponent();
            isAddWindow = _isAddWindow;
        }

        private void orderW_Loaded(object sender, RoutedEventArgs e)
        {
            viewModel = (CustomersViewModel)this.DataContext;
            if (!isAddWindow)
                viewModel.PreloadOrderDescription();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isAddWindow)
                viewModel.AddOrder();
            else
                viewModel.EditOrder();
           
            this.Close();

        }
    }
}
