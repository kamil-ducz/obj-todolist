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
                return _toDoListDbContext.Assignees.ToList();
            }

            throw new NotImplementedException();
        }

        public Assignee GetAssignee(int assigneeId)
        {
            if (_toDoListDbContext.Assignees is not null)
            {
                return _toDoListDbContext.Assignees.First(a => a.Id == assigneeId);
            }

            throw new NotImplementedException();
        }

        public void DeleteAssignee(int assigneeId)
        {

            if (_toDoListDbContext.Assignees is not null)
            {
                var assigneeToDelete = _toDoListDbContext.Assignees.First(a => a.Id == assigneeId);
                _toDoListDbContext.Assignees.Remove(assigneeToDelete);
                _toDoListDbContext.SaveChanges();

            }

            else
            {
                throw new NotImplementedException();
            }

        }

        public int InsertAssignee(Assignee assignee)
        {
            if (_toDoListDbContext.Assignees is not null)
            {
                _toDoListDbContext.Assignees.Add(assignee);
                _toDoListDbContext.SaveChanges();

                return assignee.Id;
            }

            throw new NotImplementedException();
        }

        public void UpdateAssignee(Assignee assignee)
        {
            throw new NotImplementedException();
        }
    }
}
