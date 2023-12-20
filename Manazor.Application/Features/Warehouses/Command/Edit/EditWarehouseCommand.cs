using MediatR;

namespace Manazor.Application.Features.Warehouses.Command.Edit
{
    public class EditWarehouseCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
