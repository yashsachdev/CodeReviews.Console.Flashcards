using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashcardApp.DTO
{
    internal class FlashcardDTO
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int stackId { get; set; }
    }
}
