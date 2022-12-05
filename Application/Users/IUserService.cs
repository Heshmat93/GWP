namespace Application.Users
{
    using CleanArchitecture.Application.Common.Models;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<Result> Authenticate(string userName, string passWord);
    }
}
