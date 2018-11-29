namespace StayGreen.Models.Common
{
    public class NamedEntity<T> : Entity<T>
    {
        public string Name { get; set; }
    }
}
