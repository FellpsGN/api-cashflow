using Microsoft.Extensions.DependencyInjection;

using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.Register;

namespace CashFlow.Application;

public static class DepencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
    }
}