using Microsoft.AspNetCore.Mvc;
using ToDoList.Repository;
using ToDoList.Services;
using ToDoList.Logger;

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

        [HttpGet("{page}/{pageSize}",Name = "GetTask")]
        public async Task<IActionResult>  getTask(int page = 1, int pageSize=10)
        {
            try
            {
                string? tasks = await taskService.getTask(page, pageSize);

                if (string.IsNullOrEmpty(tasks)) 
                    return NoContent();

                return Ok(tasks);
            }
            catch(Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpGet("id={id}", Name = "getTaskById")]
        public async Task<IActionResult> getTaskById(int id)
        {
            try
            {
                string? taskJson = await taskService.getTaskById(id);

                if (string.IsNullOrEmpty(taskJson))
                    return StatusCode(204);

                return Ok(taskJson);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpGet("desc={description}", Name = "getTaskByDescription")]
        public async Task<IActionResult> getTaskByDescription(string description)
        {
            try
            {
                string taskJson = await taskService.getTaskByDescription(description);

                if (string.IsNullOrEmpty(taskJson))
                    return StatusCode(204);

                return Ok(taskJson);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpPost(Name = "PostTask")]
        public async Task<IActionResult> postTask([FromBody] Models.Task task)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(204);

                string taskJson = await taskService.postTask(task);
                    return Ok(taskJson);
            }
            catch(Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpDelete("id={id}", Name = "deleteTask")]
        public  IActionResult deleteTask(int id)
        {
            try
            {
                bool deleted = taskService.deleteTask(id);

                if (!deleted)
                    Conflict("Task Do Not Exists!");

                return Ok();

            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

       

        private ObjectResult handleException(Exception ex)
        {
            LoggerService.logError(DateTime.Now + ex.ToString() + ex.InnerException);
            return StatusCode(500, "Erro interno do servidor");
        }
    }
}
