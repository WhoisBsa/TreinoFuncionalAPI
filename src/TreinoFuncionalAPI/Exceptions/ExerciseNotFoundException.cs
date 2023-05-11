namespace TreinoFuncionalAPI.Exceptions
{
    public class ExerciseNotFoundException : Exception
    {
        public ExerciseNotFoundException(string? message = "Exercício não encontrado.") : base(message)
        {
        }
    }
}
