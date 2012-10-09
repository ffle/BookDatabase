//-----------------------------------------------------------------------
// <copyright file="BusinessObject.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace BookDatabase.Api.BusinessObjects
{
    /// <summary>
    /// Abstract class from which all business objects inherit.
    /// </summary>
    [Serializable]
    public abstract class BusinessObject
    {
        #region Public Properties

        /// <summary>
        /// Gets the Id of the object
        /// </summary>
        public int? Id { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the object is new
        /// </summary>
        public bool IsNew
        {
            get
            {
                return Id == null;
            }
        }

        #endregion

        #region Public Static Operator Methods

        /// <summary>
        /// Compares two business objects for equality
        /// </summary>
        /// <param name="item1">The first business object</param>
        /// <param name="item2">The second business object</param>
        /// <returns>True if the objects are equal</returns>
        public static bool operator ==(BusinessObject item1, BusinessObject item2)
        {
            if ((object)item1 == null && (object)item2 == null)
            {
                return true;
            }

            if ((object)item1 == null || (object)item2 == null)
            {
                return false;
            }

            return item1.Equals(item2);
        }

        /// <summary>
        /// Compares two business objects for inequality
        /// </summary>
        /// <param name="item1">The first business object</param>
        /// <param name="item2">The second business object</param>
        /// <returns>True if the objects are equal</returns>
        public static bool operator !=(BusinessObject item1, BusinessObject item2)
        {
            return !(item1 == item2);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Checks to see if an other instance is equal to this one
        /// </summary>
        /// <param name="other">The other instance</param>
        /// <returns>True if the instances are equal</returns>
        public bool Equals(BusinessObject other)
        {
            // If the other is null they can't be equal:
            if (other == null)
            {
                return false;
            }

            // Handle the case of comparing two new objects:
            if (IsNew && other.IsNew)
            {
                return ReferenceEquals(this, other);
            }

            // Otherwise the two are equal if their Ids are equal:
            return Equals(other.Id, Id);
        }

        #endregion

        #region Public Override Methods

        /// <summary>
        /// Gets the hash code of the object
        /// </summary>
        /// <returns>The hash code</returns>
        public override int GetHashCode()
        {
            // Check if the item is new:
            if (Id != null)
            {
                // For existing items, make a hash code based on the Id:
                return Id.GetHashCode();
            }

            return base.GetHashCode();
        }

        /// <summary>
        /// Checks to see if an other instance is equal to this one
        /// </summary>
        /// <param name="obj">The other instance</param>
        /// <returns>True if the instances are equal</returns>
        public override bool Equals(object obj)
        {
            // Cast the incoming item as the correct type:
            var other = obj as BusinessObject;
            return Equals(other);
        }

        #endregion
    }
}
