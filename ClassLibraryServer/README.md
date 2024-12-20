# Class Library Server .NET 7

### Menu
* [Ir a Dependencias](#dependencias)
* [Ir a Generador de Tokens](#generador-de-tokens)

## Dependencias
```
Microsoft.AspNetCore.Authentication.JwtBearer
Microsoft.EntityFrameworkCore.SqlServer
ClassLibraryModels
```

## Generador de Tokens
* Fuentes
>[Pagina jwt.io](https://jwt.io) <br>
>[Pagina SHA256](https://tools.keycdn.com/sha256-online-generator)

* Configurar appsettings.json y/o appsettings.Development.json
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
* Configurar Program.cs
```
```
* Metodo del Servicio
```
public TokenDTO GenerateJwtToken(LogedinDTO logedin, JwtConfigDTO jwtConfig)
{
    // Define los claims (información contenida en el token)
    var claims = new[]
    {
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Sub, logedin.Id.ToString()),
        new Claim(JwtRegisteredClaimNames.Email, logedin.Email),
        new Claim(ClaimTypes.Role, logedin.Role)
    };

    // Genera una clave simétrica a partir del secret en appsettings.json
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Key));
    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    // Configuración del token: audiencia, emisor, expiración y firma
    var token = new JwtSecurityToken(
        issuer: jwtConfig.Issuer,
        audience: jwtConfig.Audience,
        claims: claims,
        expires: DateTime.Now.AddMinutes(Convert.ToInt32(jwtConfig.ExpireMin)),
        signingCredentials: creds
    );

    return new TokenDTO {
        Token = new JwtSecurityTokenHandler().WriteToken(token)
    };
}
```
* DTOs
```
public class LogedinDTO
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public required string Role { get; set; }
}

public class JwtConfigDTO
{
    public required string Key { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required string Subject { get; set; }
    public required string ExpireMin { get; set; }
}
```

