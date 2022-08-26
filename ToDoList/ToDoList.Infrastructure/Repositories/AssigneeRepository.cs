using ToDoList.Api;
using ToDoList.Domain.Interfaces;
using ToDoList.Domain.Models;

namespace ToDoList.Infrastructure.Repositories
{
    public class AssigneeRepository : IAssigneeRepository
    {
        private readonly ToDoListDbContext _toDoListDbContext;

        public AssigneeRepository(ToDoListDbContext toDoListDbContext)
        {
            this._toDoListDbContext = toDoListDbContext;
        }

        public List<Assignee> GetAllAssignees()
        {
            if (_toDoListDbContext.Assignees is not null)
            {
                var assignees = _toDoListDbContext.Assignees.ToList();

                return assignees;
            }

            throw new NotImplementedException();
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
