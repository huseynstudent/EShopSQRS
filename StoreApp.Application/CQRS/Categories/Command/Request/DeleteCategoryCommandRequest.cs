using MediatR;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;


namespace StoreApp.Application.CQRS.Categories.Command.Request;

public class DeleteCategoryCommandRequest : IRequest<ResponseModel<bool>>
{
    public int Id { get; set; }
}