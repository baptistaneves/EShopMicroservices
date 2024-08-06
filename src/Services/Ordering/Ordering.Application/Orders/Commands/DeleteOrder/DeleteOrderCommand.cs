namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderResult(bool IsSuccess);

public record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderResult>;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}