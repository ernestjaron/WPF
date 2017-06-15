using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadanie4;
using GUI.Model;
using ServicesLayer;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace GUI
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ViewModel()
        {
            
            Read = new RelayCommand(ExecuteMethodRead, canExecuteMethod);
            Add = new RelayCommand(ExecuteMethodAdd, canExecuteMethod);
            Delete = new RelayCommand(ExecuteMethodDelete, canExecuteMethod);
            Test = new RelayCommand(ExecuteMethodTest, canExecuteMethod);
            var query = (from p in db.Products select p).ToList();
            Products = new ObservableCollection<Product>(query);
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private CRUD crud = new CRUD();
        private ObservableCollection<Product> products;
        private Model.DataLayer datalayer = new Model.DataLayer();
        private Product product;
        DataClasses1DataContext db = new DataClasses1DataContext();


        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        public ObservableCollection<Product> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged("Products");
            }
        }


        public Product CurrentProduct
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged("CurrentProduct");
            }
        }
        

        internal Model.DataLayer DataLayer
        {
            get { return datalayer; }
            set
            {
                datalayer = value;
                Products = new ObservableCollection<Product>(value.Products);
            }
        }

        #endregion

#region Commands
       
        
        private bool canExecuteMethod(object parameter)
        {
            return true;
        }

      

        private void ExecuteMethodRead(object parameter)
        {
            Products = crud.Read(Products);
            MessageBox.Show("Liczba wczytanych elemenetów: "+ Products.Count().ToString());

        }


        private void ExecuteMethodAdd(object parameter)
        {
            Products = crud.Create(Products, CurrentProduct);
            MessageBox.Show("Dodano nowy element! Liczba elemenetów: " + Products.Count().ToString());
        }


        private void ExecuteMethodDelete(object parameter)
        {
            Products = crud.Delete(Products, CurrentProduct);
            MessageBox.Show("Usunięto element! Liczba elementów: " + Products.Count().ToString());

        }

        private void ExecuteMethodTest(object parameter)
        {
            crud.Read(Products);
        }


        public ICommand Read { get; set; }
        public ICommand Add { get; set; }
        public ICommand Delete { get; set; }

        public ICommand Test { get; set; }



        #endregion



    }
}
