﻿// TODO: Parallelize block-swap algorithm to speedup in-place merge, possibly using SSE with instruction to reverse order within an SSE Vector
//       Or, maybe SSE rotation/reverse order can be avoided, knowing that we'll be rotating it back in the following pass.
// TODO: Parallelize block-swap algorithms to see if there is a benefit, now that unit testing and benchmarking in C# is in place
//       Try simple things first like scalar parallelism of reversal algorithms middle stage of reversal by running the two portions reversal
//       in parallel to see if it speeds up at all.
using System;
using System.Collections.Generic;
using System.Text;

namespace HPCsharp
{
    static public partial class Algorithm
    {
        public static void Swap<T>(this T[] array, int indexA, int indexB)
        {
            T temp        = array[indexA];
            array[indexA] = array[indexB];
            array[indexB] = temp;
        }

        public static void Swap<T>(this T[] array, int indexA, int indexB, int length, bool reverse = false)
        {
            if (!reverse)
            {
                while (length-- > 0)
                    Swap(array, indexA++, indexB++);
            }
            else
            {
                int currIndexB = indexB + length - 1;
                while (length-- > 0)
                    Swap(array, indexA++, currIndexB--);
            }
        }

        public static void Swap<T>(ref T B, T[] array, int indexA)
        {
            T temp        = array[indexA];
            array[indexA] = B;
            B             = temp;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        // reverse/mirror a range from l to r, inclusively, in-place
        public static void Reversal<T>(this T[] array, int l, int r)
        {
            for(; l < r; l++, r--)
            {
                T temp   = array[l];
                array[l] = array[r];
                array[r] = temp;
            }
        }

        // Swaps two sequential subarrays ranges a[ l .. m ] and a[ m + 1 .. r ]
        public static void BlockSwapReversal<T>(T[] array, int l, int m, int r)
        {
            array.Reversal(l,     m);
            array.Reversal(m + 1, r);
            array.Reversal(l,     r);
        }

        public static void BlockSwapReversalReverseOrder<T>(T[] array, int l, int m, int r)
        {
            array.Reversal(l, r);
            int mInDestination = r - (m - l + 1);
            array.Reversal(l, mInDestination);
            array.Reversal(mInDestination + 1, r);
        }

        public static void BlockSwapGriesMills<T>(T[] array, int l, int m, int r)
        {
            int rotdist = m - l + 1;
            int n = r - l + 1;
            if (rotdist == 0 || rotdist == n) return;
            int p, i = p = rotdist;
            int j = n - p;
            while (i != j)
            {
                if (i > j)
                {
                    array.Swap(p - i, p, j);
                    i -= j;
                }
                else
                {
                    array.Swap(p - i, p + j - i, i);
                    j -= i;
                }
            }
            array.Swap(p - i, p, i);
        }

        // Greatest Common Divisor.  Assumes that neither input is zero
        public static int GreatestCommonDivisor(int i, int j)
        {
            if (i == 0) return j;
            if (j == 0) return i;
            while (i != j)
            {
                if (i > j) i -= j;
                else j -= i;
            }
            return i;
        }

        public static void BlockSwapJugglingBentley<T>(T[] array, int l, int m, int r)
        {
            int uLength = m - l + 1;
            int vLength = r - m;
            if (uLength <= 0 || vLength <= 0) return;
            int rotdist = m - l + 1;
            int n = r - l + 1;
            int gcdRotdistN = GreatestCommonDivisor(rotdist, n);
            for (int i = 0; i < gcdRotdistN; i++)
            {
                // move i-th values of blocks
                T t = array[i];
                int j = i;
                while (true)
                {
                    int k = j + rotdist;
                    if (k >= n)
                        k -= n;
                    if (k == i) break;
                    array[j] = array[k];
                    j = k;
                }
                array[j] = t;
            }
        }
    }
}
