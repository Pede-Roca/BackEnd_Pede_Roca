namespace Pede_RocaAPP.API.Middleware
{
    public static class ErrorHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder ErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
