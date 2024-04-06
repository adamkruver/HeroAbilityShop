using System;
using Sources.Libraries.Mvp.Interfaces.Presenters;
using Sources.Libraries.Mvp.Interfaces.Views;

namespace Sources.Libraries.Mvp.Implementation.Views
{
    public class PresentationView<T> : View, IPresentationView<T> where T : IPresenter
    {
        protected T Presenter { get; private set; }

        private void OnEnable() =>
            Presenter?.Enable();

        private void OnDisable() =>
            Presenter?.Disable();

        private void OnDestroy() =>
            Presenter?.Destroy();

        public void Construct(T presenter)
        {
            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            Hide();
            presenter.Initialize();
            Presenter = presenter;
            Show();
        }
    }
}