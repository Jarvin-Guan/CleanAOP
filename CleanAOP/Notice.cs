using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CleanAOP
{
    public class Notice : INotifyPropertyChanged, ICommand
    {

        #region [     用于实现绑定的属性基础      ]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }
        #endregion

        #region [     用于实现绑定的命令基础     ]
        public bool CanExecute(object parameter)
        {
            if (this.CanExecuteFunc != null)
            {
                return this.CanExecuteFunc(parameter);
            }

            return true;


        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (this.ExecuteAction != null)
            {
                this.ExecuteAction(parameter);

            }
        }

        public Func<object, bool> CanExecuteFunc { set; get; }

        public Action<object> ExecuteAction { set; get; }
        #endregion
    }
}
