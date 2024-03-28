namespace NinoBank.WebApi.Models
{
    /// <summary>
    /// Model for registering a new user, including their email, name, password, and initial balance.
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// Gets or sets the email address of the user. This is used as a unique identifier for the user.
        /// </summary>
        /// <value>The user's email address.</value>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the first name of the user.
        /// </summary>
        /// <value>The user's first name.</value>
        public required string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the user.
        /// </summary>
        /// <value>The user's last name.</value>
        public required string LastName { get; set; }

        /// <summary>
        /// Gets or sets the password for the user. This will be hashed and not stored in plain text.
        /// </summary>
        /// <value>The user's password.</value>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the initial balance of the user's account. This is optional and can be zero.
        /// </summary>
        /// <value>The initial balance of the user's account.</value>
        public decimal Balance { get; set; }
    }

}
