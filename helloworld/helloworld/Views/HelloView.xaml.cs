using Microsoft.UI.Xaml.Controls;
using helloworld.ViewModels;

namespace helloworld.Views
{
    public sealed partial class HelloView : Page
    {
        public HelloView()
        {
            this.InitializeComponent();
            this.HelloViewModel = new HelloViewModel();
        }

        public HelloViewModel HelloViewModel { get; }
    }
}
