using MediatR;
using StoreApp.Application.CQRS.Products.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Products.Query.Request;

public class GetAllProductQueryRequest:IRequest<Pagination<GetAllProductQueryResponse>>
{
    public int Limit { get; set; } = 15;
    public int Page { get; set; } = 1;
}
