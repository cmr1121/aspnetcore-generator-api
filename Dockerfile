# Build stage
FROM microsoft/dotnet:2.1-sdk as build-env

WORKDIR /generator

# restore
COPY api/api.csproj ./api/
RUN dotnet restore api/api.csproj

COPY tests/tests.csproj ./tests/
RUN dotnet restore tests/tests.csproj

# copy src
COPY . .

# test
RUN dotnet test tests/tests.csproj

# publish
RUN dotnet publish api/api.csproj -o /publish

# Runtime stage
FROM microsoft/dotnet:2.1-runtime
COPY --from=build-env /publish /publish
WORKDIR /publish
ENTRYPOINT ["dotnet", "api.dll"]