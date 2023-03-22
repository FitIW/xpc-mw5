# Code first approach

**do not forget** to add connections tring to user secrets or ot appsettings.json or pass it like cmd argument

`secrets.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(LocalDB)\\MSSQLLocalDB;Database=TestABCDEFGH;Trusted_Connection=True;"
  }
}

```

## Add migration

```ps1
dotnet ef migrations add "YOUR migration name"
```

## Update database

```ps1
dotnet ef database update
```
