using System;
using Game.Interfaces.Presentation.Views;
using Game.Interfaces.Presenters;
using UnityEngine;

namespace Game.Implementations.Presentation.Views
{
    public class View : MonoBehaviour, IView
    {
        private IPresenter _presenter;

        private void OnEnable() =>
            _presenter?.Enable();

        private void OnDisable() =>
            _presenter?.Disable();

        public void Show() =>
            gameObject.SetActive(true);

        public void Hide() =>
            gameObject.SetActive(false);

        protected void Construct(IPresenter presenter)
        {
            Hide();
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            Show();
        }
    }
}