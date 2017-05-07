using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Habitual.Core.UseCases.Base;

namespace Habitual.Core.UseCases
{
    public interface SetAvatarInteractorCallback : InteractorCallback
    {
        void OnAvatarSet(string imageString);
    }
    public interface SetAvatarInteractor : Interactor
    {
    }
}
