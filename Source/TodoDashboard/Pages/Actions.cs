namespace TodoDashboard.Pages
{
    public class Actions
    {
        #region Common
        public const string Index = "Index";
        public const string BindData = "BindData";
        public const string Upsert = "Upsert";
        public const string Delete = "Delete";
        public const string ActInact = "ActInact";
        public const string GetById = "GetById";
        #endregion Common        

        #region Authentication
        public const string SignIn = "SignIn";
        public const string RecoverPassword = "RecoverPassword";
        public const string Logout = "Logout";
        #endregion

        #region Profile
        public const string ChangePassword = "ChangePassword";
        #endregion

        #region Home
        public const string AddDrink  = "AddDrink";
        public const string EditDrink ="EditDrink";
        public const string ViewDrink = "ViewDrink";
        #endregion

    }
}