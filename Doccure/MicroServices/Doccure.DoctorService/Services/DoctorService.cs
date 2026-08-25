using AutoMapper;
using Doccure.DoctorService.Dtos.BranchDtos;
using Doccure.DoctorService.Dtos.DoctorDtos;
using Doccure.DoctorService.Entities;
using Doccure.DoctorService.Settings;
using MongoDB.Driver;
using System.Net.Http;

namespace Doccure.DoctorService.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMongoCollection<Doctor> _doctorCollection;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public DoctorService(IMongoCollection<Doctor> doctorCollection, IMapper mapper, HttpClient client)
        {
            _doctorCollection = doctorCollection;
            _mapper = mapper;
            _client = client;
        }

        public async Task CreateAsync(CreateDoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            await _doctorCollection.InsertOneAsync(entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _doctorCollection.DeleteOneAsync(x => x.DoctorId == id);
        }

        public async Task<List<ResultDoctorDto>> GetAllAsync()
        {
            var values = await _doctorCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDoctorDto>>(values);
        }

        public async Task<GetByIdDoctorDto> GetByIdAsync(string id)
        {
            var value = await _doctorCollection.Find(x => x.DoctorId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDoctorDto>(value);
        }

        public async Task<GetDoctorNameAndSurnameByıdDto> GetDoctorByIdAsync(string id)
        {
            var value = await _doctorCollection.Find(x => x.DoctorId == id).FirstOrDefaultAsync();

            var branch = await _client.GetFromJsonAsync<BranchDto>($"http://localhost:14971/api/Branches/GetBranch?id={value.BranchId}");

            return new GetDoctorNameAndSurnameByıdDto
            {
                DoctorId = value.DoctorId,
                Name = value.Name,
                Surname = value.Surname,
                BranchId = value.BranchId,
                BranchName = branch.BranchName
            };
        }

        public async Task UpdateAsync(UpdateDoctorDto dto)
        {
            var entity = _mapper.Map<Doctor>(dto);
            await _doctorCollection.ReplaceOneAsync(x => x.DoctorId == dto.DoctorId, entity);
        }
    }
}
