namespace AspDotNetLab1.middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            File.AppendAllText("access.txt", $"{DateTime.Now} {context.Request.Path}\n");

            await _next(context);
        }
    }
}
