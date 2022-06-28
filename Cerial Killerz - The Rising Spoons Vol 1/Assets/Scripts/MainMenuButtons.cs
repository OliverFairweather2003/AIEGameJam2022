using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Scene1()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene2()
    {
        SceneManager.LoadScene("Credits");

    }
    public void Scene3()
    {
        Application.Quit();

    }


}
