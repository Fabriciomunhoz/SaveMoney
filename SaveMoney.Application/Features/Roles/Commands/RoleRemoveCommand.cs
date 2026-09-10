namespace SaveMoney.Application.Features.Roles.Commands
{
    public class RoleRemoveCommand : RoleCommand
    {
        public int Id { get; set; }
        public RoleRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
