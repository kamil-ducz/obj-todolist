﻿using System.Collections.Generic;
using static ToDoList.Domain.Enums.Enums;

namespace ToDoList.Domain.Models
{
    public class BucketTask
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public TaskState TaskState { get; set; }
        public TaskPriority TaskPriority { get; set; }
        public virtual List<Assignee>? Assignees { get; set; }
    }
}