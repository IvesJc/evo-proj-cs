﻿namespace EvoSystems.Controllers.Exceptions;

public class InvalidDataException : Exception
{
    public InvalidDataException(string? message) : base(message)
    {
    }
}