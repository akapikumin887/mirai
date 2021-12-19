using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameMng GameManagerScript;
    private GameObject Player;
    private List<GameObject> enemy_list = new List<GameObject>();
    private bool door;//trueÇ≈ÉIÅ[ÉvÉì
    [SerializeField]
    private bool isLock = false;
    [SerializeField]
    private int lockNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameMng>();
        Player=GameManagerScript._Pleyer;
        enemy_list = GameManagerScript.GetComponent<GameMng>()._Enemys;
        door = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLock && !GameManagerScript._Keys[lockNum])
            return;


        if ((DistancePlayer() || DistanceEnemy()) && !door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Play("opendoor");
            door = true;
        }
        else if ((!DistancePlayer() && !DistanceEnemy()) && door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Play("closedoor");
            door = false;
        }
    }

    private bool DistancePlayer()
    {
        return Vector3.Distance(this.transform.position, Player.transform.position) <= 5.0f ? true : false;
    }

    private bool DistanceEnemy()
    {
        foreach (var enemy in enemy_list)
            if (Vector3.Distance(this.transform.position, enemy.transform.position) <= 5.0f)
                return true;

        return false;
    }
}
