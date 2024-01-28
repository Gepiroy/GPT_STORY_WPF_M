using GPT_STORY_WPF_M.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GPT_STORY_WPF_M.UI
{
    /// <summary>
    /// Логика взаимодействия для MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl
    {
        public MessageControl(Message message)
        {
            InitializeComponent();
            this.message.Text = message.raw;
            this.type.Text = message.from + "'s " + message.type;
        }
    }
}
