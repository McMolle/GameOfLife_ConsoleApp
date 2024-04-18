using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife_ConsoleApp
{
    internal class Grid
    {
        public int GridWidth;
        public int GridHeight;

        public Dictionary<Vector2, bool> Cells = new Dictionary<Vector2, bool>();


        public Dictionary<Vector2, int> NeighborCount = new Dictionary<Vector2, int>();


        public List<Vector2> StartsAlive = new List<Vector2>();

        private List<Vector2> _neighborhood = new List<Vector2> {
            new Vector2(-1, -1), new Vector2(0, -1), new Vector2(1, -1),
            new Vector2(-1, 0),                      new Vector2(1, 0),
            new Vector2(-1, 1),  new Vector2(0, 1),  new Vector2(1, 1)
        };

        public Dictionary<Vector2, bool> NextGeneration = new Dictionary<Vector2, bool>();



        public Grid(int width, int height)
        {
            GridWidth = width;
            GridHeight = height;


            for (int x = 0; x < GridWidth; x++)
            {
                for (int y = 0; y < GridHeight; y++)
                {
                    Vector2 c = new Vector2(x, y);
                    Cells.Add(c, false);
                }
            }
        }

        public Grid(int width, int height, List<Vector2> startsAlive)
        {
            GridWidth = width;
            GridHeight = height;
            StartsAlive = startsAlive;

            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Vector2 c = new Vector2(x, y);
                    bool state = StartsAlive.Contains(c);
                    Cells.Add(c, state);
                }
            }
        }


        public override string ToString()
        {
            string g = "";
            for (int y = 0; y < GridHeight; y++)
            {
                for (int x = 0; x < GridWidth; x++)
                {
                    Vector2 c = new Vector2(x, y);
                    if (Cells[c] == true)
                    {
                        g += $" [X] ";
                    }
                    else
                    {
                        g += $" [ ] ";
                    }
                }
                g += "\n\n";
            }
            return g;
        }

    }
}
