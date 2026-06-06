using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _maze;
    private (int x, int y) _currentLocation;

    public Maze(Dictionary<(int, int), bool[]> maze, (int, int) start)
    {
        _maze = maze;
        _currentLocation = start;
    }

    public (int, int) CurrentLocation
    {
        get { return _currentLocation; }
    }

    public void MoveLeft()
    {
        if (_maze[_currentLocation][0])
        {
            _currentLocation =
                (_currentLocation.x - 1, _currentLocation.y);
        }
    }

    public void MoveRight()
    {
        if (_maze[_currentLocation][1])
        {
            _currentLocation =
                (_currentLocation.x + 1, _currentLocation.y);
        }
    }

    public void MoveUp()
    {
        if (_maze[_currentLocation][2])
        {
            _currentLocation =
                (_currentLocation.x, _currentLocation.y - 1);
        }
    }

    public void MoveDown()
    {
        if (_maze[_currentLocation][3])
        {
            _currentLocation =
                (_currentLocation.x, _currentLocation.y + 1);
        }
    }
}