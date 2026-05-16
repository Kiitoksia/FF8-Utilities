using System;

namespace FF8Utilities.Web.Services
{
    public class WebService
    {
        public string Title { get; private set; }

        public event Action OnTitleChanged;

        public void SetTitle(string title)
        {
            Title = title;
            OnTitleChanged?.Invoke();
        }
    }
}
