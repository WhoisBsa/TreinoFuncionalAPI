using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace TreinoFuncionalAPI.Data.DTOs.Exercise
{
    public class CreateExerciseDTO
    {
        [DynamoDBProperty("name")]
        [Required(ErrorMessage = "O nome do exercício é obrigatório")]
        [StringLength(50, ErrorMessage = "O tamanho do nome do exercício não pode exceder 50 caracteres")]
        public string Name { get; set; }
        [DynamoDBProperty("description")]
        [StringLength(100, ErrorMessage = "O tamanho da descrição não pode exceder 100 caracteres")]
        public string Description { get; set; }
        [DynamoDBProperty("example_url")]
        public string ExampleUrl { get; set; }
        [DynamoDBProperty("category")]
        public string Category { get; set; }
    }
}
