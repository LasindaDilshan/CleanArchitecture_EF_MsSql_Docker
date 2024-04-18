using Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public TaskRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int> DeleteTask(int id)
        {
            return await _applicationDbContext.Tasks
                  .Where(model => model.Id == id)
                  .ExecuteDeleteAsync();
        }

        public async Task<List<Domain.Models.Task>> GetAllTasks()
        {
            return await _applicationDbContext.Tasks.AsNoTracking().ToListAsync();
        }


        public async Task<Domain.Models.Task> InsertTask(Domain.Models.Task task)
        {
            await _applicationDbContext.Tasks.AddAsync(task);
            await _applicationDbContext.SaveChangesAsync();
            return task;
        }


        public async Task<int> UpdateTask(Domain.Models.Task task, int id)
        {
            return await _applicationDbContext.Tasks
                 .Where(model => model.Id == id)
                 .ExecuteUpdateAsync(setters => setters
                   .SetProperty(m => m.Title, task.Title)
                   .SetProperty(m => m.Description, task.Description)
                   .SetProperty(m => m.DueDate, task.DueDate)
                 );

        }
    }     
}
