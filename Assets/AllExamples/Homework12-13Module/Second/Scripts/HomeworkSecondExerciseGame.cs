using TMPro;
using UnityEngine;

public class HomeworkSecondExerciseGame : MonoBehaviour
{
    private const string WinMessage = "You Win";

    [SerializeField] private BallForDetect _ball;

    [SerializeField] private TMP_Text _countOfCoinsText;

    private int _countOfCoins = 7;

    private void Awake()
    {
        _countOfCoinsText.text = $"Coins: {_countOfCoins}";
    }

    private void WinGame()
    {
        _ball.gameObject.SetActive(false);
        Debug.Log(WinMessage);
    }

    public void FoundCoin()
    {
        _countOfCoins--;

        if (_countOfCoins == 0)
            WinGame();

        _countOfCoinsText.text = $"Coins: {_countOfCoins}";
    }
}
