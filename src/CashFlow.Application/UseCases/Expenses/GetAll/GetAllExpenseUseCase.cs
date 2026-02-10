using AutoMapper;

using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;
    
    public GetAllExpenseUseCase(IExpenseRepository repository, IMapper mapper)
    {
        _expenseRepository = repository;
        _mapper = mapper;
    }

    public async Task<ResponseExpensesJson> Execute()
    {
        var result = await _expenseRepository.GetAll();
        return new ResponseExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
    
    
}