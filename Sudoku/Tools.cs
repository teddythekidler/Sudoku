using System.IO;

namespace Sudoku
{
    class Tools
    {
        public static int[,] Wczytaj(string lokalizacja)
        {
            int[,] lines = new int[9, 9];
            string input = File.ReadAllText(lokalizacja);
            int i = 0, j = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(';'))
                {
                    lines[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            
            return lines;
        }
        public static bool Sprawdz(int[,] tab)
        {
            for (int i = 0; i < 9; i++)
            {
                if ((tab[i, 0] + tab[i, 2] + tab[i, 3] + tab[i, 4] + tab[i, 5] + tab[i, 6] + tab[i, 7] +
                    tab[i, 8] + tab[i, 1]) != 45) return false;
                if ((tab[0, i] + tab[1, i] + tab[2, i] + tab[3, i] + tab[4, i] + tab[5, i] + tab[6, i] +
                    tab[7, i] + tab[8, i]) != 45) return false;
            }

            return true;
        }
        
        public static int[,] Zapisz()
        {
            int[,] lines = new int[9, 9];
            string input = File.ReadAllText(@"C:\Users\user\Desktop\sudoku.txt");
            int i = 0, j = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    lines[i, j] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }
            return lines;
        }
    }
}
