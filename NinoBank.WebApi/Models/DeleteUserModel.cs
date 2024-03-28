namespace NinoBank.WebApi.Models
{
    /// <summary>
    /// Model representing a request to delete a user, identified by their email.
    /// </summary>
    public class DeleteUserModel
    {
        /// <summary>
        /// Gets or sets the email address of the user to be deleted.
        /// </summary>
        /// <value>
        /// The email address of the user.
        /// </value>
        public required string Email { get; set; }
    }
}
