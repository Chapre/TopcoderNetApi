using TopcoderNetApi.Model;

namespace TopcoderNetApi.Services.Users
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Generates the JWT.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        string GenerateJwt(User user);
    }
}
