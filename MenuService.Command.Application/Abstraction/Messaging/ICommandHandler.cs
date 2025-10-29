using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Abstraction.Messaging
{
    public interface ICommandHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {
        Task<TResult> Handle(TCommand command, CancellationToken ct);


    }
}
