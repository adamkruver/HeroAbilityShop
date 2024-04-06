namespace Sources.Libraries.Mvp.Interfaces.Presenters
{
    public interface IPresenter
    {
        void Initialize();
        void Enable();
        void Disable();
        void Destroy();
    }
}