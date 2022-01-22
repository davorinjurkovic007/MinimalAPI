using DevNot21.Entities;

namespace DevNot21.Service
{
    public interface ITokenService
    {
        string GetToken(DbUser user);
    }
}
