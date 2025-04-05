var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", () => "Hello World!");
    endpoints.MapGet("/hello", () => "Hello from /hello endpoint!");
    endpoints.Map("/file/{fileName}.{extension}", (context) =>
    {
        string fileName = context.Request.RouteValues["fileName"]?.ToString();
        return context.Response.WriteAsync($"File name: {fileName}");
    });
    endpoints.Map("/employee/{employeeName}/{employeeId}", (context) =>
    {
        string employeeName = context.Request.RouteValues["employeeName"]?.ToString();
        string employeeId = context.Request.RouteValues["employeeId"]?.ToString();
        return context.Response.WriteAsync($"Employee Name: {employeeName}, Employee ID: {employeeId}");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the default route!");
});

app.Run();
