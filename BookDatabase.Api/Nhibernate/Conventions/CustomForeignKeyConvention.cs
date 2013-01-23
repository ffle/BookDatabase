//-----------------------------------------------------------------------
// <copyright file="CustomForeignKeyConvention.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace BookDatabase.Api.Nhibernate.Conventions
{
    /// <summary>
    /// Custom foreign key convention to allow foreign key fields to appear as {Table}Id
    /// </summary>
    public class CustomForeignKeyConvention : ForeignKeyConvention
    {
        /// <summary>
        /// Gets the name of the key
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="type">The property type</param>
        /// <returns>The key name</returns>
        protected override string GetKeyName(Member property, Type type)
        {
            if (property != null)
            {
                return property.Name + "Id";
            }

            if (type != null)
            {
                return type.Name + "Id";
            }

            // If both are null, we throw an exception:
            throw new ArgumentNullException("property", "The property and type parameters cannot both be null");
        }
    }
}
