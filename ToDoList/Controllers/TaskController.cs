using Microsoft.AspNetCore.Mvc;
using ToDoList.Repository;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private TaskService taskService;
        public TaskController()
        {
            this.taskService = new TaskService(new Connection());
        }

        [HttpGet("Task/{page}/{pageSize}",Name = "GetTask")]
        public async Task<IActionResult>  getTask(int page, int pageSize)
        {
            try
            {
                string tasks = await taskService.getTask(page, pageSize);

                if (!string.IsNullOrEmpty(tasks))
                    return Ok(tasks);
                else
                    return NoContent();
            }
            catch(Exception ex)
            {
                return handleException();
            }
        }

        [HttpPost(Name = "PostTask")]
        public async Task<IActionResult> postTask([FromBody] Models.Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string taskJson = await taskService.postTask(task);

                    return Ok(taskJson);
                }

                return StatusCode(204);
            }
            catch(Exception ex)
            {
                return handleException();
            }
        }

        private ObjectResult handleException()
        {
            // implementar log de erros antes de retornar a resposta
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}
