using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Task02GenericMatrix.Matrix;

namespace Task02GenericMatrix.Operations
{
    /// <summary>
    /// Additional extension to matrix class.
    /// </summary>
    public static class AdditionalOfMatrixs
    {
        /// <summary>
        /// Adds the specified matrix.
        /// </summary>
        /// <typeparam name="T">Parameter type.</typeparam>
        /// <param name="matrix1">First matrix.</param>
        /// <param name="matrix2">Second matrix.</param>
        /// <returns>Sum of matrixes.</returns>
        public static Matrix<T> Add<T>(this Matrix<T> matrix1, Matrix<T> matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException($"{nameof(matrix1)} and {nameof(matrix2)} can't be null.");
            }

            if (matrix1.Size != matrix2.Size)
            {
                throw new InvalidOperationException($"Can't add {nameof(matrix1)} to {nameof(matrix2)}: matrises have different sizes.");
            }

            T[,] array = new T[matrix1.Size, matrix1.Size];
            for (int i = 0; i < matrix1.Size; i++)
            {
                for (int j = 0; j < matrix1.Size; j++)
                {
                    array[i, j] = AddFunc(matrix1[i, j], matrix2[i, j]);
                }
            }

            if (matrix1.GetType() == typeof(DiagonalMatrix<T>) && matrix2.GetType() == typeof(DiagonalMatrix<T>))
            {
                return new DiagonalMatrix<T>(array);
            }

            if (matrix1.GetType() == typeof(SimmetricMatrix<T>) || matrix2.GetType() == typeof(SimmetricMatrix<T>))
            {
                if (matrix1.GetType() != typeof(SquareMatrix<T>) && matrix2.GetType() != typeof(SquareMatrix<T>))
                {
                    return new SimmetricMatrix<T>(array);
                }
            }

            return new SquareMatrix<T>(array);
        }

        private static T AddFunc<T>(T matrix1, T matrix2)
        {
            ParameterExpression p1 = Expression.Parameter(typeof(T), "matrix1");
            ParameterExpression p2 = Expression.Parameter(typeof(T), "matrix2");

            if (typeof(T) == typeof(string))
            {
                dynamic a = matrix1;
                dynamic b = matrix2;

                if (a == null || b == null)
                {
                    return default(T);
                }

                return a + b;
            }

            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(Expression.Add(p1, p2), p1, p2).Compile();

            return add(matrix1, matrix2);
        }
    }
}
