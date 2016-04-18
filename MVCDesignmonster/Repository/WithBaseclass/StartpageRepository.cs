using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCDesignmonster.Repository.WithBaseclass
{
    public class StartpageRepository : RepositoryBase<RepoDbContext>, IStartpageRepository
    {
        public string GetWelcomeTitle()
        {
            throw new NotImplementedException();
        }

        public string GetWelcomeText()
        {
            throw new NotImplementedException();
        }
    }

    public interface IStartpageRepository
    {
        string GetWelcomeTitle();
        string GetWelcomeText();
    }
}
