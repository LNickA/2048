﻿
using System;
using System.Dynamic;

namespace Game2048
{
    public class Model
    {
        Map map;
        static Random random= new Random(); 

        bool moved;

        public Model (int size )
        {
            map = new Map(size);
        }

        public int size 
        { 
            get { return map.size; } 
        }
        public bool isGameOver;

        

        public void Escape()
        {
        }

        public int GetMap(int x, int y)
        {
            return map.Get(x, y);
        }


        void Lift(int x, int y, int sx, int sy)
        {
            if (map.Get(x, y) > 0)
            {
                while (map.Get(x + sx, y + sy) == 0)
                {
                    map.Set(x + sx, y + sy, map.Get(x, y));
                    map.Set(x, y, 0);
                    x += sx;
                    y += sy;
                    moved = true;
                }
            }
        }

        void Join(int x, int y, int sx, int sy)
        {
            if (map.Get(x, y) > 0){
                if (map.Get(x + sx, y + sy) == map.Get(x, y))
                {
                    map.Set (x + sx, y+ sy, map.Get(x, y) *2);
                    while (map.Get(x-sx, y-sy) > 0)
                    {
                        map.Set(x, y, map.Get(x - sx, y - sy));
                        x-= sx; y -= sy;
                    }
                    map.Set(x, y, 0);

                }
            }
        }
        public void Left()
        {
            moved = false; 
            for (int y = 0; y < map.size; y++)
                for (int x = 1; x < map.size; x++)
                    Lift(x, y, -1, 0);
            for (int y = 0; y < map.size; y++)
                for (int x = 1; x < map.size; x++)
                    Join(x, y, -1, 0);
            if (moved) AddRandomNumber();
            else IsGameOver();
        }

        public void Right()
        {
            moved = false;
            for (int y = 0; y < map.size; y++)
                for (int x = map.size - 2; x >= 0; x--)
                    Lift(x, y, +1, 0);
            for (int y = 0; y < map.size; y++)
                for (int x = map.size - 2; x >= 0; x--)
                    Join(x, y, +1, 0);
            if (moved) AddRandomNumber();
            else IsGameOver();
        }

        public void Up()
        {
            moved = false;
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    Lift (x, y, 0, -1);
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    Join(x, y, 0, -1);
            if (moved) AddRandomNumber();
            else IsGameOver();
        }

        public void Down()
        {
            moved = false;
            for (int x = 0; x < map.size; x++)
                for (int y = map.size -2; y >= 0; y--)
                    Lift(x, y, 0, +1);
            for (int x = 0; x < map.size; x++)
                for (int y = map.size - 2; y >= 0; y--)
                    Join(x, y, 0, +1);
            if (moved) AddRandomNumber();
            else IsGameOver();
        }

        public void Start()
        {
            isGameOver= false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map.Set(x, y, 0);
            AddRandomNumber();
            AddRandomNumber();
        }

        public bool IsGameOver()
        {
            //if (isGameOver) бесполезная проверка.
            //    return isGameOver;
            for (int  x = 0;  x < size;  x++)
                for (int y = 0; y < size; y++)
                    if (map.Get(x, y) == 0)
                        return false;
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    if (map.Get(x, y) == map.Get(x + 1, y) ||
                        map.Get(x, y) == map.Get(x, y + 1))
                        return false;
            isGameOver = true;
            return isGameOver;
        }

        private void AddRandomNumber()
        {
            if (isGameOver) return;
            for (int i = 0; i < 100; i++)
            {

            }
            int x = random.Next(0, map.size);
            int y = random.Next(0, map.size);
            if (map.Get(x, y) == 0)
            {
                map.Set(x, y, random.Next(1, 3) * 2);
                return;
            }

        }

    }
}
