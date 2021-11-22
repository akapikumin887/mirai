using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDummy : MonoBehaviour
{
    private float _PlayerSpeed = 1.0f;

    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

    private bool Move()
    {
        //“ü—Í•ûŒü‚Ìæ“¾
        bool vertical = false;
        bool horizontal = false;

        Vector3 velocity = Vector3.zero;

        //¶‰E”»’è
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            int abs = Input.GetKey(KeyCode.A) ? -1 : 1;
            velocity.x += 0.5f * abs;
            velocity.z -= 0.5f * abs;
            vertical = true;
        }

        //ã‰º”»’è
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            int abs = Input.GetKey(KeyCode.S) ? -1 : 1;
            velocity.x += 0.5f * abs;
            velocity.z += 0.5f * abs;
            horizontal = true;
        }

        //Î‚ß“ü—Í‚Ì‰Á‘¬‚ğ–³‚­‚·
        if (vertical && horizontal)
            velocity /= 1.41421356f;
        else if (!(vertical || horizontal))
            return false;

        transform.position += velocity * _PlayerSpeed * Time.deltaTime;
        return true;
    }
}
