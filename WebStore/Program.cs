var builder = WebApplication.CreateBuilder(args);

#region Настройка построителя приложения - определение содержимого
//builder.Configuration.AddCommandLine(args);

var services = builder.Services;
services.AddControllersWithViews();
#endregion

var app = builder.Build(); //Сборка приложения

//app.Urls.Add("http://+:80"); // - если хочется обеспечить видимость приложения в локальной сети

#region Конфигурирование конвейера обработки входящих соединений
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

//app.MapGet("/", () => app.Configuration["CustomGreetings"]);
app.MapGet("/throw", () => 
{ 
    throw new ApplicationException("Ошибка в программе!"); 
});

//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion

app.Run(); //Запуск приложения
