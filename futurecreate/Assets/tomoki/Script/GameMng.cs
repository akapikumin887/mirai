using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    private GameObject _Pleyer;
    private List<GameObject> _Enemys = new List<GameObject>();
    private List<GameObject> _Traps = new List<GameObject>();
    private List<GameObject> _PathFindings = new List<GameObject>();
    private Camera _Camera;

    void Awake()
    {
        //プレイヤーの取得
        _Pleyer = GameObject.FindGameObjectWithTag("Player");

        //エネミーの取得
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys != null)
        {
            foreach (var obj in enemys)
                _Enemys.Add(obj);
        }

        //トラップの取得
        //GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");
        //if (traps != null)
        //{
        //    foreach (var obj in traps)
        //        _Traps.Add(obj);
        //}


        //経路探索のポイント取得
        GameObject point = GameObject.FindGameObjectWithTag("Point");
        if (point != null)
        {
            GameObject[] points = point.GetComponentsInChildren<GameObject>();

            foreach (var obj in points)
                _PathFindings.Add(obj);
        }

        //_Camera = Camera.GetAllCameras();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public GameObject GetPlayer() { return _Pleyer; }

    public bool AddEnemy(GameObject enemy)
    {
        //比較じゃなくてタグ付けしてあげる
        if (!enemy.CompareTag("Enemy"))
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

    public List<GameObject> GetTrap() { return _Traps; }

    public List<GameObject> GetPathFinding() { return _PathFindings; }
}
