using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public string whichScene;
    public Vector3 whereTo;

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
        GameManager.Instance.UpdateIsPaused();
        GameManager.Instance.NextScene(whichScene,whereTo);

    }
    
}
