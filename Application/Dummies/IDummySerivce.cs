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
        Task<Result> GetDummyAsync(int id);
        Task<Result> UpdateAsync(UpdateDummyDto updateDummyDto);
        Task<bool> DeleteAsync(int id);
        Task<Result> AddAsync(AddDummyDto addDummy);
    }
}
