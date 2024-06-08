namespace todolist_console
{
    class Task
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"[{(IsCompleted ? "X" : " ")}] {Description} (ID: {Id})";
        }
    }
}
