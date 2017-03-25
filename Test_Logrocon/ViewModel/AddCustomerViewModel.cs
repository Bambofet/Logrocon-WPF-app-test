using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Logrocon.Model;
using System.Data.Entity;

namespace Test_Logrocon.ViewModel
{
    class AddCustomerViewModel : INotifyPropertyChanged
    {
       
        private string _custName;
        private string _custAddress;
        private bool _custVip;

        /// <summary>
        /// Selected Customer Vip status
        /// </summary>
        public bool _CustomerVip
        {
            get { return this._custVip; }
            set
            {
                this._custVip = value;
                NotifyPropertyChanged("_CustomerVip");
            }
        }


        /// <summary>
        /// Selected Customer Name
        /// </summary>
        public string _CustomerName
        {
            get { return this._custName; }
            set
            {
                this._custName = value;
                NotifyPropertyChanged("_CustomerName");
            }
        }


        /// <summary>
        /// Selected Customer Address
        /// </summary>
        public string _CustomerAddress
        {
            get { return this._custAddress; }
            set
            {
                this._custAddress = value;
                NotifyPropertyChanged("_CustomerAddress");

            }
        }

               

        //INotify implimentation
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var e = PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(propertyName));
            }

        }


        /// <summary>
        /// Add new Customer into Data Base
        /// </summary>
        public void AddCustomer()
        {
            Customers temp = new Customers
            {
                Address = _custAddress,
                Name = _custName,
                VIP = _custVip
            };

           
            var context = new Database1Entities();

            context.Customers.Add(temp);
            try { 
            context.SaveChanges();
            }
            catch { }

        }



    }
}
