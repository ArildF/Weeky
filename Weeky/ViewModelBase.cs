using System;
using System.ComponentModel;

namespace Weeky
{
    public class ViewModelBase : INotifyPropertyChanged, IRaisePropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}