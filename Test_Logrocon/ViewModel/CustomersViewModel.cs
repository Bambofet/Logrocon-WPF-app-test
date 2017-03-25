using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Logrocon.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Test_Logrocon.ViewModel
{

  

    class CustomersViewModel : INotifyPropertyChanged
    {
        Database1Entities dataEntities = new Database1Entities();




        private String _newOrderDescription;
        /// <summary>
        /// Descrition of new or existing Order
        /// </summary>
        public String _NewOrderDescription
        {
            get { return _newOrderDescription; }
            set
            {
                _newOrderDescription = value;
                NotifyPropertyChanged("_NewOrderDescription");
            }
        }


        //Selected Customer Name Binding
        private String _selectedName;
        /// <summary>
        /// Name of Selected Customer
        /// </summary>
        public String _SelectedName
        {
            get { return _selectedName; }
            set
            {
                this._selectedName = value;
                NotifyPropertyChanged("_SelectedName");
            }
        }


        //Selected Customer Binding
        private Customers _selctedCust;
        /// <summary>
        /// Selected Customer Item
        /// </summary>
        public Customers _selectedCustomer
        {
            get { return _selctedCust; }
            set
            {
                this._selctedCust = value;
               if(value==null)
                    this._selectedName = "";             
               else
                    this._selectedName = value.Name;
                NotifyPropertyChanged("_selectedCustomer");
            }
        }

        //Selected Ordere Binding
        private Orders _selectedOrd;
        /// <summary>
        /// Selected Order Item
        /// </summary>
        public Orders _selectedOrder
        {
            get { return _selectedOrd; }
            set
            {
                this._selectedOrd = value;
                NotifyPropertyChanged("_selectedOrder");
            }
        }



        //Customer list binding
        private ObservableCollection<Customers> _cust;
        /// <summary>
        /// List of all Customers
        /// </summary>
        public ObservableCollection<Customers> _Customers
        {
            get { return this._cust; }
            set
            {
                this._cust = value;
                NotifyPropertyChanged("_Customers");
            }
        }

        //Orders Binding
        private ObservableCollection<Orders> _ords;
        /// <summary>
        /// List of all the Orders of the Selected Customer
        /// </summary>
        public ObservableCollection<Orders> _Orders
        {
            get { return this._ords; }
            set
            {
                this._ords = value;
                NotifyPropertyChanged("_Orders");
            }
        }

        //INotify Implimentatin for binding
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var e = PropertyChanged;
            if(e !=null)
            {
                e(this, new PropertyChangedEventArgs(propertyName));
            }

        }

       /// <summary>
       /// Delete selected customer
       /// </summary>
        public void DeleteCustomer()
            {
            
              //Delete all orders for customer
            foreach (var order in _ords)
            {
                Orders tempOrd = new Orders() { Number = order.Number };
                dataEntities.Orders.Attach(tempOrd);
                dataEntities.Orders.Remove(tempOrd);
            }
            dataEntities.SaveChanges();

            //Delete actual customer
            Customers cust = new Customers() { Id = _selectedCustomer.Id };
            dataEntities.Customers.Attach(cust);
            dataEntities.Customers.Remove(cust);
            dataEntities.SaveChanges();


            LoadCustomers();
                
            

            }

        /// <summary>
        /// Delete Selected Order
        /// </summary>
        public void DeleteOrder()
        {
            Orders tempOrd = new Orders() { Number = _selectedOrd.Number };
            dataEntities.Orders.Attach(tempOrd);
            dataEntities.Orders.Remove(tempOrd);
            dataEntities.SaveChanges();
            LoadOrders();
        }



        /// <summary>
        /// Load all the orders of the Selected Customer from Data Base
        /// </summary>
        public void LoadOrders()
        {
            ObservableCollection<Orders> orders = new ObservableCollection<Orders>();

            var query =
                from order in dataEntities.Orders
                orderby order.Number
                where order.CustomerId == _selctedCust.Id
                select new { order.Number, order.Description, order.CustomerId };

            try { 
            var a = query.ToList();


            foreach (var ord in a)
            {
                orders.Add(new Orders
                {
                    CustomerId = ord.CustomerId,
                    Description = ord.Description,
                    Number = ord.Number
                });
            }

            _Orders = orders;
            }
            catch
            {
                _Orders = null;
            }
        }



        /// <summary>
        /// Loadd all the customers from Data Base
        /// </summary>
        public void LoadCustomers()
        {
            ObservableCollection<Customers> customers = new ObservableCollection<Customers>();
            
            var query =
                   
                   from customer in dataEntities.Customers
                   orderby customer.Id               
                   select new { customer.Id, customer.Name, customer.Address, customer.VIP };

           var a=  query.ToList();

            foreach (var cus in a)
            {
                customers.Add(new Customers
                {
                    Address = cus.Address,
                    Id = cus.Id,
                    Name = cus.Name,
                    VIP = cus.VIP
                });

            }
            
            _Customers = customers;
        }

        /// <summary>
        /// Add new Order Into Data Base and update Order List
        /// </summary>
        public void AddOrder()
        {
            Orders tempOrd = new Orders
            {
                CustomerId = _selectedCustomer.Id,
                Description = _newOrderDescription
            };

            var context = new Database1Entities();
            context.Orders.Add(tempOrd);

            try
            {
                context.SaveChanges();
            }
            catch { }

            _newOrderDescription = "";
            LoadOrders();
        }


        /// <summary>
        /// Preloads Existing Order Description for existing order
        /// </summary>
        public void PreloadOrderDescription()
        {
            try
            {
                _NewOrderDescription = _selectedOrder.Description;
            }
            catch { }
        }


        /// <summary>
        /// Modifies existing Ored in the Data Base and udpates list of orders
        /// </summary>
        public void EditOrder()
        {
            

            Orders tempOrd = new Orders()
            {
                CustomerId = _selectedOrder.CustomerId,
                Number = _selectedOrder.Number,
                Description = _newOrderDescription
            };

            var context = new Database1Entities();
            context.Orders.Attach(tempOrd);
            try
            {
                context.Entry(tempOrd).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
            catch { }

            _newOrderDescription = "";
            LoadOrders();


        }


    }
    

}
