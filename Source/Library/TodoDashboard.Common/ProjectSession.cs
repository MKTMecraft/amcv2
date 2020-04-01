using System.Web;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

namespace TodoDashboard.Common
{
    public class ProjectSession
    {
        public static string CurrentCultureCode
        {
            get
            {
                if (HttpContext.Current.Session["CurrentCultureCode"] == null)
                {
                    return "gu-IN";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CurrentCultureCode"]);
                }
                //return ConvertTo.String(HttpContext.Current.Session["CurrentCultureCode"]); //= Thread.CurrentThread.CurrentUICulture.Name;
            }
            set
            {
                HttpContext.Current.Session["CurrentCultureCode"] = value;
                //HttpContext.Current.Session["CurrentCultureCode"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the client connection string.
        /// </summary>
        /// <value>The client connection string.</value>
        public static string ClientConnectionString
        {
            get
            {
                if (HttpContext.Current.Session["ConnectionString"] == null)
                {
                    return Configurations.ConnectionString;
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["ConnectionString"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ConnectionString"] = value;
            }
        }

        public static string LastLoginStr
        {
            get
            {
                if (HttpContext.Current.Session["LastLoginStr"] == null)
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["LastLoginStr"]);
                }
            }

            set
            {
                HttpContext.Current.Session["LastLoginStr"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int AdminUserID
        {
            get
            {
                if (HttpContext.Current.Session["AdminUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminUserID"] = value;
            }
        }
        public static int CustomerId
        {
            get
            {
                if (HttpContext.Current.Session["CustomerId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["CustomerId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CustomerId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the company id of the logged in user.
        /// </summary>
        public static string CompanyId
        {
            get
            {
                if (HttpContext.Current.Session["CompanyId"] == null)
                {
                    return "MA==";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CompanyId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CompanyId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department id of the logged in user.
        /// </summary>
        public static string DepartmentId
        {
            get
            {
                if (HttpContext.Current.Session["DepartmentId"] == null)
                {
                    return "MA==";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DepartmentId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DepartmentId"] = value;
            }
        }

        public static string DesignationId
        {
            get
            {
                if (HttpContext.Current.Session["DesignationId"] == null)
                {
                    return "MA==";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DesignationId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DesignationId"] = value;
            }
        }

        public static string DesignationName
        {
            get
            {
                if (HttpContext.Current.Session["DesignationName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DesignationName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DesignationName"] = value;
            }
        }

        public static string AdminRoleName
        {
            get
            {
                if (HttpContext.Current.Session["AdminRoleName"] == null)
                {
                    return "No Role";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AdminRoleName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminRoleName"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string DepartmentName
        {
            get
            {
                if (HttpContext.Current.Session["DepartmentName"] == null)
                {
                    return "No Department";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["DepartmentName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["DepartmentName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string CustomerName
        {
            get
            {
                if (HttpContext.Current.Session["CustomerName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CustomerName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CustomerName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string AggregatorName
        {
            get
            {
                if (HttpContext.Current.Session["AggregatorName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AggregatorName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AggregatorName"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int SubAdminUserID
        {
            get
            {
                if (HttpContext.Current.Session["SubAdminUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubAdminUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubAdminUserID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the SubAdminResetUserID identifier.
        /// </summary>
        public static int SubAdminResetUserID
        {
            get
            {
                if (HttpContext.Current.Session["SubAdminResetUserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubAdminResetUserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubAdminResetUserID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the admin user.
        /// </summary>
        /// <value>The name of the admin user.</value>
        public static string AdminUserName
        {
            get
            {
                if (HttpContext.Current.Session["AdminUserName"] == null)
                {
                    return "Admin";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AdminUserName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminUserName"] = value;
            }
        }

        public static string CheckType
        {
            get
            {
                if (HttpContext.Current.Session["CheckType"] == null)
                {
                    return "0";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CheckType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CheckType"] = value;
            }
        }


        public static string StepsRemaining
        {
            get
            {
                if (HttpContext.Current.Session["StepsRemaining"] == null)
                {
                    return "StepsRemaining";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["StepsRemaining"]);
                }
            }

            set
            {
                HttpContext.Current.Session["StepsRemaining"] = value;
            }
        }


        public static string CheckLastDate
        {
            get
            {
                if (HttpContext.Current.Session["CheckLastDate"] == null)
                {
                    return "-";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["CheckLastDate"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CheckLastDate"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public static int UserID
        {
            get
            {
                if (HttpContext.Current.Session["UserID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["UserID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>The name of the user.</value>
        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["UserName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserName"] = value;
            }
        }

        public static string Mobile
        {
            get
            {
                if (HttpContext.Current.Session["Mobile"] == null)
                {
                    return "Mobile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Mobile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Mobile"] = value;
            }
        }

        public static string Email
        {
            get
            {
                if (HttpContext.Current.Session["Email"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Email"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Email"] = value;
            }
        }

        public static string Menu
        {
            get
            {
                if (HttpContext.Current.Session["Menu"] == null)
                {
                    return "Menu";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Menu"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Menu"] = value;
            }
        }

        public static int SubscriptionId
        {
            get
            {
                if (HttpContext.Current.Session["SubscriptionId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["SubscriptionId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["SubscriptionId"] = value;
            }
        }

        public static int InstituteId
        {
            get
            {
                if (HttpContext.Current.Session["InstituteId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["InstituteId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["InstituteId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the access token of the facebook user.
        /// </summary>
        /// <value>The value of the facebook user access token.</value>
        public static string AccessToken
        {
            get
            {
                if (HttpContext.Current.Session["AccessToken"] == null)
                {
                    return "AccessToken";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AccessToken"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AccessToken"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        /// <value>
        /// The plan.
        /// </value>        


        /// <summary>
        /// Gets or sets the facebook business ads Id.
        /// </summary>
        /// <value>The value of the facebook business ads Id.</value>
        public static string BusinessAdAccountID
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdAccountID"] == null)
                {
                    return "BusinessAdAccountID";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdAccountID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdAccountID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business campaign Id.
        /// </summary>
        /// <value>The value of the facebook business campaign Id.</value>
        public static string BusinessCampaignId
        {
            get
            {
                if (HttpContext.Current.Session["BusinessCampaignId"] == null)
                {
                    return "BusinessCampaignId";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessCampaignId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessCampaignId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business adset Id.
        /// </summary>
        /// <value>The value of the facebook business adset Id.</value>
        public static string BusinessAdsetId
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdsetId"] == null)
                {
                    return "BusinessAdsetId";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdsetId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdsetId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the facebook business ads Id.
        /// </summary>
        /// <value>The value of the facebook business ads Id.</value>
        public static string BusinessAdsID
        {
            get
            {
                if (HttpContext.Current.Session["BusinessAdsID"] == null)
                {
                    return "BusinessAdsID";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["BusinessAdsID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["BusinessAdsID"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public static int PageSize
        {
            get
            {
                if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session["PageSize"] != null)
                {
                    if (ConvertTo.Integer(HttpContext.Current.Session["PageSize"]) == 0)
                    {
                        HttpContext.Current.Session["PageSize"] = Configurations.PageSize;
                    }

                    return ConvertTo.Integer(HttpContext.Current.Session["PageSize"]);

                }
                else
                {
                    return 10;
                }
            }

            set
            {
                HttpContext.Current.Session["PageSize"] = value;
            }
        }
        public static int TestID
        {
            get
            {
                if (HttpContext.Current.Session["TestID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["TestID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["TestID"] = value;
            }
        }

        public static DateTime StartTime
        {
            get
            {
                if (HttpContext.Current.Session["StartTime"] == null)
                {
                    return DateTime.Now;
                }
                else
                {
                    return (DateTime)(HttpContext.Current.Session["StartTime"]);
                }
            }

            set
            {
                HttpContext.Current.Session["StartTime"] = value;
            }
        }

        public static int Result
        {
            get
            {
                if (HttpContext.Current.Session["Result"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["Result"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Result"] = value;
            }
        }

        public static bool IsAdmin
        {
            get
            {
                if (HttpContext.Current.Session["IsAdmin"] == null)
                {
                    return false;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["IsAdmin"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsLogin"] = value;
            }
        }

        public static string Otp
        {
            get
            {
                if (HttpContext.Current.Session["Otp"] == null)
                {
                    return "Otp";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Otp"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Otp"] = value;
            }
        }


        public static string OtpType
        {
            get
            {
                if (HttpContext.Current.Session["OtpType"] == null)
                {
                    return "OtpType";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["OtpType"]);
                }
            }

            set
            {
                HttpContext.Current.Session["OtpType"] = value;
            }
        }

        public static string Password
        {
            get
            {
                if (HttpContext.Current.Session["Password"] == null)
                {
                    return "Password";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["Password"]);
                }
            }

            set
            {
                HttpContext.Current.Session["Password"] = value;
            }
        }

        public static string IsVerified
        {
            get
            {
                if (HttpContext.Current.Session["IsVerified"] == null)
                {
                    return "Not Verified";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["IsVerified"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsVerified"] = value;
            }
        }

        public static string IsExists
        {
            get
            {
                if (HttpContext.Current.Session["IsExists"] == null)
                {
                    return "No";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["IsExists"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsExists"] = value;
            }
        }
        /// <summary>
        /// Gets or sets the admin user identifier.
        /// </summary>
        /// <value>The admin user identifier.</value>
        public static int AdminRoleID
        {
            get
            {
                if (HttpContext.Current.Session["AdminRoleID"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AdminRoleID"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AdminRoleID"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static int TempId
        {
            get
            {
                if (HttpContext.Current.Session["TempId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["TempId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["TempId"] = value;
            }
        }
        public static string ReferenceCode
        {
            get
            {
                if (HttpContext.Current.Session["ReferenceCode"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["ReferenceCode"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ReferenceCode"] = value;
            }
        }

        public static long OrderId
        {
            get
            {
                if (HttpContext.Current.Session["OrderId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Long(HttpContext.Current.Session["OrderId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["OrderId"] = value;
            }
        }


        /// <summary>
        /// Gets or sets the profile of the admin/subadmin user.
        /// </summary>       
        public static string UserProfile
        {
            get
            {
                if (HttpContext.Current.Session["UserProfile"] == null)
                {
                    return "UserProfile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["UserProfile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["UserProfile"] = value;
            }
        }

        public static bool CanAddAggregators
        {
            get
            {
                if (HttpContext.Current.Session["CanAddAggregators"] == null)
                {
                    return false;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["CanAddAggregators"]);
                }
            }

            set
            {
                HttpContext.Current.Session["CanAddAggregators"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Aggregator's identifier.
        /// </summary>
        /// <value>The Aggregator identifier.</value>
        public static int AggregatorId
        {
            get
            {
                if (HttpContext.Current.Session["AggregatorId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["AggregatorId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AggregatorId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Aggregator's Mobile.
        /// </summary>
        /// <value>The Aggregator Mobile.</value>
        public static string AggregatorMobile
        {
            get
            {
                if (HttpContext.Current.Session["AggregatorMobile"] == null)
                {
                    return "AggregatorMobile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AggregatorMobile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AggregatorMobile"] = value;
            }
        }



        /// <summary>
        /// Gets or sets the Aggregator's IMEI Number.
        /// </summary>
        /// <value>The Aggregator IMEI Number.</value>
        public static string AggregatorImeiNumber
        {
            get
            {
                if (HttpContext.Current.Session["AggregatorImeiNumber"] == null)
                {
                    return "AggregatorImeiNumber";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["AggregatorImeiNumber"]);
                }
            }

            set
            {
                HttpContext.Current.Session["AggregatorImeiNumber"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Aggregator's TodoDashboardMobile Number.
        /// </summary>
        /// <value>The Aggregator TodoDashboardMobile Number.</value>
        public static string TodoDashboardMobile
        {
            get
            {
                if (HttpContext.Current.Session["TodoDashboardMobile"] == null)
                {
                    return "TodoDashboardMobile";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["TodoDashboardMobile"]);
                }
            }

            set
            {
                HttpContext.Current.Session["TodoDashboardMobile"] = value;
            }
        }

        public static PermissionAccess DesignationPermissions
        {
            get
            {
                if (HttpContext.Current.Session["DesignationPermissions"] == null)
                {
                    return null;
                }
                else
                {
                    return (PermissionAccess)HttpContext.Current.Session["DesignationPermissions"];
                }
            }
            set
            {
                HttpContext.Current.Session["DesignationPermissions"] = value;
            }
        }


        public static bool IsSuperAdmin
        {
            get
            {
                if (HttpContext.Current.Session["IsSuperAdmin"] == null)
                {
                    return false;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["IsSuperAdmin"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsSuperAdmin"] = value;
            }
        }

        public static int ManufacturerId
        {
            get
            {
                if (HttpContext.Current.Session["ManufacturerId"] == null)
                {
                    return 0;
                }
                else
                {
                    return ConvertTo.Integer(HttpContext.Current.Session["ManufacturerId"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ManufacturerId"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the department name of the logged in user.
        /// </summary>
        public static string ManufacturerName
        {
            get
            {
                if (HttpContext.Current.Session["ManufacturerName"] == null)
                {
                    return "";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["ManufacturerName"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ManufacturerName"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the Manufacturer's IMEI Number.
        /// </summary>
        /// <value>The Manufacturer IMEI Number.</value>
        public static string ManufacturerImeiNumber
        {
            get
            {
                if (HttpContext.Current.Session["ManufacturerImeiNumber"] == null)
                {
                    return "ManufacturerImeiNumber";
                }
                else
                {
                    return ConvertTo.String(HttpContext.Current.Session["ManufacturerImeiNumber"]);
                }
            }

            set
            {
                HttpContext.Current.Session["ManufacturerImeiNumber"] = value;
            }
        }

        public static bool IsNewApp
        {
            get
            {
                if (HttpContext.Current.Session["IsNewApp"] == null)
                {
                    return false;
                }
                else
                {
                    return ConvertTo.Boolean(HttpContext.Current.Session["IsNewApp"]);
                }
            }

            set
            {
                HttpContext.Current.Session["IsNewApp"] = value;
            }
        }
    }
}