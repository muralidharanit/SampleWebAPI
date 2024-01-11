using Models;
using SampleWebAPI.DTO;

namespace SampleWebAPI.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(User user);
    }
}
