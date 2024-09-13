namespace EvoSystems.Controllers.Exceptions;

public class InternalServerErrorException : Exception
{
    public InternalServerErrorException(string? message) : base(message)
    {
    }
}