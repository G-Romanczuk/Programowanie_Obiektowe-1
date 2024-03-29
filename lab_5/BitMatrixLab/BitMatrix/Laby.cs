﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laby
{
    public class Laby : IEnumerable<bool>
    {
        private BitArray[] data;
        public int Dimension { get; }

        public Laby(int n)
        {
            data = new BitArray[n]; // Tablica null-i
            for (int i = 0; i < n; i++)
            {
                data[i] = new BitArray(n);
            }
            Dimension = n;
        }

        public bool this[int i, int j]
        {
            get => data[i][j];
            set => data[i][j] = value;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    result += data[i][j] + " ";
                }
                result += "\n";
            }
            return result;
        }

        public IEnumerator<bool> GetEnumerator()
        {
            foreach (var d in data)
                foreach (bool x in d)
                    yield return x;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


    }
}