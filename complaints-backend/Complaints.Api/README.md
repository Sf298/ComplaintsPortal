
# Complaints API

## StartingSQL Server
```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=$sa_password" -e "MSSQL_PID=Evaluation" -p 1433:1433 -v mssqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Setting the connection string to secret manager
```powershell
dotnet user-secrets set "ConnectionStrings:ComplaintsStoreContext" "Server=192.168.86.247; Database=ComplaintsStore; User Id=sa; Password=$sa_password; TrustServerCertificate=True"
```