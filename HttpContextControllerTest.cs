// using System;
// using System.Collections.Generic;
// using System.Threading.Tasks;
// using System.IO;
// using System.Security.Claims;

// namespace testConsole
// {
//     public class TestTest
//     {
//         private TestController GetTestController()
//         {
//             IConfigurationRoot configurationRoot = SystemConfig.GetHostConfig();
//             ILogger<Test> bamLog = new NullLogger<Test>();
//             ILogger<ApiAuthService> apiAuthServiceLog = new NullLogger<ApiAuthService>();
//             var services = new ServiceCollection();
//             var builder = new ConfigurationBuilder();
//             services.AddOptions();
//             services.Configure<AppSettings>(configurationRoot.GetSection("AppSettings"));
//             services.Configure<UnifyAuthOptions>(configurationRoot.GetSection("Auth:Unify"));
//             services.Configure<QKAuthenticationOptions>(configurationRoot.GetSection("Auth:Identity"));
//             services.AddDistributedMemoryCache();
//             services.AddCacheWrapper(options =>
//             {
//                 options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);
//             });
//             services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//             var sp = services.BuildServiceProvider();
//             ServiceLocator.Instance = sp;
//             var _Accessor = sp.GetRequiredService<IHttpContextAccessor>();
//             //HttpHelper.Configure(sp.GetRequiredService<IHttpContextAccessor>());
//             IOptions<AppSettings> settings = sp.GetRequiredService<IOptions<AppSettings>>();
//             IOptions<UnifyAuthOptions> authSettings = sp.GetRequiredService<IOptions<UnifyAuthOptions>>();
//             ITypedCache cache = sp.GetRequiredService<ITypedCache>();

//             IApiAuthService authService = new ApiAuthService(cache, authSettings, apiAuthServiceLog);
//             ITest bamService = new Test(authService, settings, bamLog);
//             QkDBContext _db = new QkDBContext();
//             IRepository<Room, long> _romRep = new QkRepository<Room, long>(_db);
//             IUserService userService = new UserService(_db, _romRep);

//             ILogger<AuthenticateService> authenticateLogger = new NullLogger<AuthenticateService>();
//             IOptions<QKAuthenticationOptions> authenticateSettings = ServiceLocator.Instance.GetRequiredService<IOptions<QKAuthenticationOptions>>();
//             IAuthenticateService _authService = new AuthenticateService(authenticateSettings, authenticateLogger);
//             var identityResult = GetLoginIdentityResult(_authService).Result;
//             _Accessor.HttpContext = new DefaultHttpContext();
//             _Accessor.HttpContext.RequestServices = ServiceLocator.Instance;
//             var claims = new List<Claim>
//                 {
//                     new Claim(ClaimTypes.Name,"1529")
//                 };

//             var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//             ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimIdentity);
//             _Accessor.HttpContext.User = new ClaimsPrincipal(claimIdentity);

//             SimpleError setError;
//             _Accessor.HttpContext.TrySetUserInfo(identityResult, out setError, new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(8) });
//             return new TestController(bamService, userService);
//         }

//         private async Task<IdentityResult> GetLoginIdentityResult(IAuthenticateService _authService)
//         {
//             LoginDTO loginDTO = new LoginDTO { UserName = "check", Password = "123456" };
//             var result = await _authService.AuthenticateAsync(loginDTO.UserName, loginDTO.Password);
//             return result;
//         }
//         [Fact]
//         public async Task TestGetList()
//         {
//             var controller = GetTestController();
//             var cityList = await controller.GetList();
//             var result = cityList.Should().BeOfType<List<CityRelatedWithBusinessAddressDTO>>().Subject;
//             result.Should().NotBeNull();
//         }

//     }
// }
