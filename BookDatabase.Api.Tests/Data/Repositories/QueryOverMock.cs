//-----------------------------------------------------------------------
// <copyright file="QueryOverMock.cs" company="Steve Barker">
// Copyright Steve Barker 2012
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Moq;
using NHibernate;

namespace BookDatabase.Api.Tests.Data.Repositories
{
    /// <summary>
    /// Class to aid with testing of Session.QueryOver calls
    /// </summary>
    /// <typeparam name="T">The type of object returned by the mock</typeparam>
    public class QueryOverMock<T> : IQueryOver<T, T>
    {
        /// <summary>
        /// Stores items to return
        /// </summary>
        private readonly IList<T> items;

        /// <summary>
        /// Initializes a new instance of the QueryOverMock class
        /// </summary>
        /// <param name="items">Items to be returned</param>
        public QueryOverMock(IList<T> items)
        {
            this.items = items;
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public NHibernate.Criterion.Lambda.IQueryOverJoinBuilder<T, T> Left
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public NHibernate.Criterion.Lambda.IQueryOverSubqueryBuilder<T, T> WithSubquery
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public ICriteria RootCriteria
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public ICriteria UnderlyingCriteria
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public NHibernate.Criterion.Lambda.IQueryOverJoinBuilder<T, T> Full
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public NHibernate.Criterion.Lambda.IQueryOverJoinBuilder<T, T> Inner
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Gets a non implemented value
        /// </summary>
        public NHibernate.Criterion.Lambda.IQueryOverJoinBuilder<T, T> Right
        {
            get { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Performs a Where filter
        /// </summary>
        /// <param name="expression">Ignored: The filter query</param>
        /// <returns>Any items passed to the class on construction</returns>
        public IQueryOver<T, T> Where(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            var mock = new Mock<IQueryOver<T, T>>();
            mock.Setup(x => x.List()).Returns(items);

            return mock.Object;
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> And(NHibernate.Criterion.ICriterion expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> And(System.Linq.Expressions.Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> And(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> AndNot(System.Linq.Expressions.Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> AndNot(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverRestrictionBuilder<T, T> AndRestrictionOn(System.Linq.Expressions.Expression<Func<object>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverRestrictionBuilder<T, T> AndRestrictionOn(System.Linq.Expressions.Expression<Func<T, object>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverFetchBuilder<T, T> Fetch(System.Linq.Expressions.Expression<Func<T, object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias<U>(System.Linq.Expressions.Expression<Func<U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias(System.Linq.Expressions.Expression<Func<object>> path, System.Linq.Expressions.Expression<Func<object>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias<U>(System.Linq.Expressions.Expression<Func<T, U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias(System.Linq.Expressions.Expression<Func<T, object>> path, System.Linq.Expressions.Expression<Func<object>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias(System.Linq.Expressions.Expression<Func<object>> path, System.Linq.Expressions.Expression<Func<object>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> JoinAlias(System.Linq.Expressions.Expression<Func<T, object>> path, System.Linq.Expressions.Expression<Func<object>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path, System.Linq.Expressions.Expression<Func<U>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<IEnumerable<U>>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, IEnumerable<U>>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <param name="withClause">Parameter withClause not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, U>> path, System.Linq.Expressions.Expression<Func<U>> alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<U>> path, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="joinType">Parameter joinType not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, U>> path, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<U>> path, System.Linq.Expressions.Expression<Func<U>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, U>> path, System.Linq.Expressions.Expression<Func<U>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<U>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, U> JoinQueryOver<U>(System.Linq.Expressions.Expression<Func<T, U>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="alias">Parameter alias not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverLockBuilder<T, T> Lock(System.Linq.Expressions.Expression<Func<object>> alias)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverLockBuilder<T, T> Lock()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="projection">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> OrderBy(NHibernate.Criterion.IProjection projection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> OrderBy(System.Linq.Expressions.Expression<Func<object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> OrderBy(System.Linq.Expressions.Expression<Func<T, object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> OrderByAlias(System.Linq.Expressions.Expression<Func<object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="projections">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> Select(params NHibernate.Criterion.IProjection[] projections)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="projections">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> Select(params System.Linq.Expressions.Expression<Func<T, object>>[] projections)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="list">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> SelectList(Func<NHibernate.Criterion.Lambda.QueryOverProjectionBuilder<T>, NHibernate.Criterion.Lambda.QueryOverProjectionBuilder<T>> list)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="projection">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> ThenBy(NHibernate.Criterion.IProjection projection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> ThenBy(System.Linq.Expressions.Expression<Func<object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> ThenBy(System.Linq.Expressions.Expression<Func<T, object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="path">Parameter path not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverOrderBuilder<T, T> ThenByAlias(System.Linq.Expressions.Expression<Func<object>> path)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="resultTransformer">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> TransformUsing(NHibernate.Transform.IResultTransformer resultTransformer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> Where(NHibernate.Criterion.ICriterion expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> Where(System.Linq.Expressions.Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> WhereNot(System.Linq.Expressions.Expression<Func<bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> WhereNot(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverRestrictionBuilder<T, T> WhereRestrictionOn(System.Linq.Expressions.Expression<Func<object>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="expression">Parameter expression not used</param>
        /// <returns>Operation not implemented</returns>
        public NHibernate.Criterion.Lambda.IQueryOverRestrictionBuilder<T, T> WhereRestrictionOn(System.Linq.Expressions.Expression<Func<T, object>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="cacheMode">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> CacheMode(CacheMode cacheMode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="cacheRegion">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> CacheRegion(string cacheRegion)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> Cacheable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> ClearOrders()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <returns>Operation not implemented</returns>
        public IEnumerable<U> Future<U>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IEnumerable<T> Future()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <returns>Operation not implemented</returns>
        public IFutureValue<U> FutureValue<U>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IFutureValue<T> FutureValue()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <returns>Operation not implemented</returns>
        public IList<U> List<U>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IList<T> List()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> ReadOnly()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public int RowCount()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public long RowCountInt64()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <typeparam name="U">Type parameter not used</typeparam>
        /// <returns>Operation not implemented</returns>
        public U SingleOrDefault<U>()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public T SingleOrDefault()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="firstResult">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> Skip(int firstResult)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <param name="maxResults">Parameter not used</param>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T> Take(int maxResults)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> ToRowCountInt64Query()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not implemented
        /// </summary>
        /// <returns>Operation not implemented</returns>
        public IQueryOver<T, T> ToRowCountQuery()
        {
            throw new NotImplementedException();
        }
    }
}
