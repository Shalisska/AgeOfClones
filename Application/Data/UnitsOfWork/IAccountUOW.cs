using Application.Data.Repositories;

namespace Application.Data.UnitsOfWork
{
    public interface IAccountUOW
    {
        IProfileRepository Profile { get; }
        IAccountRepository Account { get; }

        void Save();
    }
}
