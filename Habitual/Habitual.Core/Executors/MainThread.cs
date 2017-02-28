using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Habitual.Core.Executors
{
    public interface MainThread
    {
        /// <summary>
        /// Post an action with one param to the main thread (used for UI updates)
        /// </summary>
        void Post(Action action);

    }
}
