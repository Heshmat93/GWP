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

        public async Task<Result> GetDummyAsync(int id)
        {
            var dummy = await _dummyRepository.GetByIdAsync(id);
            return Result.Success(_mapper.Map<GetDummyDetailsDto>(dummy));

        }

        public async Task<Result> GetDummiesAsync()
        {
            var dummies = (await _dummyRepository.GetAllAsync()).ToList();
            var dummyListDto = _mapper.Map<List<GetDummyListDto>>(dummies);
            return Result.Success(dummyListDto);
        }

        public async Task<Result> UpdateAsync(UpdateDummyDto updateDummyDto)
        {
            var existed = await _dummyRepository.GetByIdAsync(updateDummyDto.Id);
            if (existed is null)
            {
                return Result.Failure(new string[] { "TheItemNotExisted" });
            }
            var dummy = _mapper.Map<Dummy>(updateDummyDto);

            await _dummyRepository.Update(dummy);
            await _unitOfWork.CommitAsync();
            return Result.Success(dummy.Id);
        }
        public async Task<Result> AddAsync(AddDummyDto addDummy)
        {
            var dummy = _mapper.Map<Dummy>(addDummy);
            await _dummyRepository.Add(dummy);
            await _unitOfWork.CommitAsync();
            return Result.Success(dummy.Id);
        }
    }
}
