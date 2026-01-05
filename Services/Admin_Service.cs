using trekdle.DB_Context;
using trekdle.Models.DB_Models;
using trekdle.Services;
using BCrypt.Net;

public class Admin_Service: Base_Service<Admin>
{
    public Admin_Service(DBContext context): base(context) {}

    public override async Task CreateItemAsync(Admin admin)
    {
        admin.Password = BCrypt.HashPassword(admin.Password);

        await base.CreateItemAsync(admin);
    }
}
