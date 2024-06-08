using System.Text.Json;

namespace todolist_console
{
    class TaskManager
    {
        private List<Task> tasks = [];
        private List<int> userId = [];
        private const string FileName = "tasks.json";

        public TaskManager()
        {
            LoadTasks();
        }

        public void AddTask(string description)
        {
            var task = new Task { Id = GetNextId(), Description = description };
            tasks.Add(task);
            userId.Add(task.Id);
            SaveTasks();
            Console.WriteLine($"\nTask added: {task}");
        }

        public void RemoveTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
                userId.Remove(task.Id);
                SaveTasks();
                Console.WriteLine($"Task removed: {task}");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }

        public void MarkTaskAsCompleted(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
                SaveTasks();
                Console.WriteLine($"Task marked as completed: {task}");
            }
            else
            {
                Console.WriteLine($"Task with ID {id} not found.");
            }
        }

        public void ListTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("Tasks:");
            Console.WriteLine(new string('-', 30));
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }

        private void SaveTasks()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var jsonString = JsonSerializer.Serialize(tasks, options);
                File.WriteAllText(FileName, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving tasks: {ex.Message}");
            }
        }
        private void LoadTasks()
        {
            try
            {
                if (File.Exists(FileName))
                {
                    var jsonString = File.ReadAllText(FileName);
                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        tasks = JsonSerializer.Deserialize<List<Task>>(jsonString);
                        userId = tasks.Select(t => t.Id).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while loading tasks: {ex.Message}");
            }

        }
        private int GetNextId()
        {
            int id = 1;
            while (userId.Contains(id))
            {
                id++;
            }
            return id;
        }
        public bool HasTasks()
        {
            return tasks.Count > 0;
        }

        public void RemoveAllTasks()
        {
            tasks.Clear();
            userId.Clear();
            SaveTasks();
            Console.WriteLine("All tasks removed");
        }
    }
}
