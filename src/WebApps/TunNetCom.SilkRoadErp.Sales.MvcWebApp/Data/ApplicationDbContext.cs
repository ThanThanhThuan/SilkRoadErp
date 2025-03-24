using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TunNetCom.SilkRoadErp.Sales.MvcWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
		//public ApplicationDbContext() { } // zzAdd This one
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
