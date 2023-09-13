using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Canvas mainMenuCanvas;
    Canvas optionsCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenOptions()
    {
        mainMenuCanvas.enabled = false;
        optionsCanvas.enabled = true;
    }
    public void ReturnToMainMenu()
    {
        optionsCanvas.enabled = false;
        mainMenuCanvas.enabled = true;
    }
    
    
}
