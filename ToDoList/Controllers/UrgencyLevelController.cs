using Microsoft.AspNetCore.Mvc;
using ToDoList.Logger;
using ToDoList.Services;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrgencyLevelController : ControllerBase
    {
        private UrgencyLevelService urgencyLevelService;
        public UrgencyLevelController()
        {
            this.urgencyLevelService = new UrgencyLevelService(new Connection());
        }

        [HttpGet(Name = "getUrgencyLevel")]
        public async Task<IActionResult> getTaskStatus()
        {
            try
            {
                string? urgencyLevelJson = await urgencyLevelService.getUrgencyLevel();
                if (string.IsNullOrEmpty(urgencyLevelJson))
                    return StatusCode(204);
                else
                    return Ok(urgencyLevelJson);
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpDelete("{id}", Name = "deleteUrgencyLevel")]
        public IActionResult deleteTaskStatus(int id)
        {
            try
            {
                bool deleted  =  urgencyLevelService.deleteUrgencyLevel(id);

                if (!deleted)
                    Conflict("TaskStatus Do Not Exists!");

                return Ok();
            }
            catch (Exception ex)
            {
                return handleException(ex);
            }
        }

        [HttpPost(Name = "postUrgencyLevel")]
        public async Task<IActionResult> postTaskStatus(Models.UrgencyLevel urgencyLevel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(204);

                string? urgencyLevelJson = await urgencyLevelService.postUrgencyLevel(urgencyLevel);
                return Ok(urgencyLevelJson);
            }
            catch(Exception ex)
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
