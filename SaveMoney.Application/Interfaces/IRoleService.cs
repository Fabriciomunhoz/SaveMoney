using SaveMoney.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDTO>> GetRoles();
        Task<RoleDTO> GetById(int? id);
        Task Add(RoleDTO roleDTO);
        Task Update(RoleDTO roleDTO);
        Task Remove(int? id);
    }
}
