using Application.Management.Models;

namespace Application.Data.Repositories
{
    public interface ICurrencyRepository : IRepositorySimple<CurrencyManagementModel>
    {
        void CreateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void UpdateExchangeRate(int currentCurrencyId, int currencyId, decimal buy, decimal sell);
        void DeleteExchangeRate(int currentCurrencyId, int currencyId);
    }
}
