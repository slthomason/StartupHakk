public void BadAddUserAsync(User user); //You should not do this
public Task GoodAddUserAsync(User user); //Do this instead!

public Task<int> BadComputeDiscountAsync(User user) => Task.Run(() 
    => 0.3 * user.BaskedAmount);

    public Task<int> BestComputeDiscountAsync(User user) 
    => new ValueTask<int>(0.3 * user.BaskedAmount);

    public Task<int> BestComputeDiscountAsync(User user) 
    => Task.FromResult(0.3 * user.BaskedAmount);



public Task<int> BadAddUserAsync(User user)
{
    return _client.AddUser(user).ContinueWith(task =>
    {
        return ++totalUserCount;
    });
}

public async Task<bool> GoodAddUserAsync(User user)
{
    await _client.AddUser(user);
    return ++totalUserCount;
}

public class HealthCheckService : IBackgroundService
{
    public async Task BadHandleAsync(Client client, CancellationToken token)
    {
        while(true)
        {
            await Task.Run(()=> client.CheckHealth(token));
            await Task.Delay(500);
        }
    }

    public Task GoodHandleAsync(Client client, CancellationToken token)
    {
       var t = new Thread(()=> client.CheckHealth(token))
       {
          IsBackground = true //important to keep it alive
       };
       t.Start();
       return Task.CompletedTask;
    }
}

public bool BadAddUser1(User user)
  => _client.AddAsync(user).Result; //Do not do this

public bool BadAddUser2(User user) //Do not do this
{
   var addUserTask= _client.AddAsync(user);
   addUserTask.Wait();
   return addUserTask.Result;
}

public async Task<bool> GoodAddUserAsync(User user) //Do this instead
  => await _client.AddAsync(user);

public class TimerHealthCheckService
{
    private readonly Timer _badTimer;

    public TimerHealthCheckService()
      => _badTimer = new Timer(BadCheckHealth, 100, 200);

    // this is bad
    public void BadCheckHealth() => client.CheckHealth(...);

    // this is a bit better
    public void BetterCheckHealth() => DoHealthCheck();

    private async Task DoHealthCheck()=> await client.CheckHealth(...);
}


public class BetterTimerHealthCheckService
{
    private readonly PeriodicTimer _timer;

    public BetterTimerHealthCheckService()
    {
        _timer = new PeriodicTimer(100);
        Task.Run(DoHealthCheck);
    }

    private async Task DoHealthCheck()
    {
        while(await _timer.WaitForNextTickAsync())
            await client.CheckHealth(...);
    }
}

public class MessagePublisher
{
    public static void Publish(Action action) 
    {
        //...
    }
}

var publisher = new MessagePublisher();
publisher.Publish(async () => 
{
    await _client.PublishAsync(messages);
});

//Instead
public class MessagePublisher
{
    public static void Publish(Func<Task> action) 
    {
        //...
    }
}


// this calls Dispose() under the hood
using (var stream = new StreamWriter(httpResponse))
{
   await stream.WriteAsync("Hello World");
}

// this calls DisposeAsync() under the hood
await using (var stream = new StreamWriter(httpResponse))
{
   await stream.WriteAsync("Hello World");
}

// this calls DisposeAsync() under the hood
using (var stream = new StreamWriter(httpResponse))
{
   await stream.WriteAsync("Hello World");
   stream.FlushAsync();
}

public Task<int> BadUpdateCountersAsync() 
  => UpdateCountersAsync();

  public async Task<int> GoodUpdateCountersAsync() 
  => await UpdateCountersAsync();