# Use SDK since you're compiling and running in same container
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set working directory
WORKDIR /app

# Copy project file and restore dependencies
COPY worker.csproj ./
RUN dotnet restore

# Copy the remaining source files
COPY . ./

# Build the application
RUN dotnet build -c Release

# Run the application (Release mode)
CMD ["dotnet", "run", "--configuration", "Release"]
