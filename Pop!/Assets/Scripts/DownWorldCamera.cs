using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWorldCamera : MonoBehaviour
{
    public float speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 spriteLoc = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 pos = transform.position;
        if (pos.y > -83)
        {
            pos.y -= speed;
            transform.position = pos;
        }
        if (spriteLoc.y > Camera.main.pixelHeight + 200 || spriteLoc.y < -200)
        {
            //DO GAME OVER OR RESTART LEVEL HERE
            Debug.Log("THisWorks");
        }
        
    }
}
