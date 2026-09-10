using AutoMapper;
using MediatR;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Features.Roles.Commands;
using SaveMoney.Application.Features.Roles.Queries;
using SaveMoney.Application.Features.Users.Commands;
using SaveMoney.Application.Features.Users.Queries;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var rolesQuery = new GetUsersQuery();
            if (rolesQuery == null)
                throw new ArgumentNullException("Entity could not be loaded");

            var result = await _mediator.Send(rolesQuery);
            return _mapper.Map<IEnumerable<RoleDTO>>(result);
        }

        public async Task<RoleDTO> GetById(int? id)
        {
            var roleQuery = new GetRoleByIdQuery(id.Value);
            if (roleQuery == null)
                throw new ArgumentNullException("Entity could not be loaded");
            var result = await _mediator.Send(roleQuery);
            return _mapper.Map<RoleDTO>(result);
        }

        public async Task Add(RoleDTO roleDTO)
        {
            var roleCreateCommand = _mapper.Map<RoleCreateCommand>(roleDTO);
            await _mediator.Send(roleCreateCommand);
        }

        public async Task Update(RoleDTO roleDTO)
        {
            var roleUpdateCommand = _mapper.Map<RoleUpdateCommand>(roleDTO);
            await _mediator.Send(roleUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var roleRemoveCommand = _mapper.Map<RoleRemoveCommand>(id);
            await _mediator.Send(roleRemoveCommand);
        }

        
    }
}
