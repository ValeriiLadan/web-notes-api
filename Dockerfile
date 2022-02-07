#Get SDK Image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

#Copy and restore
COPY ./WebNotes.sln /app/
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p /app/${file%.*}/ && mv $file /app/${file%.*}/; done


RUN dotnet restore

#Publish
COPY . ./
RUN dotnet publish "CDC.WebNotes.Api/CDC.WebNotes.Api.csproj" -c Release -o out

#Final
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 5000 
COPY --from=build /app/out .

ENTRYPOINT ["/app/CDC.WebNotes.Api"]
