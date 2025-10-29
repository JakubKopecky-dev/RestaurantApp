using System;
using System.Collections.Generic;
using System.Text;

namespace MenuService.Command.Application.Abstraction.Messaging
{
    public interface ICommandExecutor
    {
        Task<TResult> Execute<TCommand, TResult>(TCommand command, CancellationToken ct) where TCommand : ICommand<TResult>;
    }
}
