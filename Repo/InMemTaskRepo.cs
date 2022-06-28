using TaskManage.Model;

namespace TaskManage.Repo
{
    public class InMemTaskRepo : ITask
    {
        private List<Tasks> _Tasks;

        public InMemTaskRepo()
        {
            _Tasks = new() { new Tasks { Id = Guid.NewGuid(), Title = "Task 1", Description = "Creating a rest api app" } };
        }

        public void CreateTask(Tasks task)
        {
            _Tasks.Add(task);
        }

        public void DeleteTask(Guid id)
        {

            var taskIndex = _Tasks.FindIndex(x => x.Id == id);
            if (taskIndex > -1)
                _Tasks.RemoveAt(taskIndex) ;
        }

        public Tasks GetTask(Guid id)
        {
           var task= _Tasks.Where(x => x.Id == id).FirstOrDefault();
            return task;
        }

        public IEnumerable<Tasks> GetTasks()
        {
            return _Tasks;
        }

        public void UpdateTask(Tasks task, Guid id)
        {
            var taskIndex = _Tasks.FindIndex(x => x.Id == id);
            if (taskIndex > -1)
                _Tasks[taskIndex] = task;

            


        }
    }
}
