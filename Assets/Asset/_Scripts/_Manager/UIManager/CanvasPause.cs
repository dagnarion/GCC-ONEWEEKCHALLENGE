using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : UICanvas
{
    public void Continue()
    {
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        UIManager.Instance.CloseUIDirectly<CanvasPause>();
        GameManager.Instance.UpdateGameState(GameState.OnPlay);
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
