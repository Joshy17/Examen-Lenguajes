using AdmTarea.BW.CU;
using AdmTarea.BW.Interfaces.BW;
using AdmTarea.BW.Interfaces.DA;
using AdmTarea.DA.Acciones;
using AdmTarea.DA.Contexto;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Inyecci�n de dependencias
builder.Services.AddTransient<IGestionarTareaBW, GestionarTareaBW>();
builder.Services.AddTransient<IGestionarTareaDA, GestionarTareaDA>();

builder.Services.AddTransient<IGestionarFotoBW, GestionarFotoBW>();
builder.Services.AddTransient<IGestionarFotoDA, GestionarFotoDA>();

//Conexi�n a BD
builder.Services.AddDbContext<AdmTareaContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=tcp:163.178.107.10;Initial Catalog=FotosC16960;Persist Security Info=False;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});

builder.Services.AddDbContext<FotoContext>(options =>
{
    // Usar la cadena de conexi�n desde la configuraci�n
    var connectionString = "Server=tcp:163.178.107.10;Initial Catalog=FotosC16960;Persist Security Info=False;User Id=laboratorios;Password=TUy&)&nfC7QqQau.%278UQ24/=%;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
    // Otros ajustes del contexto de base de datos pueden ser configurados aqu�, si es necesario
});


var app = builder.Build();

// Aplicar la pol�tica de CORS
app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
