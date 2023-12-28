using MediatR;
using MicroRabbit.Domain.Core.Bus;

namespace Rabbit.Banking.Domain;

public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
{

    private readonly IEventBus eventBus;

    public TransferCommandHandler(IEventBus eventBus)
    {
        this.eventBus = eventBus;
    }
    public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
    {

        eventBus.Publish(new TransferCreatedEvent(request.From, request.To, request.Amount));
        return Task.FromResult(true);
    }
}
