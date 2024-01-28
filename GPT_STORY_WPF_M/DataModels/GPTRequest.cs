using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPT_STORY_WPF_M.DataModels
{
    internal class GPTRequest
    {
        public string prompt { get; set; }
        public int max_tokens { get; set; } = 200;
        public double repetition_penalty { get; set; } = 1.15;
    }
}
