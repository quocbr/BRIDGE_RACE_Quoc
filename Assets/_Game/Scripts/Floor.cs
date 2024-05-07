using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Floor : MonoBehaviour
{
    [SerializeField] private Transform startPosBrick;
    [SerializeField] private int row;
    [SerializeField] private int colonm;
    [SerializeField] private GameObject brickFloors;
    [SerializeField] private Brick brick;
    private List<Brick> listBrick;
    private Dictionary<ColorType,List<Brick>> DicBrick;

    private int maxBrick;

    private void Awake()
    {
        OnInit();
    }

    private void OnInit()
    {
        listBrick = new List<Brick>();
        DicBrick = new Dictionary<ColorType, List<Brick>>();
        
        SpawnInitBrick();
        SpawnAllBrick();
    }

    public void SpawnBrick(ColorType type)
    {
        try
        {
            foreach (var brick in DicBrick[type]) 
            {
                brick.gameObject.SetActive(true);
            }
        }
        catch (Exception e) 
        {
            Debug.LogWarning(e.Message);
        }
    }

    public void DisSpawnBrick(ColorType type)
    {
        try
        {
            foreach (var brick in DicBrick[type])
            {
                //brick.gameObject.SetActive(false);
                Destroy(brick.gameObject);
            }
        }
        catch (Exception e)
        {
            Debug.LogWarning(e.Message);
        }
    }

    private void SpawnAllBrick()
    {
        Shuffle(listBrick);
        //int x = System.Enum.GetValues(typeof(ColorType)).Length - 1;
        int x = LevelManager.Ins.botCount + 1;
        maxBrick = listBrick.Count/x;

        for (int i = 0; i < x; i++)
        {
            List<Brick> list = new List<Brick>();
            for (int j = i; j < listBrick.Count; j += x)
            {
                listBrick[j].SetColorType((ColorType)i);
                list.Add(listBrick[j]);
                
            }
            DicBrick.Add((ColorType)i,list);
        }
    }

    public static void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    private void SpawnInitBrick()
    {
        Vector3 st = startPosBrick.position;
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < colonm; j++)
            {
                Vector3 vt = new Vector3(st.x - 1.5f*i, 0, st.z-1.5f*j);
                Brick newBrick = Instantiate(brick, brickFloors.transform,false);
                newBrick.transform.position = vt;
                listBrick.Add(newBrick);
                newBrick.gameObject.SetActive(false);
            }
        }
    }

    public List<Brick> GetTypeBrick(ColorType type)
    {
        List<Brick> list = new List<Brick>();
        for (int i = 0; i < DicBrick[type].Count; i++)
        {
            if (DicBrick[type][i].gameObject.activeSelf)
            {
                list.Add(DicBrick[type][i]);
            }
        }
        return list;
    }
}
