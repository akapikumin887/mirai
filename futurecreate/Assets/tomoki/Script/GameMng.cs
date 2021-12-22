using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    [SerializeField] private int _KeyCount;
    [SerializeField] private int _ItemCount;
    [SerializeField] private GameObject _VisEnemy;
    [SerializeField] private GameObject _LisEnemy;

    public GameObject _Pleyer { set; get; }
    public List<GameObject> _Enemys { set; get; } = new List<GameObject>();
    public List<GameObject> _PathFindings { set; get; } = new List<GameObject>();
    public bool GameOver { set; get; }//true�ŃQ�[���I�[�o�[
    public List<bool> _Keys { set; get; } = new List<bool>();
    public uint _ClockCount { set; get; }

    void Awake()
    {
        //�v���C���[�̎擾
        _Pleyer = GameObject.FindGameObjectWithTag("Player");

        //�G�l�~�[�̎擾
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys != null)
        {
            foreach (var obj in enemys)
                _Enemys.Add(obj);
        }


        //�o�H�T���̃|�C���g�擾
        GameObject point = GameObject.FindGameObjectWithTag("Point");
        if (point != null)
        {
            GameObject[] points = point.GetComponentsInChildren<GameObject>();

            foreach (var obj in points)
                _PathFindings.Add(obj);
        }

        //���̏�����
        for (uint i = 0; i < _KeyCount; i++)
            _Keys.Add(false);

        //�A�C�e���̏�����
        _ClockCount = 0;
    }

    void Start()
    {
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    var controllerNames = Input.GetJoystickNames();
        //    if (controllerNames[0] == "")
        //        Debug.Log("�R���g���[���[���ڑ�");
        //    else
        //    {
        //        for (int i = 0; i < 5; i++)
        //        {
        //            if (controllerNames[i] == null)
        //                break;
        //            Debug.Log(controllerNames[i]);
        //        }
        //    }
        //}

        if (GameOver)
        {
            scene_manager.FadeOut(1);
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Notification nof = GameObject.Find("Image3").GetComponent<Notification>();
        //    nof.CallNotification("�₠");
        //}
    }

    public GameObject AddEnemyVisibility(Vector3 pos)
    {
        var enemy = Instantiate(_VisEnemy, pos, Quaternion.identity);
        _Enemys.Add(enemy);

        return enemy;
    }

    public GameObject AddEnemyListen(Vector3 pos)
    {
        var enemy = Instantiate(_LisEnemy, pos, Quaternion.identity);
        _Enemys.Add(enemy);

        return enemy;
    }

}
