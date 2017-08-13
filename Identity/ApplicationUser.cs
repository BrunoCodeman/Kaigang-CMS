using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace kaigang.Identity
{
    public class ApplicationUser : IdentityUser<string, IdentityUserLogin<string>, IdentityUserRole<string>, IdentityUserClaim<string>>
    {


    }
}