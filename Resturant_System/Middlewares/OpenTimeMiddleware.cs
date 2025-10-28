namespace Resturant_System.Middlewares
{
    public class OpenTimeMiddleware 
    {
        private readonly RequestDelegate _next;
        //public static readonly TimeSpan StartTime = new TimeSpan(3, 0, 0);
        //public static readonly TimeSpan EndTime = new TimeSpan(24, 30, 0);

        private const int StartHour = 12;
        private const int EndHour = 24;

        public OpenTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var CurrentHour = DateTime.Now.Hour;

            if(CurrentHour >= StartHour && CurrentHour <= EndHour)
            {
                await _next(context); 
                return;
            }

            await context.Response.WriteAsync("The Restaurant is closed now, \n it's open at 12.00 pm.");
        }
    }
}
