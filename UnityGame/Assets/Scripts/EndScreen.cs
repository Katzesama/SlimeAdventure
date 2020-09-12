using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
