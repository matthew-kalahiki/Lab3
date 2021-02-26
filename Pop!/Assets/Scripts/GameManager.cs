using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public GameObject startButton;
    public GameObject backgroundImage;

    public GameObject dialogueBox;
    public GameObject textBox;

    public GameObject canvas;
    public GameObject events;
    public GameObject player;

    public GameObject[] colors;

    private bool[] screwdrivers = new bool[] {false,false,false,false};

    private Vector3 nextPlayerLoc;

    private bool isPaused = true;

    private bool isPreview = false;

    private Coroutine dialogueCo;

    private bool beatTutorial;

    private bool popped = false;


    // Start is called before the first frame update
    void Start()
    {
        nextPlayerLoc = new Vector3(0,0,0);
        player.SetActive(false);
        beatTutorial = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(player);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartButon()
    {
        startButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("CentralWorld", nextPlayerLoc));
        player.SetActive(true);

    }
    IEnumerator ColorLerp(Color endValue, float duration)
    {
        float time = 0;
        Image sprite = backgroundImage.GetComponent<Image>();
        Color startValue = sprite.color;

        while (time < duration)
        {
            sprite.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        sprite.color = endValue;
    }
    IEnumerator LoadYourAsyncScene(string scene, Vector3 whereTo)
    {
        nextPlayerLoc = whereTo;
        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            StartCoroutine(ColorLerp(new Color(0, 0, 0, 1), 1));
            while (!backgroundImage.GetComponent<Image>().color.Equals(new Color(0,0,0,1))) {
                yield return null;
            }
            UpdatePopped();
        }
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

        player.transform.position = nextPlayerLoc;
        StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 1));
        UpdateIsPaused();
        

        for (int i = 0; i < 4; i++)
        {
            if (screwdrivers[i]) {
                i = i;
            }
        }

    }
    public void NextScene(string whichScene, Vector3 whereTo)
    {

        beatTutorial = true;
        StartCoroutine(LoadYourAsyncScene(whichScene, whereTo));
      


    }
    public GameObject GetPlayer()
    {
        return player;
    }

    public void StartDialogue(string text)
    {
        dialogueBox.SetActive(true);
        dialogueCo = StartCoroutine(typeText(text));


    }

    public void HideDialogue()
    {
        dialogueBox.SetActive(false);
        StopCoroutine(dialogueCo);
        
    }

    IEnumerator typeText(string text)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = "";
        foreach(char c in text.ToCharArray())
        {
            textBox.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(.03f);
        }
            
    }

    public void UpdateScrewdriver(int colorIndex)
    {
        player.GetComponentsInChildren<ParticleSystem>()[colorIndex+1].Play();
        screwdrivers[colorIndex] = true;
        colors[colorIndex].SetActive(true);
    }
    public bool GetIsPaused()
    {
        return isPaused;
    }
    public void UpdateIsPaused()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 0;

        }
        else
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
        }

    }
    public bool GetIsPreview()
    {
        return isPreview;
    }
    public void UpdateIsPreview()
    {
        isPreview = !isPreview;

    }
    public bool beatT()
    {
        return beatTutorial;
    }
    public bool[] GetScrewdrivers()
    {
        return screwdrivers;
    }
    public bool GetPopped()
    {
        return popped;
    }
    public void UpdatePopped()
    {
        popped = false;
    }
}
