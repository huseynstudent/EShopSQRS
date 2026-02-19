using MediatR;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Products.Command.Request;

public class DeleteProductCommandRequest:IRequest<ResponseModel<DeleteProductCommandResponse>>
{
    public int Id { get; set; }
}
