namespace NinoBank.WebApi.Models
{
    /// <summary>
    /// Model representing a transaction request, including sender, receiver, and amount details.
    /// </summary>
    public class AddTransactionModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the receiver of the transaction.
        /// </summary>
        /// <value>
        /// The receiver's unique identifier.
        /// </value>
        public Guid ReceiverId { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        /// <value>
        /// The transaction amount as a decimal.
        /// </value>
        public decimal Amount { get; set; }
    }
}
