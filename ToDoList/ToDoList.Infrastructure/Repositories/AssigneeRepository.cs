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

            // TODO what if we want to delete connected tasks to assignee? Maybe try to find connected tasks and just delete them as well
        }

        public int InsertAssignee(Assignee assignee)
        {
            if (_toDoListDbContext.Assignees is not null)
            {
                _toDoListDbContext.Assignees.Add(assignee);
                _toDoListDbContext.SaveChanges();

                return assignee.Id;
            }

            // TODO what if assignee object has buckettask in its body? Maybe should add to AssigneeBucketTask table then?

            throw new NotImplementedException();
        }

        public void UpdateAssignee(Assignee assignee)
        {
            throw new NotImplementedException();
        }
    }
}
