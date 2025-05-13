using ToDoList.Repository;
using ToDoList.Logger;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Data;


namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private Connection context;
        public TaskService(Connection context)
        {
            this.context = context;
        }

        public async Task<string?> getTask(int page=1, int pageSize = 10)
        {
            try
            {
                var query =  context.tasks.Skip((page - 1) * pageSize).Take(pageSize);

                List<Models.Task> tasks = await query.ToListAsync();

                if (tasks.Count == 0)
                    return null;

                return JsonConvert.SerializeObject(tasks);
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString()  + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public async Task<string> getTaskByDescription(string Description)
        {
            try
            {
                var query = context.tasks.Where(x => x.Description.ToLower().Contains(Description.ToLower())).Include(x=>x.TaskStatus).Include(x=>x.UrgencyLevel);

                List<Models.Task> tasks = await query.ToListAsync();

                return tasks != null ? JsonConvert.SerializeObject(tasks) : string.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public async Task<string?> getTaskById(int id)
        {
            try
            {
                var query = context.tasks.Where(x => x.Id == id);
                Models.Task? task = await query.FirstOrDefaultAsync();

                return task != null ? JsonConvert.SerializeObject(task) : string.Empty;
            }
            catch(Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public async Task<string> postTask(Models.Task task)
        {
            try
            {
                context.tasks.Add(task);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(task);
            }
            catch(Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public bool deleteTask(int id)
        {
            try
            {
                int affectedRows = context.tasks.Where(x => x.Id == id).ExecuteDelete();

                return affectedRows == 0 ? false : true;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }
         
    }

    interface ITaskService
    {
        Task<string?> getTask(int page = 1, int pageSize = 10);
        Task<string> getTaskByDescription(string Description);
        Task<string?> getTaskById(int id);
        Task<string> postTask(Models.Task task);
        bool deleteTask(int id);
    }
}
