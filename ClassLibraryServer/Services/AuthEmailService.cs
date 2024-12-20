using ClassLibraryModels.DTOs;
using ClassLibraryModels.DTOs.Auth;
using ClassLibraryServer.Connections;
using ClassLibraryServer.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClassLibraryServer.Services
{
    public class AuthEmailService : IAuthService
    {
        private readonly EntityDbContext _dbContext;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthEmailService(EntityDbContext entityDbContext, ITokenGenerator tokenGenerator)
        {
            _dbContext = entityDbContext;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseApiDTO<TokenDTO>> LoginAsync(RequestLoginDTO loginDTO, JwtConfigDTO jwtConfigDTO, CancellationToken cancellationToken)
        {
            try
            {
                var logedinDTO = await _dbContext.TKUsers
                    .Include(r => r.Role)
                    .Where(e => e.Email.Equals(loginDTO.Email))
                    .Select(u => new LogedinDTO { 
                        Id = u.Id,
                        Email = u.Email,
                        Role = u.Role.Role
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (logedinDTO == null)
                    return new ResponseApiDTO<TokenDTO>
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        Message = "Wrong Username or Password"
                    };

                var token = _tokenGenerator.GenerateJwtToken(logedinDTO, jwtConfigDTO);

                var response = new ResponseApiDTO<TokenDTO>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Message = "Login Success",
                    Data = token,
                };

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseApiDTO<TokenDTO>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "Error en la operación de base de datos: " + ex.Message
                };
            }
        }
    }
}
