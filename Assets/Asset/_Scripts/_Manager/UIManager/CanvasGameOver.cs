using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasGameOver : UICanvas
{
    public void BackToMainMenu()
    {
        // UI Manager
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        SceneManager.LoadScene(0);
        GameManager.Instance.UpdateGameState(GameState.OnMenu);
    }
    public void Quit()
    {
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        Application.Quit();
    }
    public void ResetLevel()
    {
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        GameManager.Instance.UpdateGameState(GameState.OnPlay);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
