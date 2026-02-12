namespace ToDoAPI
{
    public class Notes
    {
        #region Propriedades Privadas
        public string Id { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Priority { get; set; }
        public string? Category { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        #endregion
    }
}
