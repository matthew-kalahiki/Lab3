using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePanel : MonoBehaviour
{
    private string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            int counter = 0;
            int numLeft = 0;

            foreach (bool i in GameManager.Instance.GetScrewdrivers()) {
                if (i) { counter++; }
            }

            numLeft = 4 - counter;

            if (counter == 0)
            {
                text = "You Need to Collect All 4 of The Screwdrivers to Escape!";
            }
            else if (counter < 4)
            {
                text = "You Need " + numLeft + " More Screwdrivers to Escape!";
            }
            else
            {
                GameManager.Instance.Win();
            }

            GameManager.Instance.StartDialogue(text);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HideDialogue();
        }
    }
}
