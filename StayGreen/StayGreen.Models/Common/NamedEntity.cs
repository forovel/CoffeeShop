namespace StayGreen.Models.Common
{
    public abstract class NamedEntity<T> : Entity<T>
    {
        public string Name { get; set; }
    }
}
