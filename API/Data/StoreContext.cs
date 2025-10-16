using System;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class StoreContext(DbContextOptions options) : IdentityDbContext<User>(options)
{
    public required DbSet<Product> Products { get; set; }
    public required DbSet<Basket> Baskets { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<IdentityRole>()
        .HasData(
                new IdentityRole {Id="0cc39e76-6275-4aeb-9e67-36596f3ebd91 ", Name = "Member", NormalizedName = "MEMBER" },
                new IdentityRole { Id="e33858d9-4609-42bb-81b3-c5d8840ba006 ", Name = "Admin", NormalizedName = "ADMIN" }
        );
    }
}
