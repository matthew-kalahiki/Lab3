using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpworldCamera : MonoBehaviour
{

    public GameObject sprite1;
    public GameObject sprite2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sprite1 && sprite2)
        {
            Vector3 spriteLoc1 = sprite1.transform.position;
            Vector3 spriteLoc2 = sprite2.transform.position;

            
            Vector3 pos = transform.position;


            pos.y = ((spriteLoc1.y + spriteLoc2.y) / 2);
            transform.position = pos;
        }
        
    }
}
