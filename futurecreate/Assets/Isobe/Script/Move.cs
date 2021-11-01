using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    
    // Start is called before the first frame update
    [SerializeField] float PlayerSpeed; // ˆÚ“®‘¬“x


    void Update()
    {
        // ¶‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(-PlayerSpeed, 0.0f, 0.0f);
        }
        // ‰E‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(PlayerSpeed, 0.0f, 0.0f);
        }
        // ‘O‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(0.0f, 0.0f, PlayerSpeed);
        }
        // Œã‚ë‚ÉˆÚ“®
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(0.0f, 0.0f, -PlayerSpeed);
        }
        
    }

}
