namespace Schoolhub.Domain.Common;

public abstract class DomainException(string message, Exception? inner = null) 
    : Exception(message, inner);