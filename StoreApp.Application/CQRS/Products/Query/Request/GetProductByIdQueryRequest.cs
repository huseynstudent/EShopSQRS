using MediatR;
using StoreApp.Application.CQRS.Products.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Products.Query.Request;

public class GetProductByIdQueryRequest:IRequest<ResponseModel<GetProductByIdQueryResponse>>
{
    public int Id { get; set; }
}
