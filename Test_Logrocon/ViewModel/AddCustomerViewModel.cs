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
    class AddCustomerViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
       
        private string _custName;
        private string _custAddress;
        private bool _custVip;


        public bool _CustomerVip
        {
            get { return this._custVip; }
            set
            {
                this._custVip = value;
                NotifyPropertyChanged("_CustomerVip");
            }
        }

        public string _CustomerName
        {
            get { return this._custName; }
            set
            {
                this._custName = value;
                NotifyPropertyChanged("_CustomerName");
            }
        }

        public string _CustomerAddress
        {
            get { return this._custAddress; }
            set
            {
                this._custAddress = value;
                NotifyPropertyChanged("_CustomerAddress");

            }
        }



        // IDataError
        public string this[string columnName]
        {
            get
            {
                string msg = null;
                switch(columnName)
                {
                    case "_CustomerName":
                        if (_CustomerName == null)
                            msg = "Name is required";
                        else if(_CustomerName.Length>5)
                            msg = "Too Long";
                        break;
                }
                return msg;
            }
        }

        //public string Error => throw new NotImplementedException();
        public string Error
        {
            get;
        }

        //INotify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            var e = PropertyChanged;
            if (e != null)
            {
                e(this, new PropertyChangedEventArgs(propertyName));
            }

        }



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
