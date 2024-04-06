using Sources.Libraries.Mvp.Interfaces.Views;
using UnityEngine;

namespace Sources.Libraries.Mvp.Implementation.Views
{
    public abstract class View : MonoBehaviour, IView
    {
        public void Show() => 
            gameObject.SetActive(true);

        public void Hide() => 
            gameObject.SetActive(false);

        public virtual void Add(IView view) => 
            view.SetParent(transform);

        public virtual void Remove(IView view) =>
            view.SetParent(null);

        public virtual void Add(IView view, int order) =>
            Add(view);

        public virtual void SetParent(Transform parent) => 
            transform.SetParent(parent, false);

        public void Destroy() => 
            Destroy(gameObject);
    }
}