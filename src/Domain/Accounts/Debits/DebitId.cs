// <copyright file="DebitId.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Domain.Accounts.Debits
{
    using System;

    /// <summary>
    /// Debit <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Domain-Driven-Design-Patterns#value-object">Value Object Domain-Driven Design Pattern</see>.
    /// </summary>
    public readonly struct DebitId : IEquatable<DebitId>
    {
        private readonly Guid debitId;

        /// <summary>
        /// Initializes a new instance of the <see cref="DebitId"/> struct.
        /// </summary>
        /// <param name="debitId">DebitId Guid.</param>
        public DebitId(Guid debitId)
        {
            if (debitId == Guid.Empty)
            {
                throw new EmptyDebitIdException($"{nameof(debitId)} cannot be empty.");
            }

            this.debitId = debitId;
        }

        /// <summary>
        /// Converts into string.
        /// </summary>
        /// <returns>Serialized string.</returns>
        public override string ToString()
        {
            return this.debitId.ToString();
        }

        /// <summary>
        /// Converts into Guid.
        /// </summary>
        /// <returns>Guid representation.</returns>
        public Guid ToGuid() => this.debitId;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is DebitId debitIdObj)
            {
                return Equals(debitIdObj);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return debitId.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(DebitId left, DebitId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(DebitId left, DebitId right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(DebitId other)
        {
            return this.debitId == other.debitId;
        }
    }
}
