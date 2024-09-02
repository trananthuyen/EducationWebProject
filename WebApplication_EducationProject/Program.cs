using ServiceContracts;
using Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


//add services into Ioc container (cho AccountServer co tieu chuan interface la IAccountService
builder.Services.AddScoped<IAccountService, AccountService>();


builder.Services.AddDbContext<AccountsDbContext>
    (options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });


var app = builder.Build();




if (builder.Environment.IsDevelopment())  //buider environment for developer to test case
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseRouting();


app.MapControllers();
app.Run();

