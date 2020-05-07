//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="RUSHKAR">
//     Copyright Rushkar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace TodoDashboard.Data
{
    /// <summary>
    /// SQL configuration class which holds stored procedure name.
    /// </summary>
    internal sealed class SQLConfig
    {
        #region Tdd_Admin
        public const string Tdd_Admin_LastLogin = "Tdd_Admin_LastLogin";
        public const string Tdd_Admin_ChangePassword = "Tdd_Admin_ChangePassword";
        public const string Tdd_Admin_Login = "Tdd_Admin_Login";
        public const string TddAdmin_ById = "TddAdmin_ById";
        #endregion

        #region Tdd_Client
        public const string Tdd_Client_Upsert = "Tdd_Client_Upsert";
        public const string Tdd_Client_Id = "Tdd_Client_Id";
        public const string Tdd_Client_All = "Tdd_Client_All";
        public const string Tdd_Client_Delete = "Tdd_Client_Delete";
        public const string Tdd_Client_ActInact = "Tdd_Client_ActInact";
        #endregion

        #region LocationWines
        public const string LocationWines_Upsert = "LocationWines_Upsert";
        public const string LocationWines_Id = "LocationWines_Id";
        public const string LocationWines_All = "LocationWines_All";
        #endregion

        #region MasterBarTypes
        public const string MasterBarTypes_Upsert = "MasterBarTypes_Upsert";
        public const string MasterBarTypes_Id = "MasterBarTypes_Id";
        public const string MasterBarTypes_All = "MasterBarTypes_All";
        #endregion

        #region MasterDistributors
        public const string MasterDistributors_Upsert = "MasterDistributors_Upsert";
        public const string MasterDistributors_Id = "MasterDistributors_Id";
        public const string MasterDistributors_All = "MasterDistributors_All";
        #endregion

        #region MasterLocations
        public const string MasterLocations_Upsert = "MasterLocations_Upsert";
        public const string MasterLocations_Id = "MasterLocations_Id";
        public const string MasterLocations_All = "MasterLocations_All";
        #endregion

        #region MasterServicesTypes
        public const string MasterServicesTypes_Upsert = "MasterServicesTypes_Upsert";
        public const string MasterServicesTypes_Id = "MasterServicesTypes_Id";
        public const string MasterServicesTypes_All = "MasterServicesTypes_All";
        #endregion

        #region MasterStates
        public const string MasterStates_All = "MasterStates_All";
        #endregion

        #region MasterTiers
        public const string MasterTiers_Upsert = "MasterTiers_Upsert";
        public const string MasterTiers_Id = "MasterTiers_Id";
        public const string MasterTiers_All = "MasterTiers_All";
        #endregion

        #region MasterUser
        public const string MasterUser_Upsert = "MasterUser_Upsert";
        public const string MasterUser_Id = "MasterUser_Id";
        public const string MasterUser_All = "MasterUser_All";
        public const string MasterUser_Login = "MasterUser_Login";
        public const string MasterUser_ActInact = "MasterUser_ActInact";
        public const string MasterUser_ChangePassword = "MasterUser_ChangePassword";
        #endregion

        #region MasterWines
        public const string MasterWines_Upsert = "MasterWines_Upsert";
        public const string MasterWines_Id = "MasterWines_Id";
        public const string MasterWines_All = "MasterWines_All";
        #endregion

        #region MasterWineVaritals
        public const string MasterWineVaritals_Upsert = "MasterWineVaritals_Upsert";
        public const string MasterWineVaritals_Id = "MasterWineVaritals_Id";
        public const string MasterWineVaritals_All = "MasterWineVaritals_All";
        #endregion
    }
}
