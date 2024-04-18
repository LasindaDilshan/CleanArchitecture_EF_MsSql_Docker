using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.DTOs
{

    public record TaskDto

    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public static explicit operator Domain.Models.Task(TaskDto entity)
        {
            return new Domain.Models.Task
            {
                Title = entity.Title,
                Description = entity.Description,
                DueDate = entity.DueDate
            };
        }
    }


}
