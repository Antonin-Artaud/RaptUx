namespace RaptUx.Permissions.Grades;

public static class GradePermission
{
    public const string GroupName = "Grade";
    
    public static class Grades
    {
        public const string Default = GroupName + ".Grades";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}