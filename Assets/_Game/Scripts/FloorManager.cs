using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;
using Random = UnityEngine.Random;

public class FloorManager : Singleton<FloorManager>
{
    [SerializeField] private List<Floor> listFloor;
    [SerializeField] private ColorSO colorSO;

    private void Start()
    {
        SpawnAll();
        //LevelManager.Ins.NAVBake();
    }

    public Material GetMaterial(ColorType type)
    {
        return colorSO.colorList[(int)type];
    }

    public ColorType GetRandomColorType() 
    {
        return (ColorType)Random.Range(0, System.Enum.GetValues(typeof(ColorType)).Length-1);
    }
    
    public void SpawnAll()
    {
        int x = LevelManager.Ins.botCount + 1;
        for (int i = 0; i < x; i++)
        {
            listFloor[0].SpawnBrick((ColorType)i);
        }
    }
    public void SpawnBrickInFloor(int index, ColorType type)
    { 
        listFloor[index+1].SpawnBrick(type);
        listFloor[index].DisSpawnBrick(type);   
    }
    
    public List<Brick> GetBricks(int index, ColorType type)
    {
        return listFloor[index].GetTypeBrick(type);
    }
}
