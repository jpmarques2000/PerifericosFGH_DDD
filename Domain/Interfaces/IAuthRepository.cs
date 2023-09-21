using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(ApplicationUser user, string senha);
        Task<ServiceResponse<string>> Login(string email, string senha);
    }
}
