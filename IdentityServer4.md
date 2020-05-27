# IdentityServer4

Authentication:身份验证; 认证；鉴定

Authorization:授权

## Client Credentials

客户端认证代码

```c#
  public void ConfigureServices(IServiceCollection services)
  {                       
      services.AddControllers();
      services.AddAuthentication("Bearer")
      .AddIdentityServerAuthentication(
          options =>
          {
              options.Authority = "http://localhost:5000"; //权限验证url
              options.RequireHttpsMetadata = false;//是否开启https
              options.ApiName = "api";
          });
      //services.AddAuthentication("Bearer")
      //    .AddJwtBearer("Bearer", options =>
      //    {
      //        options.Authority = "http://localhost:5000";
      //        options.RequireHttpsMetadata = false;
      //        options.Audience = "api";
      //    });

   }
```

```c#
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
     if (env.IsDevelopment())
     {
     	app.UseDeveloperExceptionPage();
     }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();//认证  必须放在授权前面，否则无效
    app.UseAuthorization();//授权

    app.UseEndpoints(endpoints =>
    {
    	endpoints.MapControllers();
    });
}
```

**注意点：app.UseAuthentication()必须放在app.UseAuthorization()  (认证必须放在授权的前面)**

![image-20200524194424625](image-20200524194424625.png)



# .NET项目迁移到.NET Core操作指南

地址:http://www.10qianwan.com/articledetail/430496.html



# asp.net core系列 Identity介绍

地址：https://www.jianshu.com/p/5464f2ef7a6f



# 精彩文章

https://www.cnblogs.com/jesse2013/

http://www.jessetalk.cn/