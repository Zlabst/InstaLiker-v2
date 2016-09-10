using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Awesomium.Windows.Forms;

namespace InstaLiker.Forms
{
    public interface IMainView
    {
        ISynchronizeInvoke MainThread { get; } // для вызова нужных методов из UI-потока
        WebControl WebBrowser { get; }
    }
}
