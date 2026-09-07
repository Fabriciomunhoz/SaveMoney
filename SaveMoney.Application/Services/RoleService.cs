using AutoMapper;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Interfaces;
using SaveMoney.Domain.Entities;
using SaveMoney.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveMoney.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository ?? 
                throw new ArgumentNullException(nameof(roleRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var rolesEntity = await _roleRepository.GetRolesAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(rolesEntity);
        }

        public async Task<RoleDTO> GetById(int? id)
        {
            var roleEntity = await _roleRepository.GetByIdAsync(id);
            return _mapper.Map<RoleDTO>(roleEntity);
        }

        public async Task Add(RoleDTO roleDTO)
        {
            var roleEntity = _mapper.Map<Role>(roleDTO);
            await _roleRepository.CreateAsync(roleEntity);
        }

        public async Task Update(RoleDTO roleDTO)
        {
            var roleEntity = _mapper.Map<Role>(roleDTO);
            await _roleRepository.UpdateAsync(roleEntity);
        }

        public async Task Remove(int? id)
        {
            var roleEntity = await _roleRepository.GetByIdAsync(id);
            await _roleRepository.DeleteAsync(roleEntity);
        }

        
    }
}
