using System.Linq.Expressions;
using System.Reflection;

namespace CRUDGen.Extensions
{
    public static class TypeExtension
    {
        public static object GetPropValue(this object src, string propName)
        {
            var result =  src.GetType().GetProperty(propName)?.GetValue(src, null);
            return result != null ? result : new object();
        }

        public static Expression<Func<TEntity, bool>> GetExpresion<TEntity>(int id, string _primaryKeyName) where TEntity : class
        {
            Type typeTEntity = typeof(TEntity);
            var param = Expression.Parameter(typeTEntity);
            var body = Expression.Equal(Expression.PropertyOrField(param, _primaryKeyName), Expression.Constant(id));
            var expr = Expression.Lambda<Func<TEntity, bool>>(body, param);
            return expr;
        }

        public static Expression<Func<TEntity, bool>> GetExpresionAll<TEntity>() where TEntity : class
        {
            Type typeTEntity = typeof(TEntity);
            var param = Expression.Parameter(typeTEntity);
            var body = Expression.Equal(Expression.PropertyOrField(param, "ESBORRAT"), Expression.Constant("NO"));
            var expr = Expression.Lambda<Func<TEntity, bool>>(body, param);
            return expr;
        }
    }
}
