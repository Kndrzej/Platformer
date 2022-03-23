using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameState currentGameState = GameStateManager.Instance.CurrentGameState;
            GameState newGameState = currentGameState == GameState.Gameplay ? GameState.Paused : GameState.Gameplay;
            GameStateManager.Instance.SetState(newGameState);
        }
        if(GameStateManager.Instance.CurrentGameState == GameState.Paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (GameStateManager.Instance.CurrentGameState == GameState.Gameplay)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
