using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectsPool : MonoBehaviour
{
    public static ObjectsPool instance = null;
    [SerializeField] GameObject _coin;
    [SerializeField] GameObject _toxic;
    [SerializeField] GameObject _box;
    [SerializeField] GameObject[] _walls;
    [SerializeField] GameObject[] _walls12;
    [SerializeField] float[] _wallsChances;
    [SerializeField] float[] _wallsChances12;
    [SerializeField] GameObject[] _enemies;
    [SerializeField] float[] _enemiesChances;
    

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public GameObject GetCoinPrefab()
    {
        return _coin;
    }

    public GameObject GetToxicPrefab()
    {
        return _toxic;
    }

    public GameObject[] GetWallsPrefabs()
    {
        return _walls;
    }
    public GameObject[] GetWallsPrefabs12()
    {
        return _walls12;
    }

    public GameObject[] GetEnemiesPrefabs()
    {
        return _enemies;
    }

    public float[] GetWallsChances()
    {
        return _wallsChances;
    }
    public float[] GetWallsChances12()
    {
        return _wallsChances12;
    }

    public float[] GetEnemiesChances()
    {
        return _enemiesChances;
    }
    public GameObject GetBoxPrefab()
    {
        return _box;
    }
}
