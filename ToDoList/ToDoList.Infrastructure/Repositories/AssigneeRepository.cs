﻿using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class AssigneeRepository : IAssigneeRepository
    {
        public List<Assignee> GetAllAssignees()
        {
            return Database.GetAllAssigness();
        }

        public Assignee GetAssignee(int assigneeId)
        {
            return Database.GetAssignee(assigneeId);
        }

        public void DeleteAssignee(int assigneeId)
        {
            throw new NotImplementedException();
        }

        public int InsertAssignee(Assignee assignee)
        {
            throw new NotImplementedException();
        }

        public void UpdateAssignee(Assignee assignee)
        {
            throw new NotImplementedException();
        }
    }
}
