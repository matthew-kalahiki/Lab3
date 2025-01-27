using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownWorldCamera : MonoBehaviour
{
    GameObject camera;

    public float speed;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.Instance.GetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        Vector3 spriteLoc = Camera.main.WorldToScreenPoint(player.transform.position);
        Vector3 pos = transform.position;
        if (pos.y > -83)
        {
            pos.y -= speed;
            transform.position = pos;
        }
        if (spriteLoc.y > Camera.main.pixelHeight + 200)
        {
            GameManager.Instance.UpdateIsPaused();
            GameManager.Instance.NextScene("CentralWorld", new Vector3(0, 0, 0));
            GetComponent<DownWorldCamera>().enabled = false;
        }
    }
}
