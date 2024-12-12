# Kambio WebApi .NET Core 7

## Menu
- [Ir a Dependencias](#dependencias)
- [Ir a Configurar Cors](#configurar-cors)

### Dependencias
```
```

## Configurar Cors en Program.cs
```
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowCredentials();
    options.SetIsOriginAllowed(origin => true);
});
```
