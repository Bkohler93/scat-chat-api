var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IScatService, ScatService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
           ValidateIssuer = false,
           ValidateAudience = false,
       }; 
    });
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("LocalConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
