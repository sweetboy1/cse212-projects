using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Check if current position exists in maze map
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if left movement is allowed (index 0 in the bool array)
        bool[] directions = _mazeMap[currentPos];
        if (directions.Length > 0 && directions[0]) // left is at index 0
        {
            _currX--; // Move left decreases x coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Check if current position exists in maze map
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if right movement is allowed (index 1 in the bool array)
        bool[] directions = _mazeMap[currentPos];
        if (directions.Length > 1 && directions[1]) // right is at index 1
        {
            _currX++; // Move right increases x coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Check if current position exists in maze map
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if up movement is allowed (index 2 in the bool array)
        bool[] directions = _mazeMap[currentPos];
        if (directions.Length > 2 && directions[2]) // up is at index 2
        {
            _currY--; // Move up decreases y coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Check if current position exists in maze map
        var currentPos = (_currX, _currY);
        if (!_mazeMap.ContainsKey(currentPos))
        {
            throw new InvalidOperationException("Can't go that way!");
        }

        // Check if down movement is allowed (index 3 in the bool array)
        bool[] directions = _mazeMap[currentPos];
        if (directions.Length > 3 && directions[3]) // down is at index 3
        {
            _currY++; // Move down increases y coordinate
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
