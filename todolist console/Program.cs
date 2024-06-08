namespace todolist_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();

            while (true)
            {
                Console.WriteLine("To-Do List:");
                Console.WriteLine(new string('_', 30));
                Console.WriteLine("\n1 - Add Task");
                Console.WriteLine("2 - Remove Task");
                Console.WriteLine("3 - Mark Task as Completed");
                Console.WriteLine("4 - List Tasks");
                Console.WriteLine(new string('_', 30));
                Console.WriteLine("5 - Remove all tasks");
                Console.WriteLine("6 - Exit");
                Console.Write("\nSelect an option: ");

                var input = Console.ReadLine();

                Console.Clear();

                switch (input)
                {
                    case "1":
                       
                        while(true)
                        {
                            Console.Clear();
                            Console.WriteLine("----- Add Task -----");
                            Console.Write("Please enter description: ");

                            string description = Console.ReadLine()?.Trim();
                            
                            if(!string.IsNullOrEmpty(description))
                            {
                                taskManager.AddTask(description);
                                break;
                            }
                        }
                        break;

                    case "2":
                        if (!taskManager.HasTasks())
                        {
                            Console.WriteLine("----- Remove Task -----");
                            Console.WriteLine("No tasks");
                            break;
                        }
                        Console.WriteLine("----- Remove Task -----");
                        Console.Write("Enter task ID to remove: ");
                        if (int.TryParse(Console.ReadLine(), out int removeId))
                        {
                            taskManager.RemoveTask(removeId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;

                    case "3":
                        if (!taskManager.HasTasks())
                        {
                            Console.WriteLine("----- Mark Task as Completed -----");
                            Console.WriteLine("No tasks");
                            break;
                        }
                        Console.WriteLine("----- Mark Task as Completed -----");
                        Console.Write("Enter task ID to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int completeId))
                        {
                            taskManager.MarkTaskAsCompleted(completeId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID");
                        }
                        break;

                    case "4":
                        Console.WriteLine("----- List Tasks -----");
                        taskManager.ListTasks();
                        break;

                    case "5":
                        Console.Clear();
                        Console.WriteLine("----- Remove all tasks -----");
                        if (!taskManager.HasTasks())
                        {
                            Console.WriteLine("No tasks");
                            break;
                        }
                        
                        Console.WriteLine("You sure? Y/N");

                        bool Input = false;
                        bool repeatMessage = false;

                        while (!Input)
                        {
                            if(repeatMessage)
                            {
                                Console.Clear();
                                Console.WriteLine("----- Remove all tasks -----");
                                Console.WriteLine("Please enter Y or N");
                            }
                            var confirm = Console.ReadLine()?.ToUpper();
                            if (confirm == "Y")
                            {
                                taskManager.RemoveAllTasks();
                                Input = true;
                            }
                            else if (confirm == "N")
                            {
                                Input = true;
                            }
                            else
                            {
                                Console.WriteLine("Please enter Y or N");
                                repeatMessage = true;
                            }
                        } 
                        break;
                    case "6":
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
