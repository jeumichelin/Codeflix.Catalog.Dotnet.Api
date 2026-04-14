using Codeflix.Catalog.Dotnet.Infra.Data.EF.Configurations;
using Microsoft.EntityFrameworkCore;
using DomainEntity = Codeflix.Catalog.Dotnet.Domain.Entities;

namespace Codeflix.Catalog.Dotnet.Infra.Data.EF;

public class CodeflixCatalogDbContext(DbContextOptions<CodeflixCatalogDbContext> options) : DbContext(options)
{
    public DbSet<DomainEntity.Category> Categories => Set<DomainEntity.Category>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new CategoryConfiguration());
    }
}
