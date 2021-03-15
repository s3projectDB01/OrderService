FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app 
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY MenuApp.OrderService/*.csproj ./MenuApp.OrderService/
#
RUN dotnet restore 
#
# copy everything else and build app
COPY MenuApp.OrderService/. ./MenuApp.OrderService/
#
WORKDIR /app/MenuApp.OrderService
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app 
#
COPY --from=build /app/MenuApp.OrderService/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "MenuApp.OrderService.dll"]