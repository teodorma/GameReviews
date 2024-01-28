using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameReviews.Models; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameReviewContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<GameReviewContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

SeedRoles(app.Services);

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

void SeedRoles(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            var role = new IdentityRole("Admin");
            roleManager.CreateAsync(role).Wait();
        }
        if (!roleManager.RoleExistsAsync("User").Result)
        {
            var role = new IdentityRole("User");
            roleManager.CreateAsync(role).Wait();
        }
    }
}
