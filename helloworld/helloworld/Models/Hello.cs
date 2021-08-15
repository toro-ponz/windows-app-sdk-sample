namespace helloworld.Models
{
    class Hello
    {
        public Hello()
        {
            this.Count = 0;
            this.Message = "Hello, World!";
        }

        public int Count { get; set; }
        public string Message { get; }
    }
}
