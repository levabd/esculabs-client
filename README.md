# balder-client
Balder .NET Client application

## Solutions
* **Client.sln** - Main client
* **ResearchClient.sln** - Verification algorithm development, research and testing

## Building Client

###Software requirements
- Visual Studio 2015 (Community Edition)
- PostgreSQL Server (>= v9.4)
- MongoDB Server (>= v3.0.6)

###Notes
PostgeSQL default user password should be set to `password`. Otherwise, you can change connection string in `App.config` file:

```
...
  <connectionStrings>
  ...
    <add name="pgContext" connectionString="PORT=5432;TIMEOUT=15;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;COMPATIBLE=2.2.5.0;DATABASE=balder;HOST=localhost;PASSWORD=password;USER ID=postgres" providerName="Npgsql" />
  ...
  </connectionStrings>
...
```

Open `Client.sln` solution file in Visual Studio, build and launch application. NuGet dependencies and PgSQL database migrations will be applied upon first application startup.
