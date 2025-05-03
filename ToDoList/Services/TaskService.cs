using ToDoList.Repository;
using ToDoList.Logger;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.Services
{
    public class TaskService : ITaskService
    {
        private Connection context;
        public TaskService(Connection context)
        {
            this.context = context;
        }

        public async Task<string> getTask(int page=1, int pageSize = 10)
        {
            try
            {
                var Query =  context.tasks.Skip((page - 1) * pageSize).Take(pageSize);

                List<Models.Task> tasks = await Query.ToListAsync();

                return JsonConvert.SerializeObject(tasks);
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString()  + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public string getTaskByDescription(string Description)
        {
            throw new NotImplementedException();
        }

        public string getTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> postTask(Models.Task task)
        {
            try
            {
                context.tasks.Add(task).GetDatabaseValues();
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(task);
            }
            catch(Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public void deleteTask(int id)
        {
            throw new NotImplementedException();
        }

    }

    interface ITaskService
    {
        Task<string> getTask(int page = 1, int pageSize = 10);
        string getTaskByDescription(string Description);
        string getTaskById(int id);
        Task<string> postTask(Models.Task task);
        void deleteTask(int id);
    }
}
