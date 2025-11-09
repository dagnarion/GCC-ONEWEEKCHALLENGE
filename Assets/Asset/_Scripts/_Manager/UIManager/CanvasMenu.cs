using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : UICanvas
{
    public void StartGame()
    {
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        GameManager.Instance.UpdateGameState(GameState.OnPlay);
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        AudioManager.Instance.PlaySound(SfxSoundType.Button);
        Application.Quit();
    }
}
