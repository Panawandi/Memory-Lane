using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ML.Models{
    public class UserDbContext : IdentityDbContext<UserApp>{
        
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
        }

    }
}