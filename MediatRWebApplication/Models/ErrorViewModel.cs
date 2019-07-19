using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRWebApplication.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    //#region 实现有无返回值的情况

    //public interface IRequestHandler11<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    //{
    //    Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    //}

    //public interface IRequestHandler11<in TRequest> : IRequestHandler11<TRequest, baseReq>
    //    where TRequest : IRequest<baseReq>
    //{
    //}

    //#endregion 实现有无返回值的情况

    //public interface IBaseRequest { }

    //public class Rest_I : IRequest<baseReq>
    //{
    //}

    //public interface Rest : IRequest<string>
    //{
    //}

    //public interface IRequest<baseReq>
    //{
    //}

    //public class baseReq : IBaseRequest
    //{
    //}

    //public class Ddddd : IRequestHandler11<Rest, string>
    //{
    //    public Task<string> Handle(Rest request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class Dddddd : IRequestHandler11<Rest_I>
    //{
    //    public Task<baseReq> Handle(Rest_I request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}