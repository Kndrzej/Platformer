using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMainMenu : MonoBehaviour
{
   public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
