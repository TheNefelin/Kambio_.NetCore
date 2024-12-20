# Kambio WebApi .NET Core 7

## Menu
- [Ir a Dependencias](#dependencias)
- [Ir a Configurar Cors](#configurar-cors)
- [Ir a Conexion BD](#conexion-db)

### Dependencias
```
```

## Configurar Cors
* Program.cs
```
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowCredentials();
    options.SetIsOriginAllowed(origin => true);
});
```

## Conexion BD
* appsettings.json y/o appsettings.Development.json
```
"ConnectionStrings": {
    "RutaWebSQL": "Data Source=Servidor; Initial Catalog=db_testing; User ID=testing; Password=testing; TrustServerCertificate=True;",
    "RutaSQL": "Server=localhost; Database=db_testing; User ID=testing; Password=testing; TrustServerCertificate=True;"
},
"JWT": {
    "Key": "TheKeyTheKeyTheKeyTheKeyTheKeyTheKey",
    "Issuer": "http://id.domain.com",
    "Audience": "http://domain.com",
    "ExpireMin": 60
}
```
* Program.cs
```
builder.Services.AddDbContext<EntityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RutaSQL"));
});
```

## Convertir Imagen
```
```