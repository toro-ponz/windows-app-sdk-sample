namespace ChatViewer.Models
{
    public class User
    {
        public User(long Id, string Name, string ScreenName, string IconPath)
        {
            this.Id = Id;
            this.Name = Name;
            this.ScreenName = ScreenName;
            this.IconPath = IconPath;
        }

        public long Id { get; }
        public string Name { get; }
        public string ScreenName { get; }
        public string IconPath { get; }
    }
}
