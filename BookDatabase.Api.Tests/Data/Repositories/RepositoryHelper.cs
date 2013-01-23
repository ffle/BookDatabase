//-----------------------------------------------------------------------
// <copyright file="RepositoryHelper.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.BusinessObjects;
using BookDatabase.Api.Configuration;
using BookDatabase.Api.Data.Repositories;
using BookDatabase.Api.Nhibernate.Sessions;
using Castle.Core.Logging;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Repositories
{
    /// <summary>
    /// Helper for repositories
    /// </summary>
    public static class RepositoryHelper
    {
        /// <summary>
        /// Gets a new reposiory configured for testing
        /// </summary>
        /// <typeparam name="TRepository">The type of the repository</typeparam>
        /// <typeparam name="TBusinessObject">The type of business object</typeparam>
        /// <param name="sessionMock">The session mock to use</param>
        /// <returns>A configured repository</returns>
        public static TRepository Get<TRepository, TBusinessObject>(Mock<ISession> sessionMock)
            where TBusinessObject : BusinessObject
            where TRepository : Repository<TBusinessObject>, new()
        {
            var loggerMock = new Mock<ILogger>();
            var configurationFileMock = new Mock<IApiConfigurationFile>();

            var sessionFactoryMock = new Mock<ISessionFactory>();
            sessionFactoryMock.Setup(x => x.OpenSession()).Returns(sessionMock.Object);
            
            var sessionFactoryFactoryMock = new Mock<SessionFactoryFactory>();
            sessionFactoryFactoryMock.Setup(x => x.GetInstance()).Returns(sessionFactoryMock.Object);

            return new TRepository
            {
                ConfigurationFile = configurationFileMock.Object,
                Logger = loggerMock.Object,
                SessionFactoryFactory = sessionFactoryFactoryMock.Object,
            };
        }
    }
}
