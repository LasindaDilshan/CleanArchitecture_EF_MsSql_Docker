using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<List<Domain.Models.Task>> GetAllTasks();
        Task<Domain.Models.Task> InsertTask(Domain.Models.Task task);
        Task<int> UpdatTask(Domain.Models.Task task , int id);
        Task<int> DeleteTask( int id);
    }
}
