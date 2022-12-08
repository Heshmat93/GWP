namespace Application.Dummies
{
    using Application.Common.Interfaces;
    using Application.Dummies.DTO;
    using Application.Models;
    using AutoMapper;
    using CleanArchitecture.Application.Common.Models;
    using Domain.Dummy;

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
            var x = new PaginationInputModel<Dummy>();
            var dummies = (await _dummyRepository.GetPaginatedByAsync(x));
            var dummyListDto = _mapper.Map<List<GetDummyListDto>>(dummies.Items);
            var y = new PaginatedList<GetDummyListDto>(dummyListDto, dummies.TotalCount, dummies.PageNumber, x.PageSize);
            return Result.Success(y);
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
