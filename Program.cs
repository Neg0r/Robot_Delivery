using System;
using System.Text;

namespace Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            //5x5 (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)
            //15x76543 (1, 3) (4, 4) (1, 3) (4, 4) (4, 4) (1, 3) (4, 4)
            //5x5 (1, 3) (4, 4) (4, 2)
            //5x5 (0, 0) (1, 3) (4,4) (4, 2) (4, 2) (0, 1) (3, 2) (2, 3) (4, 1)



            Console.WriteLine("Введите область и маршрут робота");
            string str = Console.ReadLine();
            //Console.WriteLine(str);
            str = str.Replace(",", ", ");
            str = str.Replace("  ", " ");

            Console.WriteLine(str);

            string Result = null;


            //нахождение 
            int indexOfx = str.IndexOf('x'); //по идее 1
            //Console.WriteLine(indexOfx);
            int indexOfSpace = str.IndexOf(' ');
            //Console.WriteLine(indexOfSpace);


            string l = str.Substring(0, indexOfx);
            //Console.WriteLine(l);
            int L = Convert.ToInt32(l);
            Console.WriteLine($"Длина = {L}");


            string w = str.Substring(indexOfx + 1, indexOfSpace - indexOfx);
            int W = Convert.ToInt32(w);
            Console.WriteLine($"Ширина = {W}");


            //колличество перемещений
            char key1 = '(';


            int count = 0;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == key1) count++;
            //Console.WriteLine(count);



            string[] coord = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //список координат: с нечётн. индексом Ох, с чётн. Оу. (на 0 размер поля)
            foreach (string s in coord)
            {
                //Console.WriteLine(s);
            }

            //ось абсцисс
            int bkb = 0; // координата по Ох, из списка
            int numb = 0; //количество буковок
            int lst = 0;    //предыдущее значение bkb
            for (int i = 1; i < count * 2 + 1; i += 2)
            {
                string s1 = coord[i];
                lst = bkb;
                bkb = Convert.ToInt32(s1[1..^1]);
                //Console.WriteLine(bkb);

                numb = bkb - lst;

                if (numb >= 0)//= если не двигается по абсциссе
                {
                    for (int j = 0; j < numb; j += 1)
                    {
                        Result += "E";//вправо
                    }
                    Result += "D";
                }
                else
                {
                    numb = Math.Abs(numb);
                    for (int k = 0; k < numb; k += 1)
                    {
                        Result += "W";//влево
                    }
                    Result += "D";
                }
            }



            Console.WriteLine("___________________________________");



            //ось ординат
            int mkb = 0;
            numb = 0;
            lst = 0;
            string ubr = null;

            for (int i = 2; i < count * 2 + 1; i += 2)
            {
                string s2 = coord[i];
                lst = mkb;
                mkb = Convert.ToInt32(s2.Substring(0, 1));
                //Console.WriteLine(mkb);
                numb = mkb - lst;



                if (numb >= 0)
                {
                    for (int j = 0; j < numb; j += 1)
                    {
                        ubr += "N";//вверх

                    }
                    ubr += ' ';

                    int indexOfED = Result.IndexOf("ED");
                    int indexOfDED = Result.IndexOf("DED");//на случай если придётся доставлять на базе (0, 0)
                    int indexOfWD = Result.IndexOf("WD");
                    int indexOfDD = Result.IndexOf("DD");
                    if (indexOfED < 0)
                    {
                        indexOfED = 100;
                    }
                    if (indexOfDED < 0)
                    {
                        indexOfDED = 100;
                    }
                    if (indexOfWD < 0)
                    {
                        indexOfWD = 100;
                    }
                    if (indexOfDD < 0)
                    {
                        indexOfDD = 100;
                    }

                    /*Console.WriteLine($"Индекс дд= {indexOfDD }");
                    Console.WriteLine($"Индекс вд= {indexOfWD }");
                    Console.WriteLine($"Индекс eд= {indexOfED }");*/

                    //вписываем данные для положительных
                    if (indexOfED < indexOfWD && indexOfED < indexOfDD && indexOfED < indexOfDED)
                    {
                        Result = Result.Insert(indexOfED + 1, ubr);
                    }
                    if (indexOfWD < indexOfED && indexOfWD < indexOfDD && indexOfWD < indexOfDED)
                    {
                        Result = Result.Insert(indexOfWD + 1, ubr);
                    }
                    if (indexOfDD < indexOfED && indexOfDD < indexOfWD && indexOfDD < indexOfDED)
                    {
                        Result = Result.Insert(indexOfDD + 1, ubr);
                    }
                    if (indexOfDED < indexOfWD && indexOfDED < indexOfDD && indexOfDED < indexOfED)
                    {
                        Result = Result.Insert(indexOfDED + 1, ubr);
                    }

                    ubr = null;


                }
                else
                {
                    numb = Math.Abs(numb);
                    for (int j = 0; j < numb; j += 1)
                    {
                        ubr += 'S';//вниз
                    }
                    ubr += ' ';


                    int indexOfED = Result.IndexOf("ED");
                    int indexOfDED = Result.IndexOf("DED");
                    int indexOfWD = Result.IndexOf("WD");
                    int indexOfDD = Result.IndexOf("DD");

                    if (indexOfED < 0)
                    {
                        indexOfED = 100;
                    }
                    if (indexOfDED < 0)
                    {
                        indexOfDED = 100;
                    }
                    if (indexOfWD < 0)
                    {
                        indexOfWD = 100;
                    }
                    if (indexOfDD < 0)
                    {
                        indexOfDD = 100;
                    }


                    /*Console.WriteLine($"Индекс дд= {indexOfDD }");
                    Console.WriteLine($"Индекс вд= {indexOfWD }");
                    Console.WriteLine($"Индекс eд= {indexOfED }");*/


                    //вписываем данные для отрицателььных
                    if (indexOfED < indexOfWD && indexOfED < indexOfDD && indexOfED < indexOfDED)
                    {
                        Result = Result.Insert(indexOfED + 1, ubr);
                    }
                    if (indexOfWD < indexOfED && indexOfWD < indexOfDD && indexOfWD < indexOfDED)
                    {
                        Result = Result.Insert(indexOfWD + 1, ubr);
                    }
                    if (indexOfDD < indexOfED && indexOfDD < indexOfWD && indexOfDD < indexOfDED)
                    {
                        Result = Result.Insert(indexOfDD + 1, ubr);
                    }
                    if (indexOfDED < indexOfWD && indexOfDED < indexOfDD && indexOfDED < indexOfED)
                    {
                        Result = Result.Insert(indexOfDED + 1, ubr);
                    }

                    ubr = null;
                }
            }

            Result = Result.Replace(" ", "");
            Console.WriteLine(Result);

        }



    }
}
