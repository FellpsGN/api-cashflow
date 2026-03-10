using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses;

public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
    
    /// <summary>
    /// This function returns TRUE if the deletion was successful otherwise returns FALSE.
    /// Essa função retorna True se o processo de remover a despesa foi feito com sucesso caso contrário retorna False.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<bool> Delete(long id);
}