namespace React.Entity
{
    public class User : IEntitybase
    {
        public string Id { get; set; }
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
    }
}