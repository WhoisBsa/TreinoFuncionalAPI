using Amazon.DynamoDBv2.DataModel;
using AutoMapper;
using TreinoFuncionalAPI.Data.DTOs.Exercise;
using TreinoFuncionalAPI.Exceptions;
using TreinoFuncionalAPI.Models;

namespace TreinoFuncionalAPI.Services
{
    public class ExerciseService
    {
        private readonly IDynamoDBContext _dynamoDb;
        private readonly IMapper _mapper;

        public ExerciseService(IDynamoDBContext dynamoDb, IMapper mapper)
        {
            _dynamoDb = dynamoDb;
            _mapper = mapper;
        }

        public async Task<List<ReadExerciseDTO>> GetAll()
        {
            var exercises = await _dynamoDb.ScanAsync<Exercise>(default).GetRemainingAsync();

            List<ReadExerciseDTO> exercisesDTO = _mapper.Map<List<ReadExerciseDTO>>(exercises);

            return exercisesDTO;
        }

        public async Task<ReadExerciseDTO> GetById(Guid id)
        {
            var exercise = await _dynamoDb.LoadAsync<Exercise>(id);
            if (exercise == null) throw new ExerciseNotFoundException();

            ReadExerciseDTO exerciseDTO = _mapper.Map<ReadExerciseDTO>(exercise);
            
            return exerciseDTO;
        }

        public async Task<Exercise> Create(CreateExerciseDTO exerciseDTO)
        {
            Exercise exercise = _mapper.Map<Exercise>(exerciseDTO);

            exercise.Id = Guid.NewGuid();

            await _dynamoDb.SaveAsync(exercise);

            return exercise;
        }

        public async Task Update(Guid id, UpdateExerciseDTO exerciseDTO)
        {
            Exercise exercise = await _dynamoDb.LoadAsync<Exercise>(id);
            if (exercise == null) throw new ExerciseNotFoundException();

                _mapper.Map(exerciseDTO, exercise);

            await _dynamoDb.SaveAsync(exercise);
        }

        public async Task Delete(Guid id)
        {
            Exercise exercise = await _dynamoDb.LoadAsync<Exercise>(id);
            if (exercise == null) throw new ExerciseNotFoundException();

            await _dynamoDb.DeleteAsync(exercise);
        }
    }
}
