﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Models
{
    class CommentModel
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int FeedId { get; set; }
        public string FeedTitle { get; set; }
    }
}
