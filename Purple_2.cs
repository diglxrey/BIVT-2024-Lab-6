using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6
{
    public class Purple_2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int _distance;
            private int[] _marks;


            public string Name => _name;
            public string Surname => _surname;
            public int Distance => _distance;
            public int[] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    var copy1 = new int[_marks.Length];
                    Array.Copy(_marks, copy1, _marks.Length);
                    return copy1;
                }
            }
            public int Result { get; private set; }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _distance = 0;
                _marks = new int[5];
                Result = 0;
            }
            public void Jump(int distance, int[] marks)
            {
                if (marks == null || marks.Length != 5 || _marks == null) return;
                for (int i1 = 0; i1 < 5; i1++)
                    _marks[i1] = marks[i1];
                Result = marks.Sum() - marks.Min() - marks.Max() + 60 + (distance - 120) * 2;
                if (Result < 0) Result = 0;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null) return;
                for (int i2 = 1, j1 = 2; i2 < array.Length;)
                {
                    if (i2 == 0 || array[i2].Result <= array[i2 - 1].Result)
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
                Console.WriteLine($"Name {_name}    Surname {_surname}    Result {Result}");
            }
        }
    }
}
