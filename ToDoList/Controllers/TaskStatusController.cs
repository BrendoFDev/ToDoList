using Microsoft.AspNetCore.Mvc;
using ToDoList.Logger;
using ToDoList.Services;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    public class TaskStatusController : ControllerBase
    {
        private TaskStatusService taskstatusService;
        public TaskStatusController()
        {
            this.taskstatusService = new TaskStatusService(new Connection());
        }

        [HttpGet("/",Name = "getTaskStatus")]
        public async Task<IActionResult> getTaskStatus()
        {
            try
            {
                string? taskStatusJson = await taskstatusService.getTaskStatus();
                if (string.IsNullOrEmpty(taskStatusJson))
                    return StatusCode(204);
                else
                    return Ok(taskStatusJson);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpDelete("/{id}", Name = "deleteTaskStatus")]
        public IActionResult deleteTaskStatus(int id)
        {
            try
            {
                bool deleted  =  taskstatusService.deleteTaskStatus(id);

                if (!deleted)
                    Conflict("TaskStatus Do Not Exists!");

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
