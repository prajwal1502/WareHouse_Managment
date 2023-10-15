using MyMDB.Data.Model;
using MyMDB.Model;

namespace MyMDB.Data.EFCore
{
    public class EfCoreMovieRepository : EfCoreRepository<Movie, MyMDBContext>
    {
        public EfCoreMovieRepository(MyMDBContext context) : base(context)
        {

        }
    }
}
