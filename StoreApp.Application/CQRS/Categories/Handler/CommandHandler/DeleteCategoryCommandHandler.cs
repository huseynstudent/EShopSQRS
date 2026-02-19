using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Application.CQRS.Categories.Command.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Domain.Entities;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.CommandHandler;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, ResponseModel<DeleteCategoryCommandResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        _unitOfWork.CategoryRepository.Delete(request.Id);
        await _unitOfWork.SaveChangesAsync();
        var response = new DeleteCategoryCommandResponse
        {
            Id = category.Id,
            Name = $"Deleted {category.Name}"
        };
        return new ResponseModel<DeleteCategoryCommandResponse>(response);
    }
}