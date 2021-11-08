客户端模式

# 安装模板
	dotnet  new -i IdentityServer4.Templates

# 添加模板项目
	dotnet new is4empty -n Authorization.IdentityServer

# 添加解决方案
	dotnet  new sln -n Authorization.IdentityServer.Project
	dotnet sln add Authorization.IdentityServer\Authorization.IdentityServer.csproj

发现文档： https://localhost:5001/.well-known/openid-configuration