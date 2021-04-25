using GameOfLife.Model.Enums;
using System;

namespace GameOfLife.Model
{
    public class Universe
    {
        private readonly int size;

        private Universe(int size)
        {
            this.size = size;
            CurrentState = new State[size, size];
        }

        public State[,] CurrentState { get; private set; }

        public static Universe Create(in int size)
        {
            var universe = new Universe(size);
            universe.SeedUniverse();
            return universe;
        }

        public State[,] NextMoment()
        {
            var nextState = new State[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    nextState[i, j] = CountNextState(i, j);
                }
            }

            CurrentState = nextState;
            return CurrentState;
        }

        private State CountNextState(int x, int y)
        {
            int liveNeighboursCount = CountLiveNeighbours(x, y);

            if (CurrentState[x, y] == State.Live)
            {
                if (liveNeighboursCount == 2 || liveNeighboursCount == 3)
                {
                    return State.Live;
                }
            }
            else
            {
                if (liveNeighboursCount == 3)
                {
                    return State.Live;
                }
            }

            return State.Dead;
        }

        private int CountLiveNeighbours(int x, int y)
        {
            int liveNeighboursCount = 0;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int xNeighbourCoordinate = (x + i + size) % size;
                    int yNeighbourCoordinate = (y + j + size) % size;

                    if (CurrentState[xNeighbourCoordinate, yNeighbourCoordinate] == State.Live
                        && !(xNeighbourCoordinate == x && yNeighbourCoordinate == y))
                    {
                        liveNeighboursCount++;
                    }
                }
            }

            return liveNeighboursCount;
        }

        private void SeedUniverse()
        {
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    CurrentState[i, j] = (State)random.Next(2);
                }
            }
        }
    }
}
