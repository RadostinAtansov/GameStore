namespace GameStore.Data
{
    using GameStore.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using System.Security.Claims;

    //public class ApplicationClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    //{
    //    public ApplicationClaimsPrincipalFactory(
    //        UserManager<ApplicationUser> userManager, 
    //        RoleManager<IdentityRole> roleManager, 
    //        IOptions<IdentityOptions> options) 
    //        : base(userManager, roleManager, options)
    //    {}

    //    public async override Task<ClaimsPrincipal>CreateAsync(ApplicationUser user)
    //    {
    //        var principal = await base.CreateAsync(user);
    //        if (!string.IsNullOrWhiteSpace(user.FirstName))
    //        {
    //            ((ClaimsIdentity)principal.Identity).AddClaims(new[]
    //            {
    //                new Claim(ClaimTypes.GivenName, user.FirstName)
    //            });
    //        }
    //        if (!string.IsNullOrWhiteSpace(user.LastName))
    //        {
    //            ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
    //                new Claim(ClaimTypes.Surname, user.LastName),
    //            });
    //        }

    //        return principal;
    //    }
    //}
}