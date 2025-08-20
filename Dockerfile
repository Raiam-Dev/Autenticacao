FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build 
WORKDIR /app 
COPY *.sln . 
COPY FirebaseStudio/*.csproj ./FirebaseStudio/ 
RUN dotnet restore 
COPY FirebaseStudio/. ./FirebaseStudio/ 
WORKDIR /app/FirebaseStudio 
RUN dotnet publish -c Release -o out 
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime 
WORKDIR /app 
COPY --from=build /app/FirebaseStudio/out ./ 
EXPOSE 80 
ENTRYPOINT ["dotnet", "FirebaseStudio.dll"] 
