using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<int> DeleteTask(int id)
        {
           return await _taskRepository.DeleteTask(id);
        }

        public async Task<List<Domain.Models.Task>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

      
        public async Task<Domain.Models.Task> InsertTask(Domain.Models.Task task)
        {
            return await _taskRepository.InsertTask(task);
        }

        public async Task<int> UpdatTask(Domain.Models.Task task, int id)
        {
            return await _taskRepository.UpdateTask(task , id);
        }
    }
}
