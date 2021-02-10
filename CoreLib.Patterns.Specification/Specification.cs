using System;
using System.Linq.Expressions;

namespace CoreLib.Patterns.Specification
{
    public abstract class Specification<T>
    {
        #region Public Functions
        public abstract Expression<Func<T, bool>> ToExpression(); 
        public bool IsSatisfiedBy(T entity)
        {
            var predicate = ToExpression().Compile();
            return predicate(entity);
        }
        #endregion
    }

    internal sealed class AndSpecification<T> : Specification<T>
    {
        #region Fields
        private readonly Specification<T> _left;
        private readonly Specification<T> _right; 
        #endregion

        #region Constructors
        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        #endregion

        #region Public Functions
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
            return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters);
        } 
        #endregion
    }

    internal sealed class OrSpecification<T> : Specification<T>
    {
        #region Fields
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;
        #endregion

        #region Constructors
        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }
        #endregion

        #region Public Functions
        public override Expression<Func<T, bool>> ToExpression()
        {
            var leftExpression = _left.ToExpression();
            var rightExpression = _right.ToExpression();

            BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
            return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters);
        }
        #endregion
    }

    internal sealed class NotSpecification<T> : Specification<T>
    {
        #region Fields
        private readonly Specification<T> _specification; 
        #endregion

        #region Constructors
        public NotSpecification(Specification<T> specification)
        {
            _specification = specification;
        }
        #endregion

        #region Public Functions
        public override Expression<Func<T, bool>> ToExpression()
        {
            var specificationExpression = _specification.ToExpression();

            UnaryExpression notExpression = Expression.Not(specificationExpression.Body);
            return Expression.Lambda<Func<T, bool>>(notExpression, specificationExpression.Parameters);
        }
        #endregion
    }
}
