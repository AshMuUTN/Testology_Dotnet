using System.Threading.Tasks;
using Testology_Dotnet.Domain.Models.Auth;
using Testology_Dotnet.Domain.Repositories.Auth;
using Testology_Dotnet.Domain.Repositories;
using Testology_Dotnet.Domain.Security.Hashing;
using Testology_Dotnet.Domain.Services;
using Testology_Dotnet.Domain.Services.Communication;

namespace Testology_Dotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> CreateUserAsync(User user, params ApplicationRole[] userRoles)
        {
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            if(existingUser != null)
            {
                return new CreateUserResponse(false, "Email already in use.", null);
            } 

            user.Password = _passwordHasher.HashPassword(user.Password);

            await _userRepository.AddAsync(user, userRoles);
            await _unitOfWork.CompleteAsync();

            return new CreateUserResponse(true, null, user);
        }

        public async Task<CreateUserResponse> UpdateUserPasswordAsync(User user)
        {
            var existingUser = await _userRepository.FindByEmailAsync(user.Email);
            if(existingUser == null)
            {
                return new CreateUserResponse(false, "Email not registered.", null);
            } 

            existingUser.Password = _passwordHasher.HashPassword(user.Password);

            _userRepository.UpdatePassword(existingUser);
            await _unitOfWork.CompleteAsync();

            return new CreateUserResponse(true, null, user);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userRepository.FindByEmailAsync(email);
        }
    }
}