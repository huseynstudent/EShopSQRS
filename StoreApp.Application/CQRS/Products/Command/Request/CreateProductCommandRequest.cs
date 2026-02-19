using MediatR;
using StoreApp.Application.CQRS.Products.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;

namespace StoreApp.Application.CQRS.Products.Command.Request;

public class CreateProductCommandRequest:IRequest<ResponseModel<CreateProductCommandResponse>>
{
    public string Name { get; set; }
    public double Price { get; set; }
}
