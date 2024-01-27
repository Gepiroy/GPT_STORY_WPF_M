using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_STORY_WPF_M
{
    public static class UIThread
    {
        public static void run(Action toDo)
        {
            MainWindow.Instance.Dispatcher.Invoke(toDo);
        }

    }
}
