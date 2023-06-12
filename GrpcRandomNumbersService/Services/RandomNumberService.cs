using GrpcRandomNumbersService.Repositories;

namespace GrpcRandomNumbersService.Services;

public class RandomNumberService : IRandomNumberService
{
    private readonly INumberRepository _numberRepository;

    public RandomNumberService(INumberRepository numberRepository)
    {
        _numberRepository = numberRepository;
    }
    
    public long GetNextNumber()
    {
        var nextNumber = Random.Shared.NextInt64();

        while (!_numberRepository.TryAddNumber(nextNumber))
        {
            nextNumber = Random.Shared.NextInt64();
        }

        return nextNumber;
    }
}