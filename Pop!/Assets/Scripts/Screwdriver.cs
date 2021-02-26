using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Screwdriver : MonoBehaviour
{
    public int colorIndex;

    AudioSource sound;
    private GameObject player2;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        player = GameManager.Instance.GetPlayer();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D()
    {
        if (SceneManager.GetActiveScene().name == "UpWorld")
        {
            player2 = GameObject.Find("Character2");

            if (-5 < player2.transform.position.x && player2.transform.position.x < -3 && player2.transform.position.y > 23)
            {
                if (4 < player.transform.position.x && player.transform.position.x < 6 && player.transform.position.y > 23)
                {
                    GameManager.Instance.UpdateScrewdriver(colorIndex);
                    sound.Play();
                    Destroy(gameObject, sound.clip.length);
                    Debug.Log("1");
                    Destroy(GameObject.Find("ScrewdriverYellow-Sheet_0 (1)"));
                }
            }
        }
        else
        {
            GameManager.Instance.UpdateScrewdriver(colorIndex);
            sound.Play();
            Destroy(gameObject, sound.clip.length);
            Debug.Log("2");
        }
    }
}
