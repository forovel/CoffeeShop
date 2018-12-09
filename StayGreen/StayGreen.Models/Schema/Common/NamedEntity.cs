namespace StayGreen.Models.Schema.Common
{
    public abstract class NamedEntity<T> : Entity<T>
    {
        public string Name { get; set; }
    }
}
