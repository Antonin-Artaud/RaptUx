using RaptUx.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace RaptUx.Permissions.Project;

public class ProjectPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(ProjectPermission.GroupName, L("Project Management"));

        var bookPermission = bookStoreGroup.AddPermission(ProjectPermission.Projects.Default, L("Default"));
        bookPermission.AddChild(ProjectPermission.Projects.Create, L("Create"));
        bookPermission.AddChild(ProjectPermission.Projects.Edit, L("Edit"));
        bookPermission.AddChild(ProjectPermission.Projects.Delete, L("Delete"));
    }
    
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RaptUxResource>(name);
    }
}