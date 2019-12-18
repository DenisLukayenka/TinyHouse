using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void OnExitButtonPress()
    {
        Debug.Log("Quit game");
        
        Application.Quit();
    }

    public void OnNewGameButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
