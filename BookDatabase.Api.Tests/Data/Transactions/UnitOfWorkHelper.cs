//-----------------------------------------------------------------------
// <copyright file="UnitOfWorkHelper.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using BookDatabase.Api.Configuration;
using BookDatabase.Api.Data.Transactions;
using BookDatabase.Api.Nhibernate.Sessions;
using Castle.Core.Logging;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Transactions
{
    /// <summary>
    /// Helper for unit of work
    /// </summary>
    public static class UnitOfWorkHelper
    {
        #region Public Static Methods

        /// <summary>
        /// Gets a new unit of work configured testing
        /// </summary>
        /// <param name="sessionMock">The session mock to use</param>
        /// <returns>A configured unit of work</returns>
        public static IUnitOfWork Get(Mock<ISession> sessionMock)
        {
            var loggerMock = new Mock<ILogger>();
            var configurationFileMock = new Mock<IApiConfigurationFile>();
            configurationFileMock.Setup(x => x.DatabaseOperationRetries).Returns(5);

            var sessionFactoryMock = new Mock<ISessionFactory>();
            sessionFactoryMock.Setup(x => x.OpenSession()).Returns(sessionMock.Object);

            var sessionFactoryFactoryMock = new Mock<SessionFactoryFactory>();
            sessionFactoryFactoryMock.Setup(x => x.GetInstance()).Returns(sessionFactoryMock.Object);

            return new UnitOfWork
            {
                ConfigurationFile = configurationFileMock.Object,
                Logger = loggerMock.Object,
                SessionFactoryFactory = sessionFactoryFactoryMock.Object,
            };
        }

        #endregion
    }
}
