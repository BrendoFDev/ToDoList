using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ToDoList.Logger;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class TaskStatusService : ITaskStatusService
    {
        private Connection context;
        public TaskStatusService(Connection connection)
        {
            this.context = connection;
        }

        public async Task<string?> getTaskStatus()
        {
            try
            {
                List<Models.TaskStatus> taskStatuses = await context.taskStatus.ToListAsync();

                return taskStatuses != null ? JsonConvert.SerializeObject(taskStatuses) : string.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public bool deleteTaskStatus(int id)
        {
            try
            {
                int affectedRows = context.taskStatus.Where(x => x.Id == id).ExecuteDelete();

                return affectedRows == 0 ? false : true;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }
    }

    interface ITaskStatusService
    {
        Task<string?> getTaskStatus();
        bool deleteTaskStatus(int id);
    }
}
