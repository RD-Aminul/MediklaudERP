using mediklaud_api.FormQuery.SignIn;
using mediklaud_api.Service.SignIn;

namespace mediklaud_api.Interface.SignIn
{
    public interface ISignInService
    {
        Task<String> getUser(GetUserDataQuery getUserDataQuery);
    }
}
