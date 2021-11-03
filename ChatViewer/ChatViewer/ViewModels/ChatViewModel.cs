using ChatViewer.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.Core;

namespace ChatViewer.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public ChatViewModel()
        {
            this.ChatList = new ObservableCollection<Chat>();

            this.AddChatCommand = new RelayCommand((object _) =>
            {
                User user = new User(1, "とろゝ", "toro_ponz", "https://hayabusa.io/openrec-image/user/3219367/321936685.w164.ttl3600.v1543673624.png?format=png");
                Chat chat = new Chat("Hello, World!", user);

                this.ChatList.Add(chat);
            });

            this.ConnectSocket();
        }

        private void ConnectSocket()
        {
            var options = new IO.Options();
            options.Transports = Quobject.Collections.Immutable.ImmutableList.Create("websocket");
            options.Query = new Dictionary<string, string>() { { "movieId", "2413585" } };

            Socket socket = IO.Socket("https://chat.openrec.tv", options);

            socket.On(Socket.EVENT_CONNECT, this.On());
            socket.On(Socket.EVENT_CONNECT_ERROR, this.On());
            socket.On(Socket.EVENT_CONNECT_TIMEOUT, this.On());
            socket.On(Socket.EVENT_DISCONNECT, this.On());
            socket.On(Socket.EVENT_ERROR, this.On());
            socket.On(Socket.EVENT_RECONNECT, this.On());
            socket.On(Socket.EVENT_RECONNECTING, this.On());
            socket.On(Socket.EVENT_RECONNECT_ATTEMPT, this.On());
            socket.On(Socket.EVENT_RECONNECT_ERROR, this.On());
            socket.On(Socket.EVENT_RECONNECT_FAILED, this.On());

            socket.On(Socket.EVENT_MESSAGE, async (object message) =>
            {
                System.Diagnostics.Debug.WriteLine(message);


                User user = new User(1, "とろゝ", "toro_ponz", "https://hayabusa.io/openrec-image/user/3219367/321936685.w164.ttl3600.v1543673624.png?format=png");
                Chat chat = new Chat("Hello, World!", user);


                var dispatcherQueue = Microsoft.UI.Xaml.Window.Current.DispatcherQueue;
                dispatcherQueue.TryEnqueue(() => this.ChatList.Add(chat));

                /**
                try
                {
                    JObject o = JObject.Parse(message.ToString());

                    string type = o["type"].ToString();

                    switch ((SocketType)int.Parse(type))
                    {
                        case SocketType.Chat:
                            this.AddChat(o);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                **/
            });

            socket.Connect();
        }

        private void AddChat(JObject message)
        {
            //var userId = long.Parse(message["data"]["user_id"].ToString());
            //var userName = message["data"]["user_name"].ToString();
            //var userScreenName = message["data"]["user_key"].ToString();
            //var userIconPath = message["data"]["user_icon"].ToString();
            //var chatMessage = message["data"]["message"].ToString();

            //User user = new User(userId, userName, userScreenName, userIconPath);
            //Chat chat = new Chat(chatMessage, user);

            User user = new User(1, "とろゝ", "toro_ponz", "https://hayabusa.io/openrec-image/user/3219367/321936685.w164.ttl3600.v1543673624.png?format=png");
            Chat chat = new Chat("Hello, World!", user);

            this.ChatList.Add(chat);
        }

        private Action<object> On()
        {
            return (object message) => System.Diagnostics.Debug.WriteLine(message);
        }

        public RelayCommand AddChatCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Chat> ChatList { get; }

    }
}
