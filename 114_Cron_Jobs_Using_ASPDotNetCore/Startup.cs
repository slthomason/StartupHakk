 public void ConfigureServices(IServiceCollection services)
 {
     // other DI registrations...
     // register CronJobs below
     services.AddCronJob<MyCronJob1>(c =>
     {
         c.TimeZoneInfo = TimeZoneInfo.Local;
         c.CronExpression = @"*/5 * * * *";
     });
     services.AddCronJob<MyCronJob2>(c =>
     {
         c.TimeZoneInfo = TimeZoneInfo.Local;
         c.CronExpression = @"* * * * *";
     });
     services.AddCronJob<MyCronJob3>(c =>
     {
         c.TimeZoneInfo = TimeZoneInfo.Local;
         c.CronExpression = @"50 12 * * *";
     });
 }