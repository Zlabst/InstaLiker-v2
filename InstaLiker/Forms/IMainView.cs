using System;

namespace InstaLiker.Forms
{
    public interface IMainView
    {
        void NavigateToPage(Uri uri, out string htmlDocument);
        void ChangeStatus(string message);
        void GetHtmlDocument(out string htmlDocument);
        void EnableCtrls(bool state);
        void PressLike(int tagId);
        void RefreshBrowser();
    }
}