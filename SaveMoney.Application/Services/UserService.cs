using AutoMapper;
using MediatR;
using SaveMoney.Application.DTOs;
using SaveMoney.Application.Features.Users.Commands;
using SaveMoney.Application.Interfaces;
using SaveMoney.Application.Features.Users.Queries;

namespace SaveMoney.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> GetUsers()
        {
            var usersQuery = new GetUsersQuery();
            if (usersQuery == null)
                throw new ArgumentNullException("Entity could not be loaded");

            var result = await _mediator.Send(usersQuery);
            return _mapper.Map<IEnumerable<UserDTO>>(result);
        }

        public async Task<UserDTO> GetById(int? id)
        {
            var userQuery = new GetUserByIdQuery(id.Value);
            if (userQuery == null)
                throw new ArgumentNullException("Entity could not be loaded");
            var result = await _mediator.Send(userQuery);
            return _mapper.Map<UserDTO>(result);
        }

        public async Task Add(UserDTO userDTO)
        {
            var userCreateCommand = _mapper.Map<UserCreateCommand>(userDTO);
            await _mediator.Send(userCreateCommand);
        }

        public async Task Update(UserDTO userDTO)
        {
            var userUpdateCommand = _mapper.Map<UserUpdateCommand>(userDTO);
            await _mediator.Send(userUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            var userEntity = new UserRemoveCommand(id.Value);
            if (userEntity == null)
                throw new ArgumentNullException("Entity could not be loaded");

            await _mediator.Send(userEntity);
        }


    }
}
