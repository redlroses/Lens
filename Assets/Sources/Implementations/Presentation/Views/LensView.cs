using Game.Implementations.Controllers.Presenters;
using Game.Interfaces.Presenters;
using UnityEngine;

namespace Game.Implementations.Presentation.Views
{
    public class LensView : View
    {
        public void Construct(LensPresenter lensPresenter)
        {
            Construct(lensPresenter as IPresenter);

            Debug.Log("LensView Construct");
        }
    }
}