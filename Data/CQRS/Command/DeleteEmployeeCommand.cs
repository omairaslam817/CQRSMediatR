using MediatR;

namespace CQRSMediatR.Data.CQRS.Command
{
    public class DeleteEmployeeCommand:IRequest<int>
    {
        public int Id { get; set; }
    }
}
