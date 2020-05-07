namespace TodoDashboard.Pages
{
    public class Controllers
    {
        public const string Users = "Users";
        public const string Role = "Role";
        public const string Home = "Home";
        public const string Authentication = "Authentication";
        public const string Profile = "Profile";
        public const string Wine = "Wine";
        public const string Location = "Location";
        public const string Master = "Master";

        public static string[] Admin = { Home,Master,Users, Profile, Location, Wine };
        public static string[] Managers = { Home, Profile, Location,Wine };
    }
}