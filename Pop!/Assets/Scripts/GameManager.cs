using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public GameObject startButton;
    public GameObject backgroundImage;

    public GameObject canvas;
    public GameObject events;


    // Start is called before the first frame update
    void Start()
    {
        
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

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartButon()
    {
        startButton.SetActive(false);
        StartCoroutine(LoadYourAsyncScene("CentralWorld"));

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
    IEnumerator LoadYourAsyncScene(string scene)
    {
        if (!SceneManager.GetActiveScene().name.Equals("Start"))
        {
            StartCoroutine(ColorLerp(new Color(0, 0, 0, 1), 1));
            while (!backgroundImage.GetComponent<Image>().color.Equals(new Color(0,0,0,1))) {
                yield return null;
            }
        }
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            StartCoroutine(ColorLerp(new Color(0, 0, 0, 0), 1));
       
    }
    public void NextScene(string whichScene)
    {
        StartCoroutine(LoadYourAsyncScene(whichScene));

    }
}
