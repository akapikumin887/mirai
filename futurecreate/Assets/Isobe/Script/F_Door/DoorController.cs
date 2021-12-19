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
        Player=GameManagerScript.GetPlayer();
        enemy_list = GameManagerScript.GetComponent<GameMng>().GetEnemy();
        door = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isLock && !GameManagerScript.GetKey(lockNum))
            return;

        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 5.0f&&!door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Play("opendoor");
            door = true;
        }
        else if(Vector3.Distance(this.transform.position, Player.transform.position) > 5.0f && door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Play("closedoor");
            door = false;
        }
    }
}
