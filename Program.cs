using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Map;
            int MapWidht;
            int MapHeight;
            int x, y, step = 0;
            

            int[,] WayMap;
        /// <summary>
        /// Конструктор
        /// </summary>
        
            MapWidht = 16;
            MapHeight = 9;
            Map = new int[,]{
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                {1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1},
                {1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1},
                {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};
            WayMap = new int[10, 10];
        
        /// <summary>
        /// Отображение карты
        /// </summary>
      
            for ( y = 0; y < MapHeight; y++)
            {
                Console.WriteLine();
                for ( x = 0; x < MapWidht; x++)
                    if (Map[y, x] == 1)
                        Console.Write("2");
                    else
                        Console.Write("0");
            }
            Console.ReadKey();
            Console.WriteLine("введите старт по ширине");
            int startX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите старт по длине");
            int startY = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите финишь по ширине");
            int finX = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("введите финишь по длине");
            int finY = Convert.ToInt32(Console.ReadLine());

            bool add = true;
            int[,] cMap = new int[MapHeight, MapWidht];
            
            for (y = 0; y < MapHeight; y++)
                for (x = 0; x < MapWidht; x++)
                {
                    if (Map[y, x] == 1)
                        cMap[y, x] = -2;// стены
                    else
                        cMap[y, x] = -1;// не ступал сюда
                }
            cMap[startY, startX] = 0;//старт 0
            while (add == true)
            {
                add = false;
                for (y = 0; y < MapWidht; y++)
                    for (x = 0; x < MapHeight; x++)
                    {
                        if (cMap[x, y] == step)
                        {
                            
                            if (y - 1 >= 0 && cMap[x - 1, y] != -2 && cMap[x - 1, y] == -1)//лево
                                cMap[x - 1, y] = step + 1;
                            if (x - 1 >= 0 && cMap[x, y - 1] != -2 && cMap[x, y - 1] == -1)// вниз
                                cMap[x, y - 1] = step + 1;
                            if (y + 1 < MapWidht && cMap[x + 1, y] != -2 && cMap[x + 1, y] == -1)//право
                                cMap[x + 1, y] = step + 1;
                            if (x + 1 < MapHeight && cMap[x, y + 1] != -2 && cMap[x, y + 1] == -1)//вверх
                                cMap[x, y + 1] = step + 1;
                        }
                    }
                step++;
                add = true;
                if (cMap[finY, finX] != -1)//решение найдено
                    add = false;
                if (step > MapWidht * MapHeight)//решение не найдено
                    add = false;
            }
           
            for (y = 0; y < MapHeight; y++)
            {
                Console.WriteLine();
                for (x = 0; x < MapWidht; x++)
                    if (cMap[y, x] == -1)
                        Console.Write(" ");
                    else
                    if (cMap[y, x] == -2)
                        Console.Write("#");
                    else
                    if (y == startY && x == startX)
                        Console.Write("S");
                    else
                    if (y == finY && x == finX)
                        Console.Write("F");
                    else
                    if (cMap[y, x] > -1)
                        Console.Write("{0}", cMap[y, x]);

            }
            Console.ReadKey();


        }
    }
    }


