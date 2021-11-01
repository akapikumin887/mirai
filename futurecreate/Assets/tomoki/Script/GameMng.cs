using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    private List<GameObject> _Enemys = new List<GameObject>();

    void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("enemy");

        if (objects == null)
            return;

        foreach (var obj in objects)
            _Enemys.Add(obj);
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool AddEnemy(GameObject enemy)
    {
        if (!enemy.CompareTag("enemy"))
            return false;

        _Enemys.Add(enemy);
        return true;
    }

    public List<GameObject> GetEnemy() { return _Enemys; }

    public List<GameObject> GetVisibilityEnemy()
    {
        List<GameObject> vEnemy = new List<GameObject>();

        foreach (var obj in _Enemys)
        {
            var scr = obj.GetComponent<EnemyVisibility>();

            vEnemy.Add(obj);
        }

        return vEnemy;
    }

    public List<GameObject> GetListenEnemy()
    {
        List<GameObject> lEnemy = new List<GameObject>();

        foreach (var obj in _Enemys)
        {
            var scr = obj.GetComponent<LisEnemy>();
            if (scr != null)
                lEnemy.Add(obj);
        }

        return lEnemy;
    }

}
