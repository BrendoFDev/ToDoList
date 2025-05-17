using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ToDoList.Logger;
using ToDoList.Repository;

namespace ToDoList.Services
{
    public class UrgencyLevelService : IUrgencyLevelService
    {
        private Connection context;
        public UrgencyLevelService(Connection connection)
        {
            this.context = connection;
        }

        public async Task<string?> getUrgencyLevel()
        {
            try
            {
                List<Models.UrgencyLevel> urgencyLevel = await context.urgencyLevel.ToListAsync();

                return urgencyLevel != null ? JsonConvert.SerializeObject(urgencyLevel) : string.Empty;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public bool deleteUrgencyLevel(int id)
        {
            try
            {
                int affectedRows = context.urgencyLevel.Where(x => x.Id == id).ExecuteDelete();

                return affectedRows == 0 ? false : true;
            }
            catch (Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }

        public async Task<string?> postUrgencyLevel(Models.UrgencyLevel urgencyLevel)
        {
            try
            {
                context.urgencyLevel.Add(urgencyLevel);
                await context.SaveChangesAsync();
                return JsonConvert.SerializeObject(urgencyLevel);
            }
            catch(Exception ex)
            {
                LoggerService.logError(ex.ToString() + Environment.NewLine + ex.StackTrace);
                throw new Exception("Erro interno do servidor");
            }
        }
    }

    interface IUrgencyLevelService
    {
        Task<string?> getUrgencyLevel();
        bool deleteUrgencyLevel(int id);
        Task<string?> postUrgencyLevel(Models.UrgencyLevel urgencyLevel);
    }
}
