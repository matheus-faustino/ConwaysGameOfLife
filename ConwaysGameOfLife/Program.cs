using System.Linq;
using SDL2;

namespace ConwaysGameOfLife
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int WINDOW_WIDTH = 1000;
            const int WINDOW_HEIGHT = 1000;
            const int CELL_SIZE = 5;

            // Cria a janela de exibição
            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);

            IntPtr window = SDL.SDL_CreateWindow("Conway's Game of Life - Matheus Faustino",
                SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED,
                WINDOW_WIDTH, WINDOW_HEIGHT, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

            IntPtr renderer = SDL.SDL_CreateRenderer(window, -1, SDL.SDL_RendererFlags.SDL_RENDERER_SOFTWARE);

            // Gera uma matriz com booleanos aleatórios
            int rowsCount = WINDOW_HEIGHT / CELL_SIZE, columnsCount = WINDOW_WIDTH / CELL_SIZE;

            bool[,] generation = new bool[rowsCount, columnsCount];

            Random random = new Random();

            for (int row = 0; row < rowsCount; row++)
            {
                for (int column = 0; column < columnsCount; column++)
                {
                    generation[row, column] = random.Next(2) == 1;
                }
            }

            // Loop de execução
            SDL.SDL_Event e;

            bool isRunning = true;

            while (isRunning)
            {
                while (SDL.SDL_PollEvent(out e) != 0)
                {
                    if (e.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        isRunning = false;
                    }
                }

                SDL.SDL_SetRenderDrawColor(renderer, 0, 0, 0, 255);
                SDL.SDL_RenderClear(renderer);

                // Calcula a geração
                bool[,] currentGeneration = new bool[rowsCount, columnsCount];

                for (int row = 0; row < rowsCount; row++)
                {
                    for (int column = 0; column < columnsCount; column++)
                    {
                        int neighborsCount = CountNeighbors(generation, row, column);

                        if (generation[row, column])
                        {
                            currentGeneration[row, column] = neighborsCount == 2 || neighborsCount == 3;
                        }
                        else
                        {
                            currentGeneration[row, column] = neighborsCount == 3;
                        }
                    }
                }

                // Exibe a geração
                for (int row = 0; row < rowsCount; row++)
                {
                    for (int column = 0; column < columnsCount; column++)
                    {
                        if (generation[row, column])
                        {
                            SDL.SDL_SetRenderDrawColor(renderer, 0, 255, 0, 255);

                            SDL.SDL_Rect cell = new SDL.SDL_Rect
                            {
                                x = column * CELL_SIZE,
                                y = row * CELL_SIZE,
                                w = CELL_SIZE,
                                h = CELL_SIZE
                            };

                            SDL.SDL_RenderFillRect(renderer, ref cell);
                        }
                    }
                }

                // Clona a geração atual para ser utilizada na próxima geração
                generation = (bool[,])currentGeneration.Clone();

                SDL.SDL_RenderPresent(renderer);
                SDL.SDL_Delay(100);
            }

            SDL.SDL_DestroyRenderer(renderer);
            SDL.SDL_DestroyWindow(window);
            SDL.SDL_Quit();
        }

        public static int CountNeighbors(bool[,] matrix, int row, int column)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            int neighbors = 0;

            int[] directionsRow = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] directionsColumn = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < 8; i++)
            {
                int newRow = row + directionsRow[i];
                int newColumn = column + directionsColumn[i];

                if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns)
                {
                    if (matrix[newRow, newColumn])
                    {
                        neighbors++;
                    }
                }
            }

            return neighbors;
        }
    }
}