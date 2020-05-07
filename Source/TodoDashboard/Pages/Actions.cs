namespace TodoDashboard.Pages
{
    public class Actions
    {
        #region Common
        public const string Index = "Index";
        public const string BindData = "BindData";
        public const string BindLocationData = "BindLocationData";
        public const string BindWineData = "BindWineData";
        public const string Upsert = "Upsert";
        public const string Delete = "Delete";
        public const string ActInact = "ActInact";
        public const string GetById = "GetById";
        public const string DeleteSelectedWinesFromLocation = "DeleteSelectedWinesFromLocation";
        public const string DeleteSelectedLocationsFromWine = "DeleteSelectedLocationsFromWine";
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

        #region Master
        public const string WineVaritals = "WineVaritals";
        public const string BarTypes = "BarTypes";
        public const string ServiceTypes = "ServiceTypes";
        public const string Tiers = "Tiers";
        public const string Distributors = "Distributors";
        #endregion
    }
}