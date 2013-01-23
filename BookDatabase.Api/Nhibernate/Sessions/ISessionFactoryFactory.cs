//-----------------------------------------------------------------------
// <copyright file="ISessionFactoryFactory.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using NHibernate;

namespace BookDatabase.Api.Nhibernate.Sessions
{
    /// <summary>
    /// Interface for a factory to make SessionFactory objects
    /// </summary>
    public interface ISessionFactoryFactory
    {
        /// <summary>
        /// Gets a SessionFactory
        /// </summary>
        /// <returns>A configured SessionFactory</returns>
        ISessionFactory GetInstance();
    }
}
