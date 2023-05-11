using AutoMapper;
using TreinoFuncionalAPI.Data.DTOs.Exercise;
using TreinoFuncionalAPI.Models;

namespace TreinoFuncionalAPI.Profiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<CreateExerciseDTO, Exercise>();
            CreateMap<Exercise, ReadExerciseDTO>();
            CreateMap<UpdateExerciseDTO, Exercise>();
        }
    }
}
