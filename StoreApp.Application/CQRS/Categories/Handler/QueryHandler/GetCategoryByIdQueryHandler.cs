using MediatR;
using StoreApp.Application.CQRS.Categories.Query.Request;
using StoreApp.Application.CQRS.Categories.Query.Response;
using StoreApp.Comman.GlobalResponse.Generics.ResponseModel;
using StoreApp.Repository.Comman;


namespace StoreApp.Application.CQRS.Categories.Handler.QueryHandler;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQueryRequest, ResponseModel<GetCategoryByIdQueryResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<GetCategoryByIdQueryResponse>> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
    {
        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Id);
        var response = new GetCategoryByIdQueryResponse
        {
            Id = category.Id,
            Name = category.Name
        };

        return new ResponseModel<GetCategoryByIdQueryResponse>(response);
    }
}