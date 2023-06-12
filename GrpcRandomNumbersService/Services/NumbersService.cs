using Google.Protobuf.WellKnownTypes;
using Grpc.Core;

namespace GrpcRandomNumbersService.Services;

public class NumbersService : Numbers.NumbersBase
{
    private readonly ILogger<NumbersService> _logger;
    private readonly IRandomNumberService _randomNumberService;

    public NumbersService(ILogger<NumbersService> logger, IRandomNumberService randomNumberService)
    {
        _logger = logger;
        _randomNumberService = randomNumberService;
    }

    public override Task<NumberReply> GetNumber(Empty request, ServerCallContext context)
    {
        var nextNumber = _randomNumberService.GetNextNumber();
        var userAgent = context.RequestHeaders.GetValue("user-agent");
        
        _logger.LogDebug("NextNumber - {NextNumber}, context - {UserAgent}", nextNumber, userAgent);

        var jsonResponse = Value.Parser.ParseJson(@"{""number"": """ + nextNumber + @"""}");
        
        _logger.LogTrace("JsonResponse - {JsonResponse}", jsonResponse.ToString());

        return Task.FromResult(new NumberReply
        {
            Data = jsonResponse
        });
    }
}