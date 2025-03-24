using TMPro;
using UnityEngine;

public class HomeworkGame : MonoBehaviour
{
    private const string LossMessage = "You Loss";
    private const string WinMessage = "You Win";

    [SerializeField] private Ball _ball;

    [SerializeField] private TMP_Text _countOfCoinsText;
    [SerializeField] private TMP_Text _timerText;

    [SerializeField] private float _timer;

    private int _countOfCoins = 5;

    private bool _gameActive = true;

    private void Awake()
    {
        _countOfCoinsText.text = $"Coins: {_countOfCoins}";
        _timerText.text = $"Timer: {_timer:0.00}";
    }

    private void Update()
    {
        if (_gameActive)
            Timer();
    }

    private void Timer()
    {
        if (_timer <= 0)
        {
            _timer = 0;
            GameResult(LossMessage);
        }
        else
            _timer -= Time.deltaTime;

        _timerText.text = $"Timer: {_timer:0.00}";
    }

    private void GameResult(string message)
    {
        _gameActive = false;
        _ball.gameObject.SetActive(false);

        _timerText.text = $"Timer: {_timer:0.00}";

        Debug.Log(message);
    }

    public void FoundCoin()
    {
        _countOfCoins--;

        if (_countOfCoins == 0)
            GameResult(WinMessage);

        _countOfCoinsText.text = $"Coins: {_countOfCoins}";
    }
}
