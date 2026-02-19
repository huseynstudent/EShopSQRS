using MediatR;
using StoreApp.Application.CQRS.Categories.Command.Request;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;

namespace StoreApp.Application.CQRS.Categories.Handler.CommandHandler;

class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, ResponseModel<bool>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<bool>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        _unitOfWork.CategoryRepository.Delete(request.Id);
        await _unitOfWork.SaveChangesAsync();

        return new ResponseModel<bool>(true);
    }
}