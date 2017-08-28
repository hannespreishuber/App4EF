using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace App4EF
{
    public class ToDo : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private string _task;

        public string Task
        {
            get { return _task; }
            set { _task = value;
                RaisePropertyChanged("Task"); }
        }

        public bool Done { get; set; } = false;
        public event PropertyChangedEventHandler PropertyChanged;
       // ([CallerMemberName] String propertyName = "")
        void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
