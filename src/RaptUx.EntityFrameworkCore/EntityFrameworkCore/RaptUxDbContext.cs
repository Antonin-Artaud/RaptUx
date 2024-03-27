using Microsoft.EntityFrameworkCore;
using RaptUx.Entities.ChallengeEntities;
using RaptUx.Entities.CoursesEntities;
using RaptUx.Entities.GradeEntities;
using RaptUx.Entities.ProjectEntities;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace RaptUx.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class RaptUxDbContext :
    AbpDbContext<RaptUxDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    // Domain Entities
    public DbSet<ChallengeEntity> Challenges { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<GradeEntity> Grades { get; set; }
    public DbSet<ProjectEntity> Projects { get; set; }
    
    #endregion

    public RaptUxDbContext(DbContextOptions<RaptUxDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
        
        builder.Entity<ChallengeEntity>(b =>
        {
            b.ToTable(RaptUxConsts.DbTablePrefix + "Challenges", RaptUxConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.Property(c => c.ImageUrl).IsRequired().HasMaxLength(255);
            b.Property(c => c.Title).IsRequired().HasMaxLength(255);
            b.Property(c => c.Description).IsRequired().HasMaxLength(255);
            b.Property(c => c.Context).IsRequired().HasMaxLength(255);
            b.Property(c => c.Details).IsRequired().HasMaxLength(255);
            b.Property(c => c.Category).IsRequired().HasMaxLength(255);
            b.Property(c => c.AvailabilityDate).IsRequired();

            b.HasMany(c => c.Courses);
            b.HasMany(c => c.Projects);
        });
        
        builder.Entity<CourseEntity>(b =>
        {
            b.ToTable(RaptUxConsts.DbTablePrefix + "Courses", RaptUxConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.Property(c => c.Title).IsRequired().HasMaxLength(255);
            b.Property(c => c.Link).IsRequired().HasMaxLength(255);
            b.Property(c => c.Description).IsRequired().HasMaxLength(255);
        });
        
        builder.Entity<GradeEntity>(b =>
        {
            b.ToTable(RaptUxConsts.DbTablePrefix + "Grades", RaptUxConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.Property(c => c.Title).IsRequired().HasMaxLength(255);
            b.Property(c => c.Description).IsRequired().HasMaxLength(255);
        });
        
        builder.Entity<ProjectEntity>(b =>
        {
            b.ToTable(RaptUxConsts.DbTablePrefix + "Projects", RaptUxConsts.DbSchema);
            b.ConfigureByConvention();
            
            b.Property(c => c.OwnerId).IsRequired();
            b.Property(c => c.ImageBase64).IsRequired().HasMaxLength(255);
            b.Property(c => c.Link).IsRequired().HasMaxLength(255);
            b.Property(c => c.Description).IsRequired().HasMaxLength(255);
            b.Property(c => c.Likes).IsRequired();
        });
    }
}
