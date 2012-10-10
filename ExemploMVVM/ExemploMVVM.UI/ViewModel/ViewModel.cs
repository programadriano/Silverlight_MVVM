using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using ExemploMVVM.Model.Model;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace ExemploMVVM.UI.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public ViewModel()
        {
            this.People = new ObservableCollection<Person>();
            this.AddCommand = new DelegateCommand<object>(ExecuteAddCommad);
            this.ClearVariablesPerson();
        }

        #endregion

        #region Private Methods

        private void ExecuteAddCommad(object parameter)
        {
            if (string.IsNullOrEmpty(this.Name))
                MessageBox.Show("Campo nome em branco.");
            
            this.People.Add(new Person() { Name = this.Name, Email = this.Email });
            this.ClearVariablesPerson();
        }

        private void ClearVariablesPerson()
        {
            this.Email = string.Empty;
            this.Name = string.Empty;
        }

        #endregion

        #region Public Properties

        public ObservableCollection<Person> People { get; set; }
        public DelegateCommand<object> AddCommand { get; set; }

        private string _name;
        public string Name
        {
            get { return this._name; }
            set
            {
                this._name = value;
                this.NotifyPropertyChanged("Name");
            }
        }
        private string _email;
        public string Email
        {
            get { return this._email; }
            set
            {
                this._email = value;
                this.NotifyPropertyChanged("Email");
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
