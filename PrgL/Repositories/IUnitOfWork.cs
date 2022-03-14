using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrgL.Repositories
{
    public interface IUnitOfWork
    {
        ILanguageRepository Language { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
