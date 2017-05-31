using Sample.WebAPI.ViewModels;

namespace Sample.WebAPI.Models
{
    /// <summary>
    /// Response helper class
    /// </summary>
    public class ResponseHelper
    {
        /// <summary>
        /// Create success response object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns>
        /// Return success response object
        /// </returns>
        public static ResponseModel<T> CreateSuccessResponse<T>(T content) where T : class
        {
            var result = new ResponseModel<T>() { Content = content, Success = true };

            return result;
        }

        /// <summary>
        /// Create failure response object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns>
        /// Return failure response object
        /// </returns>
        public static ResponseModel<T> CreateFailureResponse<T>(string message) where T : class
        {
            var result = new ResponseModel<T>() { Message = message, Success = false };

            return result;
        }
    }
}