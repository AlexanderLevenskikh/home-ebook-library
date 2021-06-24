namespace Web.ViewModels.Shared
{
    public abstract class Dto<T>
    {
        public T Id { get; set; } = default!;
    }
}