using helloworld.Models;
using Microsoft.UI.Xaml;
using System.ComponentModel;
using System.Windows.Input;

namespace helloworld.ViewModels
{
    public class HelloViewModel : INotifyPropertyChanged
    {
        public HelloViewModel()
        {
            this.HelloCommand = new RelayCommand((object _) => ++Count);
        }
        public RelayCommand HelloCommand { get; }

        public int Count
        {
            get
            {
                return this._Hello.Count;
            }
            set
            {
                this._Hello.Count = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Count)));
            }
        }

        public string Message
        {
            get
            {
                return this._Hello.Message;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Hello _Hello = new();

    }
}
