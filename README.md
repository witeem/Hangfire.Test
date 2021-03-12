## HandFire定时任务策略

> Hangfire是一个任务调度的组件，自带面板，可以操作正在运作的任务，可以看到执行情况，而且使用起来简单。



### HandFire+Redis

##### 引入Nuget包：

> Hangfire.AspNetCore
>
> Hangfire.Console
>
> Hangfire.Core
>
> Hangfire.Dashboard.BasicAuthorization
>
> Hangfire.Redis.StackExchange.StrongName
>
> Microsoft.VisualStudio.Web.BrowserLink


##### 在appsettings.json配置文件加入Redis链接

```Json
"ConnectionStrings": {
    "Redis": "127.0.0.1:6379,abortConnect=false,connectRetry=3,connectTimeout=3000,defaultDatabase=1,syncTimeout=3000,version=3.2.1,responseTimeout=3000"
  },
```



##### 在Startup.cs注入服务添加请求处理管道：

```C#
public void ConfigureServices(IServiceCollection services)
{
    //注入Hangfire服务
    services.AddHangfire(config => config.UseRedisStorage(Redis));
    services.AddHangfireServer();
    services.AddMvc().AddNewtonsoftJson(options => {
        //忽略循环引用
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //不使用驼峰样式的key
        options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver(); 
    });
}

 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
     if (env.IsDevelopment())
     {
         app.UseDeveloperExceptionPage();
         app.UseBrowserLink();
     }
     else
     {
         app.UseExceptionHandler("/Home/Error");
     }
     app.UseStaticFiles();
     app.UseRouting();
     app.UseHangfireServer();
     app.UseHangfireDashboard();
     BackgroundJob.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));
     app.UseEndpoints(endpoints =>
                      {
                          endpoints.MapControllers();
                          endpoints.MapHangfireDashboard();
                      });
 }
```



