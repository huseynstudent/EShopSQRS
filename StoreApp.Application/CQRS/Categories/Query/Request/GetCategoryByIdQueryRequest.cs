using MediatR;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Application.CQRS.Categories.Query.Response;

namespace StoreApp.Application.CQRS.Categories.Query.Request;

public class GetCategoryByIdQueryRequest : IRequest<ResponseModel<GetCategoryByIdQueryResponse>>
{
    public int Id { get; set; }
}