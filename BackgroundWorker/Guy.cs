namespace BackgroundWorker
{
    public class Guy
    {
        private readonly string name;

        public string Name { get { return name; } }

        private readonly sbyte age;

        public sbyte Age { get { return age; } }

        public int Cash { get; private set; }

        public Guy(string name, sbyte age, int cash)
        {
            this.name = name;
            this.age = age;
            Cash = cash;
        }
    }
}
