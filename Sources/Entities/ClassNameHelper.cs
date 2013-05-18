using System;
using System.Linq.Expressions;
using Entities.Entity;

namespace Entities
{
	//http://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
	public static class ClassNameHelper
	{
		public static string GetFieldName<T>(Expression<Func<T, object>> action)
			where T : class, IEntityBase
		{
			MemberExpression expression = GetMemberInfo(action);
			return expression.Member.Name;
		}

		private static MemberExpression GetMemberInfo(Expression method)
		{
			var lambda = method as LambdaExpression;
			if (lambda == null)
			{
				throw new ArgumentNullException("method");
			}

			MemberExpression memberExpr = null;

			if (lambda.Body.NodeType == ExpressionType.Convert)
			{
				memberExpr = ((UnaryExpression) lambda.Body).Operand as MemberExpression;
			} else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
			{
				memberExpr = lambda.Body as MemberExpression;
			}

			if (memberExpr == null)
			{
				throw new ArgumentException("method");
			}

			return memberExpr;
		}
	}
}