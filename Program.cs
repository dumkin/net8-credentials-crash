using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://localhost:2000");
var app = builder.Build();

app.MapGet("/", context =>
{
    context.Response.Headers.Append("X-WSSecurity-For", "None");
    context.Response.Headers.Append("WWW-Authenticate", "Negotiate");
    context.Response.StatusCode = 401;
    return Task.CompletedTask;
});

var cts = new CancellationTokenSource();
cts.CancelAfter(TimeSpan.FromSeconds(10));
await Task.Factory.StartNew(async () => await app.RunAsync(cts.Token));

var client = new HttpClient(new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
    Credentials = new NetworkCredential("test", "test"),
});
client.BaseAddress = new Uri("http://127.0.0.1:2000");
await client.GetStringAsync("");