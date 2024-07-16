namespace Ordering.Domain.ValueObjects;

public record OrdermItemId
{
    public Guid Value { get; }

    private OrdermItemId(Guid value) => Value = value;

    public static OrdermItemId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("OrdermItemId cannot be empty");
        }

        return new OrdermItemId(value);
    }
}
