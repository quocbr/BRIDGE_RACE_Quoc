using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer
{
    public const int WATER = 4;
    public const int PLAYER = 7;
    public const int BOT = 8;
    public const int BRICK = 10;
    public const int BRIDGE = 11;
    public const int DOOR = 12;
    public const int FINISHBOX = 13;
    
}

public class Anim
{
    public const string IDLE = "idle";
    public const string RUN = "run";
    public const string WIN = "win";
}

public class PathContant
{
    public const string MAP_PATH = "Level/Map/Map";
    public const string STARTPOINT_PATH = "Level/StartPoint/StartPoint";
    public const string FINISHPOINT_PATH = "Level/FinishPoint/FinishPoint";
    public const string MAPDATA_PATCH = "Level/Map/MapData";
    public const string BRICK_PATCH = "Brick";
}

