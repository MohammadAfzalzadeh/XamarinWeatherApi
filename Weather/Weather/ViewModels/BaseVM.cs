using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace Weather.ViewModels
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void onPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private bool buzy { get; set; }

        public async Task run(Func<Task> func)
        {
            if (!buzy)
            {
                buzy = true;
                try{
                    await func();
                }
                finally{
                buzy = false;
                }
              
            }
        }
    }
}
