using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWebApplication.Models
{
    public class Ping : IRequest<string>
    {
        public int F1 { get; set; }
    }

    public class PingHandler : IRequestHandler<Ping, string>
    {
        Task<string> IRequestHandler<Ping, string>.Handle(Ping request, CancellationToken cancellationToken)
        {
            if (request.F1 == 1)
            {
                return Task.FromResult("Pong1");
            }
            else
            {
                return Task.FromResult("Pong");
            }
        }
    }

    public class PingHandler1 : IRequestHandler<Ping1>
    {
        public Task<Unit> Handle(Ping1 request, CancellationToken cancellationToken)
        {
            return Unit.Task;
        }
    }

    public class Ping1 : IRequest
    {
    }
}