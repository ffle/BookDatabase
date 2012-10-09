//-----------------------------------------------------------------------
// <copyright file="BusinessObjectClassMap.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects;
using FluentNHibernate.Mapping;

namespace BookDatabase.Api.Mappings
{
    /// <summary>
    /// Abstract class from which all generic business object mappings should inherit
    /// </summary>
    /// <typeparam name="T">The type of business object being mapped</typeparam>
    public abstract class BusinessObjectClassMap<T> : ClassMap<T> where T : BusinessObject
    {
        #region Protected Constructors

        /// <summary>
        /// Initializes a new instance of the BusinessObjectClassMap class
        /// </summary>
        protected BusinessObjectClassMap()
        {
            Not.LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity();
        }

        #endregion
    }
}
