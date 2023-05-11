using Amazon.DynamoDBv2.DataModel;

namespace TreinoFuncionalAPI.Data.DTOs.Exercise
{
    public class ReadExerciseDTO
    {
        [DynamoDBHashKey("id")]
        public Guid Id { get; set; }
        [DynamoDBProperty("name")]
        public string Name { get; set; }
        [DynamoDBProperty("description")]
        public string Description { get; set; }
        [DynamoDBProperty("example_url")]
        public string ExampleUrl { get; set; }
        [DynamoDBProperty("category")]
        public string Category { get; set; }
    }
}
