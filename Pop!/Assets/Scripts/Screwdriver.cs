using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screwdriver : MonoBehaviour
{
    public int colorIndex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D()
    {
        gameObject.SetActive(false);
        GameManager.Instance.UpdateScrewdriver(colorIndex);
    }
}
