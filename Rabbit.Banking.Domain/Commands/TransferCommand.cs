using MicroRabbit.Domain.Core.Commands;

namespace Rabbit.Banking.Domain;

public abstract class TransferCommand:Command
{
    public int From { get; protected set; }
    public int To { get; set; }

    public decimal Amount { get; protected set; }
    //
}
