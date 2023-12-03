using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CenterMotosApi.Repositories.UnitOfWork
{
    public interface IUnitOfWork
    {
        public Task SaveChangesAsync();
    }
}
