namespace Application.Dummies
{
    using Application.Common.Interfaces;
    using Application.Dummies.DTO;
    using AutoMapper;
    using CleanArchitecture.Application.Common.Models;
    using Domain.Dummy;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class DummySerivce : IDummySerivce
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Dummy> _dummyRepository;
        private readonly IMapper _mapper;

        public DummySerivce(IUnitOfWork unitOfWork, IRepository<Dummy> dummyRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _dummyRepository = dummyRepository;
            _mapper = mapper;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Dummy> GetAppSettingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result> GetDummiesAsync()
        {
            var dummies = (await _dummyRepository.GetAllAsync()).ToList();
            var dummyListDto = _mapper.Map<List<GetDummyListDto>>(dummies);
            return Result.Success(dummyListDto);
        }

        public Task<Dummy> UpdateAsync(Dummy appSetting)
        {
            throw new NotImplementedException();
        }
        public async Task<Result> AddAsync(AddDummyDto addDummy)
        {
            var dummy = _mapper.Map<Dummy>(addDummy);
          await  _dummyRepository.Add(dummy);
            await _unitOfWork.CommitAsync();
            return Result.Success(dummy.Id);
        }
    }
}
