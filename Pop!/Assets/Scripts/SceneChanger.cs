using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string whichScene;

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
       
        StartCoroutine(LoadYourAsyncScene());

    }
    IEnumerator LoadYourAsyncScene()
    {
        

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(whichScene);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
