using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    public int colorIndex;

    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.UpdateScrewdriver(colorIndex);

        Debug.Log("screwdriver get");
        sound.Play();
        Destroy(gameObject, sound.clip.length);
    }
}
