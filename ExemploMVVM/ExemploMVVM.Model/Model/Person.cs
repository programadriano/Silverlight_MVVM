using System.ComponentModel;

namespace ExemploMVVM.Model.Model
{
    public class Person : INotifyPropertyChanged
    {
        #region Constructor

        public Person()
        {
        }

        #endregion

        #region Public Properties
               
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

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
