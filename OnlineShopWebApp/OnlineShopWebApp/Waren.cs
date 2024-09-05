namespace OnlineShopWebApp
{
    public class Waren
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }

        public Waren(string id, string name, string cost)
        {
            Id = id;
            Name = name;
            Cost = cost;
        }
        public string Info()
        {
            return String.Join(Environment.NewLine, [Id, Name, Cost]);
        }
    }
}
