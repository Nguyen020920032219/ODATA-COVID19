using CovidODataApi.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Reflection.Emit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Covid19DbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddOData(options =>
    options.Select().Filter().OrderBy().Count().SetMaxTop(null)
           .AddRouteComponents("odata", GetEdmModel())
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<VwCovidDataCombined>("CovidData");
    builder.EntitySet<Confirmed>("Confirmed");
    builder.EntitySet<Death>("Death");
    builder.EntitySet<Recovered>("Recovered");
    builder.EntitySet<DailyReport>("DailyReport");
    return builder.GetEdmModel();
}