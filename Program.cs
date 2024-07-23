using Contact_Management_Web_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
// Configure services
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseInMemoryDatabase("ContactDb"));
builder.Services.AddControllersWithViews();
//builder.Services.AddDbContext<ContactContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("ContactContext") ?? throw new InvalidOperationException("Connection string 'ContactContext' not found.")));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Seed data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ContactContext>();
    SeedData(context);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//create test data
void SeedData(ContactContext context)
{
    if (!context.Contact.Any())
    {
        context.Contact.AddRange(
            new Contact { Name = "Sample Contact 1", Email = "SampleContact1@gmail.com", PhoneNumber = "074 324 4354" },
            new Contact { Name = "Sample Contact 2", Email = "SampleContact2@gmail.com", PhoneNumber = "075 675 2345", },
            new Contact { Name = "Sample Contact 3", Email = "SampleContact3@gmail.com", PhoneNumber = "084 323 6756", }
        );
        context.SaveChanges();
    }
}