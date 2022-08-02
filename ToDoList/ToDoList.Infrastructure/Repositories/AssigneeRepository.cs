﻿using ToDoList.Api;
using ToDoList.Domain.Models;
using ToDoList.Infrastructure.Interfaces;

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

        public int InsertAssignee(int assigneeId)
        {
            throw new NotImplementedException();
        }

        public void UpdateAssignee(int assigneeId)
        {
            throw new NotImplementedException();
        }
    }
}
