namespace StayGreen.Models.Dtos.Common
{
    public abstract class BaseDto<T>
    {
        public T Id { get; set; }
    }
}
