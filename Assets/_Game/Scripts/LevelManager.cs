using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject botPrefab;
    [SerializeField] private Transform parentMap;
    [SerializeField] private NavMeshSurface navMeshSurface;


    private List<GameObject> cBrick;
    private GameObject currentMap;
    private NavMeshData currentMapData;
    private GameObject currentStartPoint;
    

    private GameObject player;
    private List<GameObject> bot;

    public GameObject currentFinishPoint;
    public int botCount;

    private void Start()
    {
        cBrick = new List<GameObject>();
        GameObject[] loadedBricks = Resources.LoadAll<GameObject>($"{PathContant.BRICK_PATCH}");
        cBrick.AddRange(loadedBricks);
    }

    public void spawnMapToIndex(string index)
    {
        int Index = int.Parse(index);
        GameObject mapPrefab = Resources.Load<GameObject>($"{PathContant.MAP_PATH}_{Index}");
        GameObject spPrefab = Resources.Load<GameObject>($"{PathContant.STARTPOINT_PATH}_{Index}");
        GameObject fpPrefab = Resources.Load<GameObject>($"{PathContant.FINISHPOINT_PATH}_{Index}");

        NavMeshData newNavMeshData= Resources.Load<NavMeshData>($"{PathContant.MAPDATA_PATCH}_{Index}");
        
        currentMap = Instantiate(mapPrefab, parentMap);
        navMeshSurface.BuildNavMesh();
        navMeshSurface.navMeshData = newNavMeshData;
        
        currentStartPoint = Instantiate(spPrefab, parentMap);
        currentFinishPoint = Instantiate(fpPrefab, parentMap);
    }

    public void SpawnBot(int countBot)
    {
        Vector3 botPos = currentStartPoint.transform.position;
        player = Instantiate(playerPrefab,botPos,Quaternion.identity);
        player.GetComponent<Character>().ChangeColorType((ColorType)0, cBrick[0]);

        CameraFollow.Ins.SetFollow(player.transform);

        int z = 1, x = 1,temp = 1;
        bot = new List<GameObject>();
        for (int i = 0; i < countBot; i++)
        {
            if(i%2 == 0)
            {
                GameObject newBot = Instantiate(botPrefab, botPos + new Vector3(3*z,0,0), Quaternion.identity);
                newBot.GetComponent<Character>().ChangeColorType((ColorType)temp, cBrick[temp]);
                z++;
                bot.Add(newBot);
            }
            else
            {
                GameObject newBot = Instantiate(botPrefab, botPos + new Vector3(-3 * x, 0, 0), Quaternion.identity);
                newBot.GetComponent<Character>().ChangeColorType((ColorType)temp, cBrick[temp]);
                x++;
                bot.Add(newBot);
            }
            temp++;
        }
    }

    public void DeleteCurentMap()
    {
        Destroy(currentMap);
        Destroy(currentFinishPoint);
        Destroy(currentStartPoint);

        Destroy(player);
        for (int i = 0; i < botCount; i++)
        {
            Destroy(bot[i]);
        }
        bot.Clear();
    }

}
