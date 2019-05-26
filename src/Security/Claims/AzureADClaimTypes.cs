namespace Awaoa.Core.Security.Claims
{
    public static class AzureADClaimTypes
    {
        /// <summary>
        /// The object identifier for the user in AAD.
        /// This value is the immutable and non-reusable identifier of the user.
        /// Use this value, not email, as a unique identifier for users; email addresses can change.
        /// If you use the Azure AD Graph API in your app, object ID is that value used to query profile information.
        /// <remark>
        /// Example: "59f9d2dc-995a-4ddf-915e-b3bb314a7fa4"
        /// </remark>
        /// </summary>
        public const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        /// <summary>
        /// Tenant ID. This value is a unique identifier for the tenant in Azure AD.
        /// Example: "b9bd2162-77ac-4fb2-8254-5c36e9c0a9c4"
        /// </summary>
        public const string TenantId = "http://schemas.microsoft.com/identity/claims/tenantid";

        /// <summary>
        /// The user's display name. Example: "Alice A."
        /// </summary>
        public const string Name = "name";

        /// <summary>
        /// A human readable display name of the user. Example: "alice@contoso.com"
        /// </summary>
        public const string UniqueName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";

        /// <summary>
        /// User principal name. Example: "alice@contoso.com"
        /// </summary>
        public const string UserPrincipalName = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn";
    }
}