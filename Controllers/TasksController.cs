using Microsoft.AspNetCore.Mvc;
using TaskManage.Dtos;
using TaskManage.Model;
using TaskManage.Repo;

namespace TaskManage.Controllers
{
    [ApiController]
    [Route("tasks")]
    public class TasksController:ControllerBase
    {
        private ITask _TaskRepo;
        public TasksController(ITask taskRepo)
        {
            //_TaskRepo=new InMemTaskRepo();
            _TaskRepo=taskRepo;

        }
        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetTasks()
        {
            return _TaskRepo.GetTasks().
                Select(x=> new TaskDto {Id=x.Id , Title=x.Title , Description=x.Description}).ToList();
                
        }
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetTask(Guid id)
        {
            var task = _TaskRepo.GetTask(id);

            if (task == null)
                return NotFound();

            var taskDto = new TaskDto { Title = task.Title , Description = task.Description, Id = task.Id };
           // return _TaskRepo.GetTask(id).
              //  Select(x => new TaskDto { Id = x.Id, Title = x.Title, Description = x.Description });
            return taskDto;

        }
        [HttpPost]
        public ActionResult CreateTask(CreateOrUpdateBookDTO task)
        {
            var myTask = new Tasks();
            myTask.Title = task.Title;
            myTask.Description = task.Description;
            myTask.Id=Guid.NewGuid();

            _TaskRepo.CreateTask(myTask);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateTask(Guid id,CreateOrUpdateBookDTO task)
        {
            var myTask = _TaskRepo.GetTask(id);

            if (myTask == null)
                return NotFound();
            myTask.Title = task.Title;
            myTask.Description = task.Description;
            myTask.Id = Guid.NewGuid();

            _TaskRepo.UpdateTask(myTask,id);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteTask(Guid id)
        {
            var task = _TaskRepo.GetTask(id);
            if(task == null)
               return NotFound();

            _TaskRepo.DeleteTask(id);

            return Ok();
        }

    }
}
