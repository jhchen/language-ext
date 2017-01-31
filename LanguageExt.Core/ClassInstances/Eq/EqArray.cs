﻿using LanguageExt.TypeClasses;
using static LanguageExt.TypeClass;

namespace LanguageExt.ClassInstances
{
    /// <summary>
    /// Array equality
    /// </summary>
    public struct EqArray<EQ, A> : Eq<A[]> where EQ : struct, Eq<A>
    {
        public static readonly EqArray<EQ, A> Inst = default(EqArray<EQ, A>);

        /// <summary>
        /// Equality test
        /// </summary>
        /// <param name="x">The left hand side of the equality operation</param>
        /// <param name="y">The right hand side of the equality operation</param>
        /// <returns>True if x and y are equal</returns>
        public bool Equals(A[] x, A[] y)
        {
            if (x == null) return y == null;
            if (y == null) return false;
            if (x.Length != y.Length) return false;

            for (var i = 0; i < x.Length; i++)
            {
                if (!equals<EQ, A>(x[i], y[i])) return false;
            }
            return true;
        }

        public static implicit operator EqArray<EQ,A>(EQ eq) =>
            EqArray<EQ,A>.Inst;
    }
}