using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookDatabase.Api.Data.Repositories.Users;
using Moq;
using Castle.Core.Logging;
using BookDatabase.Api.Configuration;
using BookDatabase.Api.Nhibernate.Sessions;
using BookDatabase.Api.Data.Transactions;
using BookDatabase.Api.BusinessObjects.Users;

namespace Delete
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var logger = new Mock<ILogger>(); 
            
            var configurationFile = new Mock<IApiConfigurationFile>();

            configurationFile.Setup(x => x.DatabaseOperationRetries).Returns(1);
            configurationFile.Setup(x => x.ConnectionString).Returns("Data Source=UK017284;Initial Catalog=BookDatabase;Integrated Security=True;Pooling=False");

            var sessionFactoryFactory = new SessionFactoryFactory
            {
                ConfigurationFile = configurationFile.Object,
            };
            
            IUserRepository userRepository = new UserRepository
            {
                Logger = logger.Object,
                ConfigurationFile = configurationFile.Object,
                SessionFactoryFactory = sessionFactoryFactory,
            };

            IUnitOfWork unitOfWork = new UnitOfWork
            {
                Logger = logger.Object,
                ConfigurationFile = configurationFile.Object,
                SessionFactoryFactory = sessionFactoryFactory,
            };

            var newUser = new User
            {
                UserName = "UserName11",
                Password = "Password",
                FirstName = "Steve",
                LastName = "Barker",
            };

            unitOfWork.SaveOrUpdate(newUser);
            unitOfWork.Commit();
            
            var users = userRepository.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine(user.UserName);
            }

            Console.ReadLine();
        }
    }
}
