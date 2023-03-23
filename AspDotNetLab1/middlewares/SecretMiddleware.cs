using System.Text.RegularExpressions;

namespace AspDotNetLab1.middlewares
{
    public class SecretMiddleware
    {
        private readonly RequestDelegate _next;

        public SecretMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Regex validateSecretRegex = new Regex("^/secret");
            Console.WriteLine();

            if (validateSecretRegex.IsMatch(context.Request.Path))
            {
                await context.Response.WriteAsync("This is a secret message.");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
