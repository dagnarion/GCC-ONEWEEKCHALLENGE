using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasMainGame : UICanvas
{
    [SerializeField] HealthSystem playerHealth;
    [SerializeField] Sprite fullHeart;
    [SerializeField] Sprite emptyHeart;
    [SerializeField] Image[] hearts;
    [SerializeField] TextMeshProUGUI Distance;
    [SerializeField] TextMeshProUGUI Coin;
    public override void SetUp()
    {
        base.SetUp();
    }
    void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth.currentHp)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
        Distance.text = "DISTANCE: "+LevelManager.Instance.CurrentDistance;
        Coin.text = ": " + EconomyManager.Instance.CurrentMoney;
    }
}
