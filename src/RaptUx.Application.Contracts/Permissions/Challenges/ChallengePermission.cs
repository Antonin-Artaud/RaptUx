namespace RaptUx.Permissions.Challenges;

public static class ChallengePermission
{
    public const string GroupName = "Challenge";
    
    public static class Challenges
    {
        public const string Default = GroupName + ".Challenge";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Update";
        public const string Delete = Default + ".Delete";
    }
}