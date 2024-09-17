using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        // GET: api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetTasks()
        {
            // Veritabanından görevleri döndüreceğiz (şu anlık basit bir liste döndürüyoruz)
            return new string[] { "Task1", "Task2" };
        }

        // GET: api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<string> GetTaskById(int id)
        {
            // ID'ye göre görev döndür
            return "Task " + id;
        }

        // POST: api/tasks
        [HttpPost]
        public ActionResult<string> CreateTask([FromBody] string task)
        {
            // Görev oluştur
            return "Task created: " + task;
        }

        // PUT: api/tasks/{id}
        [HttpPut("{id}")]
        public ActionResult<string> UpdateTask(int id, [FromBody] string updatedTask)
        {
            // Görevi güncelle
            return "Task " + id + " updated to: " + updatedTask;
        }

        // DELETE: api/tasks/{id}
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTask(int id)
        {
            // Görev sil
            return "Task " + id + " deleted";
        }

        // POST: api/tasks/assign
        [HttpPost("assign")]
        public ActionResult<string> AssignTask([FromBody] string taskAssignment)
        {
            // Görev atama işlemi
            return "Task assigned: " + taskAssignment;
        }
    }
}
