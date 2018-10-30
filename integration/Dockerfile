FROM microsoft/dotnet:2.1-sdk as build-env
WORKDIR /integration

# restore
COPY integration.csproj .
RUN dotnet restore 

# copy src
COPY . .
ENTRYPOINT [ "dotnet", "test" ]