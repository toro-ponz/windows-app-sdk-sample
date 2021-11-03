using ChatViewer.ViewModels;
using Microsoft.UI.Xaml.Controls;

namespace ChatViewer.Views
{
    public sealed partial class ChatView : Page
    {
        public ChatView()
        {
            this.InitializeComponent();
            this.ChatViewModel = new ChatViewModel();
        }

        public ChatViewModel ChatViewModel { get; }
    }
}
