FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
COPY ./publish /publish
WORKDIR /publish
COPY *.csproj ./
RUN dotnet restore
EXPOSE 5000
EXPOSE 5001
ENTRYPOINT ["dotnet", "ApiItau.Api.dll"]