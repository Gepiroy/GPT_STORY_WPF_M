using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPT_STORY_WPF_M.Chats
{
    public class Message
    {
        private string _raw = "-";
        public string raw {
            get => _raw;
            set{
                _raw = value;
                if(Regex.IsMatch(_raw, @"^\d\."))
                {
                    _raw = _raw.Substring(3);
                }
            }
}
        public string from = "N/A";
        public string type = "N/A";
    }
}
