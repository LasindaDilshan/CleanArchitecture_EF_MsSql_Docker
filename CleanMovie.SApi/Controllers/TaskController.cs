using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanMovie.SApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Domain.Models.Task>>> Get()
        {
            try
            {                
                return Ok(await _taskService.GetAllTasks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpPost]
        public async Task<ActionResult<Domain.Models.Task>> CreateTask(TaskDto task)
        {
            try
            {
                Domain.Models.Task entityDTO = (Domain.Models.Task)task;
                return Ok(await _taskService.InsertTask(entityDTO));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpPut]
        public async Task<ActionResult<Domain.Models.Task>> UpdateTask(TaskDto task, int id)
        {
            try
            {
                Domain.Models.Task entity = (Domain.Models.Task)task;
                return Ok(await _taskService.UpdatTask(entity,  id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }
        [HttpDelete]
        public async Task<ActionResult<Domain.Models.Task>> DeleteTask( int id)
        {
            try
            {
                return Ok(await _taskService.DeleteTask( id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);

            }
        }

    }
}
