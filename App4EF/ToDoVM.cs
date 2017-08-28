using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace App4EF
{
    public class ToDoVM : INotifyPropertyChanged
    {


        public ObservableCollection<ToDo> ToDoList { get; set; }= new ObservableCollection<ToDo>();
        private ToDo _item;
        public ToDoVM()
        {
            Item = new ToDo();
        }
        public ToDo Item
        {
            get { return _item; }
            set { _item = value;
                RaisePropertyChanged("Item");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void AddNew()
        {
            Item = new ToDo();
            

        }
        public void SaveItem()
        {
            var ef = new ToDoContext();
            if (_item.ID>0)
            {
                var item=ef.ToDos.Find(_item.ID);
                ef.Entry(item).CurrentValues.SetValues(Item);
                ToDoList.Where(id => id.ID == _item.ID).First().Task = _item.Task;
      
            }
            else
            {
                ef.ToDos.Add(_item);
                //ToDoList.Add(_item);
                //oder 
               // Load();
            
            }
            ef.SaveChanges();
            Load();
        }

        public void Load()
        {
            
            var ef = new ToDoContext();
            foreach (var t in ef.ToDos)
            {
                if (ToDoList.Where(x => x.ID == t.ID).Count() == 0)
                {

                    ToDoList.Add(t);
                }
            }


        }
        public void SelectedID(ToDo item)
        {
            Item = item;

        }
        public void UpdateDone()
        {
            var ef = new ToDoContext();

            foreach (var item in ef.ToDos)
            {
                item.Done = ToDoList.Where(id => id.ID == item.ID).First().Done;

            }
            ef.SaveChanges();
        }

        void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
