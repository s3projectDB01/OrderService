FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY MenuApp.OrderService/*.csproj ./MenuApp.OrderService/
COPY MenuApp.OrderService.EntityFramework/*.csproj ./MenuApp.OrderService.EntityFramework/
COPY MenuApp.OrderService.Logic/*.csproj ./MenuApp.OrderService.Logic/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY MenuApp.OrderService/. ./MenuApp.OrderService/
COPY MenuApp.OrderService.EntityFramework/. ./MenuApp.OrderService.EntityFramework/
COPY MenuApp.OrderService.Logic/. ./MenuApp.OrderService.Logic/
#
WORKDIR /app/MenuApp.OrderService
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
# make sure qrcodes can be generated
RUN apt-get update && apt-get install -y libgdiplus

WORKDIR /app 
#
COPY --from=build /app/MenuApp.OrderService/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "MenuApp.OrderService.dll"]