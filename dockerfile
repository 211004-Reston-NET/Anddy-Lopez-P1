#First our virtual OS will need the .NET 5.0 SDK
#We can utilize docker hub to access one of the published images from .NET themselves
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

#Setting our working directory
WORKDIR /app

#Time to copy our projects and paste it to the working directory
# * is the wildcard meaning it'll grab anything in your folder that has .sln extension
COPY *.sln ./
COPY P0BL/*.csproj P0BL/
COPY P0DL/*.csproj P0DL/
COPY P0Models/*.csproj P0Models/
COPY P0Test/*.csproj P0Test/
COPY P0WebUI/*.csproj P0WebUI/

# We need to build/restore our files (bin & obj)
RUN cd P0WebUI && dotnet restore

# copy the source files
COPY . ./
#cmd /bin/bash It was too check if it copied everything and restored everything

# We need to publish the application and its dependencies to a folder for deployment
RUN dotnet publish P0WebUI -c Release -o publish --no-restore

#We change our base image to be the runtime since we already used the sdk to create the application itself
#This is to use a lot less memory
FROM mcr.microsoft.com/dotnet/runtime:5.0 as runtime 

WORKDIR /app
COPY --from=build /app/publish ./

CMD ["dotnet", "P0WebUI.dll"]