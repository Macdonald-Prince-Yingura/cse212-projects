using System;
using System.Collections.Generic;

public class Maze
{
    // Represents valid movements from each (x, y) position in the maze.
    // The tuple value is (Left, Right, Up, Down) — true means the path is open.
    private Dictionary<(int x, int y), (bool Left, bool Right, bool Up, bool Down)> _maze;
    private (int x, int y) _currentLocation;

    public Maze(
        Dictionary<(int x, int y), (bool Left, bool Right, bool Up, bool Down)> maze,
        (int x, int y) startLocation)
    {
        _maze = maze;
        _currentLocation = startLocation;
    }

    // Problem 4 - Move Left
    // Moves the player left (decreases x) if the path is open.
    public void MoveLeft()
    {
        if (_maze[_currentLocation].Left)
            _currentLocation = (_currentLocation.x - 1, _currentLocation.y);
        else
            Console.WriteLine("ERROR: Cannot move left!");
    }

    // Problem 4 - Move Right
    // Moves the player right (increases x) if the path is open.
    public void MoveRight()
    {
        if (_maze[_currentLocation].Right)
            _currentLocation = (_currentLocation.x + 1, _currentLocation.y);
        else
            Console.WriteLine("ERROR: Cannot move right!");
    }

    // Problem 4 - Move Up
    // Moves the player up (decreases y) if the path is open.
    public void MoveUp()
    {
        if (_maze[_currentLocation].Up)
            _currentLocation = (_currentLocation.x, _currentLocation.y - 1);
        else
            Console.WriteLine("ERROR: Cannot move up!");
    }

    // Problem 4 - Move Down
    // Moves the player down (increases y) if the path is open.
    public void MoveDown()
    {
        if (_maze[_currentLocation].Down)
            _currentLocation = (_currentLocation.x, _currentLocation.y + 1);
        else
            Console.WriteLine("ERROR: Cannot move down!");
    }

    // Returns the player's current location (for testing/display purposes)
    public (int x, int y) GetCurrentLocation()
    {
        return _currentLocation;
    }
}