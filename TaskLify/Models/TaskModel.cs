﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLify.Models
{
    public class TaskModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string details { get; set; }
        
        public TaskModel()
        {

        }
    }
}
