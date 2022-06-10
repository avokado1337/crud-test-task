namespace Data_Access_Layer.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TaskStatus Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

    }
}
