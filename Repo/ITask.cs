using TaskManage.Model;

namespace TaskManage.Repo
{
    public interface ITask
    {
        public IEnumerable<Tasks> GetTasks();

        public Tasks GetTask(Guid id);

        public void CreateTask(Tasks task);
       
        public void UpdateTask(Tasks task,Guid id);

        public void DeleteTask(Guid id);
    }
}
