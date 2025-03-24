using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    private const string RestartMessage = "To restart key down space";
    private const string WinMessage = "You Win! Great Job";
    private const string LoseMessage = "You Lose! Great Job";

    [SerializeField] private float _timeToWin;
    [SerializeField] private float _timeToLose;
    [SerializeField] private float _winZone;

    [SerializeField] private Hero _hero;
    [SerializeField] private Enemy _enemy;

    [SerializeField] private TMP_Text _timerToWinText;
    [SerializeField] private TMP_Text _timerToLoseText;

    private float _startTimeToWin;
    private float _startTimeToLose;

    private bool _isReadyToRestart = false;

    private void Awake()
    {
        _startTimeToWin = _timeToWin;
        _startTimeToLose = _timeToLose;

        TextViewUpdate();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isReadyToRestart)
        {
            Debug.Log(1);
            RestartGame();
            _isReadyToRestart = false;
        }

        Vector3 diraction = _hero.transform.position - _enemy.transform.position;

        if (diraction.magnitude < _winZone)
            TimerToWin();
        else
            TimerToLose();

        TextViewUpdate();
    }

    private void TimerToWin()
    {
        _timerToWinText.color = Color.green;
        _timerToLoseText.color = Color.white;

        if (_timeToWin >= 0)
            _timeToWin -= Time.deltaTime;
        else
            ClearGame(WinMessage);

        _timeToLose = _startTimeToLose;
    }

    private void TimerToLose()
    {
        _timerToLoseText.color = Color.red;
        _timerToWinText.color = Color.white;

        if (_timeToLose >= 0)
            _timeToLose -= Time.deltaTime;
        else
            ClearGame(LoseMessage);

        _timeToWin = _startTimeToWin;
    }

    private void OffCharacters()
    {
        _hero.gameObject.SetActive(false);
        _enemy.gameObject.SetActive(false);
    }

    private void OnCharacters()
    {
        _hero.gameObject.SetActive(true);
        _enemy.gameObject.SetActive(true);
    }

    private void TextViewUpdate()
    {
        _timerToWinText.text = $"Time To Win:\n{_timeToWin.ToString("0.00")}";
        _timerToLoseText.text = $"Time To Lose:\n{_timeToLose.ToString("0.00")}";
    }

    private void ClearGame(string message)
    {
        Debug.Log(message);

        OffCharacters();

        _isReadyToRestart = true;

        Debug.Log(RestartMessage);
    }

    private void RestartGame()
    {
        _timeToWin = _startTimeToWin;
        _timeToLose = _startTimeToLose;

        _enemy.SetStartPosition();
        _hero.SetStartPosition();

        OnCharacters();

        _enemy.SetNewRandomPoints();
    }
}