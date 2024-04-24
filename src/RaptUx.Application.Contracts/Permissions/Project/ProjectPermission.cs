namespace RaptUx.Permissions.Project;

public class ProjectPermission
{
    public const string GroupName = "Project";

    public static class Projects
    {
        public const string Default = GroupName + ".Project";
        public const string Create = GroupName + ".Create";
        public const string Edit = GroupName + ".Update";
        public const string Delete = GroupName + ".Delete";
    }
}