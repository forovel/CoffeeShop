namespace StayGreen.Models.Dtos.Common
{
    public abstract class NamedBaseDto<T> : BaseDto<T>
    {
        public string Name { get; set; }
    }
}
