# Balder Client

## Solutions
* **Client.sln** - Main client
* **ResearchClient.sln** - Verification algorithm development, research and testing

##Building Client

###Software requirements
- Visual Studio 2015 (Community Edition) [ [Download](https://go.microsoft.com/fwlink/?LinkId=532606&clcid=0x409) ]
- Accord.NET Framework (v3.0.2) [ [Download](https://github.com/accord-net/framework/releases/download/v3.0.0/Accord.NET-3.0.2-installer.exe) ]
- PostgreSQL Server (>= v9.4) [ [Download](http://www.enterprisedb.com/postgresql-944-installers-win64?ls=Crossover&type=Crossover) ]
- MongoDB Server (>= v3.0.6) [ [Download](https://www.mongodb.org/dr/fastdl.mongodb.org/win32/mongodb-win32-x86_64-2008plus-ssl-3.0.6-signed.msi/download) ]

###Additional links
- [MongoDB Windows Service configuration guide](http://docs.mongodb.org/manual/tutorial/install-mongodb-on-windows/#configure-a-windows-service-for-mongodb)
- [MongoVUE](http://www.mongovue.com/) (MongoDB GUI client)
- [pgAdmin](http://www.pgadmin.org/index.php) (PostgreSQL GUI client, could also be installed via PostgeSQL Server installer)

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
