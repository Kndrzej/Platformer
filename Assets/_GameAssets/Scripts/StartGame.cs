using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void StartGameOnLevelOne()
    {
        SceneManager.LoadScene(1);
    }
}
