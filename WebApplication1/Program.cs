using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();




builder.Services.AddControllers(option => {
    //option.ReturnHttpNotAcceptable=true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ApplicationDBContext
builder.Services.AddEntityFrameworkNpgsql()
            .AddDbContext<ApplicationDBContext>(opt =>
            opt.UseNpgsql(builder.Configuration.GetConnectionString("SampleDBConnection")));






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
