using System;

class Program
{
    static int kursorX;
    static int kursorY;
    static int[,] mapa = {
            { 0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,0,0,1,2,0,0,1,0,0,0,0,0,0,0,0,0,0 },
            { 0,0,1,1,1,0,0,2,1,1,0,0,0,0,0,0,0,0,0 },
            { 0,0,1,0,0,2,0,2,0,1,0,0,0,0,0,0,0,0,0 },
            { 1,1,1,0,1,0,1,1,0,1,0,0,0,1,1,1,1,1,1 },
            { 1,0,0,0,1,0,1,1,0,1,1,1,1,1,0,0,4,4,1 },
            { 1,0,2,0,0,2,0,0,0,0,0,0,0,0,0,0,4,4,1 },
            { 1,1,1,1,1,0,1,1,1,0,1,3,1,1,0,0,4,4,1 },
            { 0,0,0,0,1,0,0,0,0,0,1,1,1,1,1,1,1,1,1 },
            { 0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0 }
        };

    static void IspisiMapu()
    {
        for (int i = 0; i < mapa.GetLength(1); i++)
        {
            for (int j = 0; j < mapa.GetLength(0); j++)
            {
                Console.CursorLeft = i;
                Console.CursorTop = j;
                if (mapa[j, i] == 1)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine((char)166);
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (mapa[j, i] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine((char)176);
                }
                else if (mapa[j, i] == 3)
                {
                    kursorX = i; kursorY = j;
                }
                else if (mapa[j, i] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine((char)126);
                }
            }
        }
    }
    static void NacrtajKursor()
    {
        Console.CursorLeft = kursorX;
        Console.CursorTop = kursorY;
        Console.WriteLine("Y");
    }
    static void NevidljiviKursor()
    {
        Console.CursorLeft = kursorX;
        Console.CursorTop = kursorY;
        if (mapa[kursorY, kursorX] == 4)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine((char)126);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else Console.WriteLine(" ");
    }
    static bool KretanjeKursora(int x, int y)
    {
        if (mapa[y, x] != 1)
        {
            return true;
        }
        else return false;
    }
    static bool PomeranjeKutijeDesno(int x, int y)
    {
        if (mapa[y, x] == 2)
        {
            if (mapa[y, x + 1] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                mapa[y, x] = 0;
                mapa[y, x + 1] = 2;
                Console.CursorLeft = x + 1;
                Console.CursorTop = y;
                Console.WriteLine((char)176);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else if (mapa[y, x + 1] == 4)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                mapa[y, x] = 0;
                mapa[y, x + 1] = 2;
                Console.CursorLeft = x + 1;
                Console.CursorTop = y;
                Console.WriteLine((char)176);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else return false;
        }
        return true;
    }
    static bool PomeranjeKutijeLevo(int x, int y)
    {
        if (mapa[y, x] == 2)
        {
            if (mapa[y, x - 1] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                mapa[y, x] = 0;
                mapa[y, x - 1] = 2;
                Console.CursorLeft = x - 1;
                Console.CursorTop = y;
                Console.WriteLine((char)176);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else return false;
        }
        return true;
    }
    static bool PomeranjeKutijeGore(int x, int y)
    {
        if (mapa[y, x] == 2)
        {
            if (mapa[y - 1, x] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                mapa[y, x] = 0;
                mapa[y - 1, x] = 2;
                Console.CursorLeft = x;
                Console.CursorTop = y - 1;
                Console.WriteLine((char)176);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else return false;
        }
        return true;
    }
    static bool PomeranjeKutijeDole(int x, int y)
    {
        if (mapa[y, x] == 2)
        {
            if (mapa[y + 1, x] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                mapa[y, x] = 0;
                mapa[y + 1, x] = 2;
                Console.CursorLeft = x;
                Console.CursorTop = y + 1;
                Console.WriteLine((char)176);
                Console.ForegroundColor = ConsoleColor.White;
                return true;
            }
            else return false;
        }
        return true;
    }
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        IspisiMapu();
        NacrtajKursor();
        while (true)
        {
            ConsoleKeyInfo kursor = Console.ReadKey(true);
            if (kursor.Key == ConsoleKey.RightArrow)
            {
                if (KretanjeKursora(kursorX + 1, kursorY))
                {
                    if (PomeranjeKutijeDesno(kursorX + 1, kursorY))
                    {
                        NevidljiviKursor();
                        kursorX++;
                        NacrtajKursor();
                    }
                }
            }
            else if (kursor.Key == ConsoleKey.LeftArrow)
            {
                if (KretanjeKursora(kursorX - 1, kursorY))
                {
                    if (PomeranjeKutijeLevo(kursorX - 1, kursorY))
                    {
                        NevidljiviKursor();
                        kursorX--;
                        NacrtajKursor();
                    }
                }
            }
            else if (kursor.Key == ConsoleKey.UpArrow)
            {
                if (KretanjeKursora(kursorX, kursorY - 1))
                {
                    if (PomeranjeKutijeGore(kursorX, kursorY - 1))
                    {
                        NevidljiviKursor();
                        kursorY--;
                        NacrtajKursor();
                    }
                }
            }
            else if (kursor.Key == ConsoleKey.DownArrow)
            {
                if (KretanjeKursora(kursorX, kursorY + 1))
                {
                    if (PomeranjeKutijeDole(kursorX, kursorY + 1))
                    {
                        NevidljiviKursor();
                        kursorY++;
                        NacrtajKursor();
                    }
                }
            }
            else if (kursor.Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}