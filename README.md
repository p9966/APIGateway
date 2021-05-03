# Codebus.apigateway

`codebus.apigateway`是一款基于`.NetCore + Ocelot`开发的一款智能API网关。在保留了`Ocelot`现有功能的情况下，我们新增了配置存储/读取方式、缓存配置存储/读取方式、自定义限流、鉴权、熔断等。 新增配置定时生效、配置实施修改生效、UI界面管理、调用链、集群功能等。`codebus.apigateway` 简化了`Ocelot` 的配置方式（通过管理界面即可完成服务管理），如果说你们使用的技术栈为.NetCore，并且有想上微服务架构的意向，那么`codebus.apigateway`将会是一个不错的选择。

# 框架组件介绍

- codebus.apigateway.core：Api核心和Ocelot扩展组件
  - DependencyInjection：依赖注入管理
  - Entities：网关配置实体
  - GatewayConfigurationRepository：网关配置仓库
  - Middleware：中间件
- codebus.apigateway.portal：提供网关管理WebApi

# 代码片段

```c#
public static void AddCore(this IServiceCollection services, IConfiguration configuration)
{
    services.AddDbContext<GatewayDbContext>(options =>
                                            {
                                                options.UseLazyLoadingProxies();
                                                options.UseMySQL(configuration["MySql:ConnectionString"], x => x.MigrationsAssembly("codebus.apigateway.portal"));
                                            }, ServiceLifetime.Scoped);


    services.AddOcelot().AddConfigurationRepository(option =>
                                                    {
                                                        // 启用配置自动更新，每30秒更新一个路由配置
                                                        option.AutoUpdate = true;
                                                        option.UpdateInterval = 30 * 1000;
                                                    });
}
```



# 技术栈

- 后端
  - C#
  - .NetCore(3.x)
  - Ocelot(15.0.7)
  - EFCore
- 前端
  - JavaScript/JQuery
  - CSS
  - HTML

# 项目进度

关于网关配置参数请参Ocelot官方[文档](https://ocelot.readthedocs.io/en/latest/)。

截止到目前，codebus.apigateway框架已经可以满足API网关的基本功能了，计划中的功能点，均已得到较高水准的实现，体功能点完成进度如下所示：

- [x] 通过数据库动态配置网关
- [x] 通过API动态获取/配置网关
- [x] 路由
- [x] 聚合请求
- [x] 结合Consul或Eureka做服务发现
- [x] WebSocket
- [x] Kubernetes
- [x] 熔断限流
- [x] 服务治理
- [x] 负载均衡
- [x] 标头/方法/查询字符串/申明转换
- [ ] 记录/跟踪/关联
- [ ] UI管理界面
- [ ] 缓存配置集群部署
- [ ] 鉴权

# 贡献

我们很乐意接受来自社区的贡献，所以有任何建议或意见请及时评论，当然更欢迎你也能在`Codebus.apigateway`中留下代码。