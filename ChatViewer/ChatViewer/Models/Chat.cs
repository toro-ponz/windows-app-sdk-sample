namespace ChatViewer.Models
{
    public class Chat
    {
        public Chat(string Message, User User)
        {
            this.Message = Message;
            this.User = User;
        }

        public string Message { get; }
        public User User { get; }
    }
}
