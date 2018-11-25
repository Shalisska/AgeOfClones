using Application.Data.Repositories;

namespace Application.Data.UnitsOfWork
{
    public interface ISocialStatusUOW
    {
        ISocialStatusRepository SocialStatus { get; }

        void Save();
    }
}
