// <copyright file="Name.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Customers.ValueObjects
{
    /// <summary>
    /// Name <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#entity">Entity Design Pattern</see>.
    /// </summary>
    public readonly struct Name : System.IEquatable<Name>
    {
        private readonly string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> struct.
        /// </summary>
        /// <param name="text">Name.</param>
        public Name(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new NameShouldNotBeEmptyException($"The {nameof(text)} field is required.");
            }

            this.text = text;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>string.</returns>
        public override string ToString()
        {
            return this.text;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Name nameObj)
            {
                return Equals(nameObj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.text.GetHashCode(System.StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Name left, Name right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Name left, Name right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Name other)
        {
            return this.text == other.text;
        }
    }
}
