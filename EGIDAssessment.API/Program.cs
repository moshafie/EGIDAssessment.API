using EGIDAssessment.Core.Domain.Interfaces.IRepository;
using EGIDAssessment.Core.Domain.Services;
using EGIDAssessment.Core.Domain.Services.SignalR;
using EGIDAssessment.Infrastructure.DataContext;
using EGIDAssessment.Infrastructure.DependencyInjection;

using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft;
using System.Reflection;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                             "https://localhost:4200",
                                             "http://localhost:4200/",
                                             "https://localhost:4200/")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .AllowCredentials();
});
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<DbContext, EGIDAssessmentDbContext>();
builder.Services.AddSignalR(e => e.MaximumReceiveMessageSize = 102400000);
builder.Services.AddTransient<ITimerManager,TimerManager>();
builder.Services.AddMediatR(typeof(EGIDAssessmentDbContext).GetTypeInfo().Assembly);
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddInfrastructure();
var app = builder.Build();

// Configure the HTTP request pipeline.
using (EGIDAssessmentDbContext context =new EGIDAssessmentDbContext(builder.Configuration))
{
    context.Database.EnsureCreated();
}


    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<StockHub>("/Market");

app.Run();
