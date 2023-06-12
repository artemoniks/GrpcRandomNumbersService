using System.Collections.Concurrent;

namespace GrpcRandomNumbersService.Repositories;

public class NumberRepository : INumberRepository
{
    private readonly ConcurrentDictionary<long, byte> _numbers = new();

    public bool TryAddNumber(long number)
    {
        return _numbers.TryAdd(number, 0);
    }
}