using Management;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    [SerializeField] GameObject mainMenuCanvas;
    [SerializeField] GameObject optionsCanvas;
  
    public void StartGame()
	{
		//WorldDataManager.Instance.LoadStartingDefault();
		SceneManager.LoadScene(1);
    }

	public void LoadGame()
	{

	}

	public void LoadGameFromFile()
	{
        WorldDataManager.Instance.LoadWorldData("Test", "Test");
		SceneManager.LoadScene(1);
	}

    public void OpenOptions()
    {
        mainMenuCanvas.SetActive(false);
        optionsCanvas.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        optionsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   
}
