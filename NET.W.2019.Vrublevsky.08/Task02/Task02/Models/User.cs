using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Task02.Models
{
    /// <summary>
    /// Instance of a user.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last naem.</param>
        public User(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if (!this.Checker())
            {
                throw new ArgumentException("User's data is incorrect.");
            }
        }

        /// <summary>
        /// Gets or sets first name.
        /// </summary>
        /// <value>
        /// First name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name.
        /// </summary>
        /// <value>
        /// Last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Returns <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }

        /// <summary>
        /// Return a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode()
        {
            return (this.FirstName + this.LastName).GetHashCode();
        }

        private bool Checker()
        {
            Regex name = new Regex(@"^[a-zA-z'-]+$");

            if (name.IsMatch(this.FirstName) && name.IsMatch(this.LastName))
            {
                return true;
            }

            return false;
        }
    }
}
