using RaptUx.Localization;
using RaptUx.Permissions.Grades;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace RaptUx.Permissions.Challenges;

public class ChallengePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var bookStoreGroup = context.AddGroup(ChallengePermission.GroupName, L("Challenge Management"));

        var booksPermission = bookStoreGroup.AddPermission(ChallengePermission.Challenges.Default, L("Default"));
        booksPermission.AddChild(ChallengePermission.Challenges.Create, L("Create"));
        booksPermission.AddChild(ChallengePermission.Challenges.Edit, L("Edit"));
        booksPermission.AddChild(ChallengePermission.Challenges.Delete, L("Delete"));
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<RaptUxResource>(name);
    }
}