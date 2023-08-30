namespace GameStore.Data.Models
{
    using System.Security.Claims;
    using System.Security.Principal;

    public static class IdentityExtentions
    {
        public static string FirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.GivenName);
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string LastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst(ClaimTypes.Surname);           
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}