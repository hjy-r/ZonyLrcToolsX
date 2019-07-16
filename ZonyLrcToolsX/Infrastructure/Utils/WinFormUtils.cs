using System;
using System.Windows.Forms;

namespace ZonyLrcToolsX.Infrastructure.Utils
{
    public class WinFormUtils
    {
        public static void InvokeAction(Form from, Action action)
        {
            from.Invoke(action);
        }
    }
}
