using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.Interfaces
{
    public interface IApplicationUserService
    {
        Task RegisterUser(string email, string password);
    }
}
