using RaptUx.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RaptUx.Permissions.Grades;

public class GradePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(GradePermission.GroupName, L("Grade Management"));

        var booksPermission = bookStoreGroup.AddPermission(GradePermission.Grades.Default, L("Default"));
        booksPermission.AddChild(GradePermission.Grades.Create, L("Create"));
        booksPermission.AddChild(GradePermission.Grades.Edit, L("Edit"));
        booksPermission.AddChild(GradePermission.Grades.Delete, L("Delete"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RaptUxResource>(name);
    }
}