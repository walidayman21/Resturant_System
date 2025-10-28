namespace Resturant_System.Services
{
    public class SingeltonService
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
