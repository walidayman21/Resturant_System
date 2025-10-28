namespace Resturant_System.Services
{
    public class TransientService
    {
        public string Id { get; } = Guid.NewGuid().ToString();
    }
}
