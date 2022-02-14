namespace WebStore.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var controllerName = context.Request.RouteValues["controller"];
            var actionName = context.Request.RouteValues["action"];

            // Обработка информации из context.Request

            var task = _next(context); // далее здесь работает оставшаяся часть конвейера

            // Выполнять действия параллельно ассинхронно с остальной частью конвейера

            await task;
            // Дообработка данных в context.Response
        }
    }
}
