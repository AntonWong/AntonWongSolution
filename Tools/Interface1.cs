using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework;
using EntityFramework.Batch;
using EntityFramework.Extensions;
using EntityFramework.Mapping;

namespace Tools
{
    public static class GetSqlText
    {
        public static string DeleteSql<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, bool>> filterExpression) where TEntity : class
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (filterExpression == null)
                throw new ArgumentNullException("filterExpression");

            return source.Where(filterExpression).Delete();
        }
        public static string Delete<TEntity>(this IQueryable<TEntity> source)
                   where TEntity : class
        {
            ObjectQuery<TEntity> sourceQuery = source.ToObjectQuery();
            if (sourceQuery == null)
                throw new ArgumentException("The query must be of type ObjectQuery or DbQuery.", "source");

            ObjectContext objectContext = sourceQuery.Context;
            if (objectContext == null)
                throw new ArgumentException("The ObjectContext for the source query can not be null.", "source");
         
            EntityMap entityMap = sourceQuery.GetEntityMap<TEntity>();
            if (entityMap == null)
                throw new ArgumentException("Could not load the entity mapping information for the query ObjectSet.", "source");

            return InternalDelete(objectContext, entityMap, sourceQuery);
        }

        #region  1
        public static string InternalDelete<TEntity>(ObjectContext objectContext, EntityMap entityMap, ObjectQuery<TEntity> query, bool async = false)
            where TEntity : class
        {

            var innerSelect = GetSelectSql(query, entityMap);

            var sqlBuilder = new StringBuilder(innerSelect.Length * 2);

            sqlBuilder.Append("DELETE ");
            sqlBuilder.Append(entityMap.TableName);
            sqlBuilder.AppendLine();

            sqlBuilder.AppendFormat("FROM {0} AS j0 INNER JOIN (", entityMap.TableName);
            sqlBuilder.AppendLine();
            sqlBuilder.AppendLine(innerSelect);
            sqlBuilder.Append(") AS j1 ON (");

            bool wroteKey = false;
            foreach (var keyMap in entityMap.KeyMaps)
            {
                if (wroteKey)
                    sqlBuilder.Append(" AND ");

                sqlBuilder.AppendFormat("j0.[{0}] = j1.[{0}]", keyMap.ColumnName);
                wroteKey = true;
            }
            sqlBuilder.Append(")");
            return sqlBuilder.ToString();
        }
        #endregion

        private static string GetSelectSql<TEntity>(ObjectQuery<TEntity> query, EntityMap entityMap)
           where TEntity : class
        {
            // TODO change to esql?

            // changing query to only select keys
            var selector = new StringBuilder(50);
            selector.Append("new(");
            foreach (var propertyMap in entityMap.KeyMaps)
            {
                if (selector.Length > 4)
                    selector.Append((", "));

                selector.Append(propertyMap.PropertyName);
            }
            selector.Append(")");

            var selectQuery = DynamicQueryable.Select(query, selector.ToString());
            var objectQuery = selectQuery as ObjectQuery;

            if (objectQuery == null)
                throw new ArgumentException("The query must be of type ObjectQuery.", "query");

            string innerJoinSql = objectQuery.ToTraceString();

            return innerJoinSql;
        }

        
    }
}
