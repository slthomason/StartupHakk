//Benchmark
public class ParallelBenchmarking
{
    [Benchmark]
    public int[] ArrayForEach()
    {
        var array = new int[1_000_000];
        for (var i = 0; i < 1_000_000; i++)
        {
            array[i] = i;
        }
        return array;
    }
    [Benchmark]
    public int[] ParallelForEach()
    {
        var array = new int[1_000_000];
        Parallel.For(0, 1_000_000, i =>
        {
            array[i] = i;
        });
        return array;
    }
}





//OneOf
[HttpGet]
public async Task<IActionResult> AllPortfolio()
{
    var result = await GetStocks();
    return result.Match(stocks =>
        {
            _logger.LogInformation("");
            return Ok(stocks);
        },
        error =>
        {
            _logger.LogError("Failed to get stocks {@error}", error);
            return Ok(error);
        });
}

private async Task<OneOf<List<StockEntity>, Error>> GetStocks()
{
    var stocks = await _stocksRepository.GetStocks();
    if (stocks == null)
    {
        return new Error(){ Message = "Not Found"};
    }

    return stocks;
}




//AutoFixture
[Fact]
public void AutoFixtureTest()
{
    // Arrange
    var fixture = new Fixture().Customize(new AutoMoqCustomization());

    var expectedResult = fixture.Create<string>();
    var sut = fixture.Create<StockService>();
    // Act
    var result = sut.GetStocks();
    // Assert
    Assert.Equal(expectedResult, result);
}








//FluentAssertion
//Without FluentAssertions
Assert.Equal(expectedResult, result);
//With FluentAssertions
result.Should().Be(expectedResult);











//FluentValidations
public class StockValidator : AbstractValidator<Stock>
{
    public StockValidator()
    {
        RuleFor(o => o.Amount).GreaterThan(0);
        RuleFor(o => o.AccountId).NotEmpty();
        RuleFor(o => o.ClientId).NotEmpty();
    }
}



















//Nodatime
// Instant represents time from epoch
Instant now = SystemClock.Instance.GetCurrentInstant();

// Convert an instant to a ZonedDateTime
ZonedDateTime nowInIsoUtc = now.InUtc();

// Create a duration
Duration duration = Duration.FromMinutes(3);

// Add it to our ZonedDateTime
ZonedDateTime thenInIsoUtc = nowInIsoUtc + duration;

// Time zone support (multiple providers)
var london = DateTimeZoneProviders.Tzdb["Europe/London"];

// Time zone conversions
var localDate = new LocalDateTime(2012, 3, 27, 0, 45, 00);
var before = london.AtStrictly(localDate);