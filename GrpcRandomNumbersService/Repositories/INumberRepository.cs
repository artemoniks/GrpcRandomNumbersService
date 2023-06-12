namespace GrpcRandomNumbersService.Repositories;

public interface INumberRepository
{
    bool TryAddNumber(long number);
}