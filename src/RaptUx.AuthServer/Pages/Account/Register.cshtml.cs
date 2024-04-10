using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.Account.Web.Pages.Account;
using Volo.Abp.Identity;

namespace RaptUx.Pages.Account;

public class CustomRegisterModel(
    IAccountAppService accountAppService,
    IAuthenticationSchemeProvider schemeProvider,
    IOptions<AbpAccountOptions> accountOptions,
    IdentityDynamicClaimsPrincipalContributorCache contributorCache)
    : RegisterModel(accountAppService, schemeProvider, accountOptions, contributorCache);