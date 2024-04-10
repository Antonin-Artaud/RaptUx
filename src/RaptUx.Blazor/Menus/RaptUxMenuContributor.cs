using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaptUx.Localization;
using RaptUx.MultiTenancy;
using RaptUx.Permissions;
using RaptUx.Permissions.Grades;
using Volo.Abp.Account.Localization;
using Volo.Abp.Identity.Blazor;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.SettingManagement.Blazor.Menus;
using Volo.Abp.TenantManagement.Blazor.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Abp.Users;

namespace RaptUx.Blazor.Menus;

public class RaptUxMenuContributor : IMenuContributor
{
    private readonly IConfiguration _configuration;

    public RaptUxMenuContributor(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
        else if (context.Menu.Name == StandardMenus.User)
        {
            await ConfigureUserMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<RaptUxResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                RaptUxMenus.Home,
                l["Menu:Home"],
                "/",
                icon: "fas fa-home",
                order: 0
            )
        );
        
        context.Menu.Items.Insert(
            1,
            new ApplicationMenuItem(
                RaptUxMenus.Challenges,
                l["Menu:Challenges"],
                "/challenges",
                icon: "fas fa-rocket",
                order: 1
            )
        );
        
        context.Menu.Items.Insert(
            2,
            new ApplicationMenuItem(
                RaptUxMenus.Profile,
                l["Menu:Profile"],
                "/my-profile",
                icon: "fas fa-user",
                order: 2
            ).RequireAuthenticated()
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenus.GroupName, 3);

        context.Menu.GetAdministration()
            .AddItem(new ApplicationMenuItem(
                "Rapt'Ux",
                "Rapt'Ux Management",
                icon: "fa fa-book"
            ).RequirePermissions(GradePermission.Grades.Default).RequireAuthenticated()
            .AddItem(
            new ApplicationMenuItem(
                "Grade",
                "Grades Management",
                url: "/grades"
            )
        ).RequireAuthenticated()
        .AddItem(
            new ApplicationMenuItem(
                "Course",
                "Courses Management",
                url: "/courses"
            )
            ).RequireAuthenticated()
        .AddItem(
            new ApplicationMenuItem(
                "challenge",
                "Challenge Management",
                url: "/challenge"
            )
            ).RequireAuthenticated());
        
        return Task.CompletedTask;
    }

    private Task ConfigureUserMenuAsync(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<RaptUxResource>();
        var accountStringLocalizer = context.GetLocalizer<AccountResource>();
        var authServerUrl = _configuration["AuthServer:Authority"] ?? "";

        context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountStringLocalizer["MyAccount"],
                $"{authServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}", icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
        context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "~/Account/Logout", icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());

        return Task.CompletedTask;
    }
}
