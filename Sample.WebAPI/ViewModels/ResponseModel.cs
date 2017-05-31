namespace Sample.WebAPI.ViewModels
{
    /// <summary>
    /// Response model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ResponseModel<T> where T : class
    {
        /// <summary>
        /// True if response valid else false
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Contains error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Response content
        /// </summary>
        public T Content { get; set; }
    }
}