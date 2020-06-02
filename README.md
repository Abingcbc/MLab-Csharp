# MLab-Csharp

## 程序集

- [ ] API业务

- [ ] 服务器注册中心

- [ ] 容器管理

- [ ] token加密解密（共享程序集）

- [ ] hdfs文件管理 （c++/CLR)

- [ ] 用户密码加密 （COM组件）

- [ ] 系统监控 （Win32 dll）




EF DB-first

```
dotnet tool install --global dotnet-ef --version 3.0.0


dotnet ef dbcontext scaffold "Server=localhost;User Id=root;Password= 3103Diaozuida ;Database=mlab" "Pomelo.EntityFrameworkCore.MySql" -c MyDbContext -o Models
```

