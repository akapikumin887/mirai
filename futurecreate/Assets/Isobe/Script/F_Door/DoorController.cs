using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private GameMng GameManagerScript;
    private GameObject Player;
    private List<GameObject> enemy_list = new List<GameObject>();
    private bool door;//trueÇ≈ÉIÅ[ÉvÉì

    public AnimationClip opendoor;
    public AnimationClip closedoor;

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
        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 3.0f&&!door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Stop();
            animation.clip = opendoor;
            animation.Play("opendoor");
            door = true;
        }
        else if(Vector3.Distance(this.transform.position, Player.transform.position) > 3.0f && door)
        {
            Animation animation = this.GetComponent<Animation>();
            animation.Stop();
            animation.clip = closedoor;
            animation.Play("closedoor");
            door = false;
        }
    }
}
