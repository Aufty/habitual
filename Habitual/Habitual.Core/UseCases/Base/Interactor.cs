using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.UseCases.Base
{
    public interface InteractorCallback
    {
        void OnError(string message);
    }
    public interface Interactor
    {
        void Execute();
    }
}
