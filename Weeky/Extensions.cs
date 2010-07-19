using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Weeky
{
    public static class Extensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
            {
                action(item);
            }
        }
        public static string PropertyName<TObj, TRet>(this Expression<Func<TObj, TRet>> func)
        {
            var expr = func.Body as MemberExpression;
            if (expr == null)
            {
                throw new ArgumentException("Expression must be property access");
            }

            return expr.Member.Name;
        }

        public static void OnPropertyChanged<TVM, TProp>(
            this TVM rpc, Expression<Func<TVM, TProp>> expr) where TVM : IRaisePropertyChanged
        {
            rpc.RaisePropertyChanged(expr.PropertyName());
        }
    }

    public interface IRaisePropertyChanged
    {
       void RaisePropertyChanged(string prop);
    }
}
