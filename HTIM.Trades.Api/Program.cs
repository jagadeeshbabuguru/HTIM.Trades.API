using HTIM.Trades.Business.Helpers;
using HTIM.Trades.Business;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Identity.Web;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();

builder.Services.AddMicrosoftIdentityWebApiAuthentication(config);
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});
// Add services to the container.
builder.Services.AddBussinessInterface(config);
builder.Services.AddControllers();
builder.Services
    .AddApiVersioning()
    .AddVersionedApiExplorer(setup =>
    {
        setup.GroupNameFormat = "'v'V";
        setup.SubstituteApiVersionInUrl = true;
    });
//builder.Services.AddCors(options => options.AddPolicy(name: "TradesAPI",
//policy =>
//{
//    policy.WithOrigins("http://localhost:4200", "http://testudp.american-equity.com/").AllowAnyMethod().AllowAnyHeader();
//}));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Trades API",
        Description = "ADFS Authentication for API"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Automatically adds an Authorization header  using the Bearer schema to all requests requiring authentication.\n\nExample \n Authorization: Bearer Value \n\n",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{ }
                    }

                });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AppRights", policy =>
      policy.RequireRole("AppAdmin", "AppRead", "AppWrite"));
});



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseApiVersioning();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();
//app.UseCors("TradesAPI");
app.Run();

