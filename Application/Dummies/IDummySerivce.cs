namespace Application.Dummies
{
    using Application.Dummies.DTO;
    using CleanArchitecture.Application.Common.Models;
    using Domain.Dummy;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    public interface IDummySerivce
    {
        Task<Result> GetDummiesAsync();
        Task<Dummy> GetAppSettingByIdAsync(int id);
        Task<Dummy> UpdateAsync(Dummy appSetting);
        Task<bool> DeleteAsync(int id);
        Task<Result> AddAsync(AddDummyDto addDummy);
    }
}
