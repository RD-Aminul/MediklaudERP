using mediklaud_api.FormQuery.SignIn;
using mediklaud_api.Interface.SignIn;
using Microsoft.AspNetCore.Mvc;

namespace mediklaud_api.Controllers.SignIn
{
    [Route("api/[controller]")]
    [ApiController]

    public class SignInController : ControllerBase
    {
        private readonly ISignInService signIn;
        public SignInController(ISignInService signIn)
        {
            this.signIn = signIn;
        }

        [HttpGet]
        [Route("GetUserList")]
        public async Task<String> GetUserData([FromQuery] GetUserDataQuery getUserDataQuery)
        {
            return await signIn.getUser(getUserDataQuery);
        }
    }
}
