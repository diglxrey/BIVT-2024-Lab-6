using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6 
{
    public class Purple_1 
    {
        public struct Participant 
        {
            private string _name;
            private string _surname;
            private double[] _coefs;
            private int[,] _marks;
            private int _jumpN;


            public string Name => _name;
            public string Surname => _surname;
            public double[] Coefs
            {
                get
                {
                    if (_coefs == null) return null;
                    var copy1 = new double[_coefs.Length];
                    Array.Copy(_coefs, copy1, _coefs.Length);
                    return copy1;
                }
            }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    var copy2 = new int[_marks.GetLength(0), _marks.GetLength(1)];
                    Array.Copy(_marks, copy2, _marks.Length);
                    return copy2;
                }
            }
            public double TotalScore { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _coefs = new double[4] { 2.5, 2.5, 2.5, 2.5 };
                _marks = new int[4, 7];
                _jumpN = 0;
                TotalScore = 0;
            }
            public void SetCriterias(double[] coefs)
            {
                if (_coefs == null || coefs == null || coefs.Length != 4) return;
                Array.Copy(coefs, _coefs, coefs.Length);
            }

            public void Jump(int[] marks)
            {
                if (marks == null || _marks == null || _coefs == null || _jumpN >= 4 || marks.Length != 7) return;

                for (int i1 = 0; i1 < marks.Length; i1++) _marks[_jumpN, i1] = marks[i1];

                TotalScore += (marks.Sum() - marks.Min() - marks.Max()) * _coefs[_jumpN];

                _jumpN++;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null) return;

                for(int i2 = 1, j1 = 2; i2 < array.Length;)
                {
                    if (i2 == 0 || array[i2].TotalScore <= array[i2 - 1].TotalScore)
                    {
                        i2 = j1;
                        j1++;
                    }
                    else
                    {
                        var temp = array[i2];
                        array[i2] = array[i2 - 1];
                        array[i2 - 1] = temp;
                        i2--;
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"Name {_name}");
                Console.WriteLine($"Surname {_surname}");


                Console.WriteLine("Coefs");
                foreach (var coef in _coefs)
                {
                    Console.Write($"{coef} ");
                }

                Console.WriteLine("Marks");
                int a1 = _marks.GetLength(0);
                int b2 = _marks.GetLength(1);
                for (int i3 = 0; i3 < a1; i3++)
                {
                    for (int j2 = 0; j2 < b2; j2++)
                    {
                        Console.Write($"{_marks[i3, j2]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine($"Total score {TotalScore}");
            }
        }
    }
}
