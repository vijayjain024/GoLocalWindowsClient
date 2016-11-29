﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class VoteModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Type { get; set; }
        public int FeedID { get; set; }
        public string FeedTitle { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
