namespace Sample.WebAPI.ViewModels
{
    /// <summary>
    /// Resource model
    /// </summary>
    public class ResourceModel
    {
        /// <summary>
        /// Resource id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// project id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// People id
        /// </summary>
        public int PeopleId { get; set; }

        /// <summary>
        /// Resource description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Resource details
        /// </summary>
        public PeopleModel Person { get; set; } 
    }
}