//-----------------------------------------------------------------------
// <copyright file="SQLConfig.cs" company="Rushkar">
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
    }
}
