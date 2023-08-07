using Amazon.DynamoDBv2.DataModel;
using System.ComponentModel.DataAnnotations;

namespace TreinoFuncionalAPI.Models
{
    [DynamoDBTable("Exercises")]
    public class Exercise
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }
        [DynamoDBProperty("name")]
        [Required(ErrorMessage = "O nome do exercício é obrigatório")]
        [MaxLength(50, ErrorMessage = "O tamanho do nome do exercício não pode exceder 50 caracteres")]
        public string? Name { get; set; }
        [DynamoDBProperty("description")]
        [MaxLength(100, ErrorMessage = "O tamanho da descrição não pode exceder 100 caracteres")]
        public string? Description { get; set; }
        [DynamoDBProperty("example_url")]
        public string? ExampleUrl { get; set; }
        [DynamoDBProperty("category")]
        [MaxLength(100, ErrorMessage = "O tamanho da categoria não pode exceder 50 caracteres")]
        public string? Category { get; set; }
    }
}
