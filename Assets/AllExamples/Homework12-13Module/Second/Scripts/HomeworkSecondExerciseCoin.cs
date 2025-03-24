using UnityEngine;

public class HomeworkSecondExerciseCoin : MonoBehaviour
{
    [SerializeField] private HomeworkSecondExerciseGame _game;
    private void OnTriggerEnter(Collider other)
    {
        BallForDetect ball = other.GetComponent<BallForDetect>();

        if (ball != null)
        {
            _game.FoundCoin();
            gameObject.SetActive(false);
        }
    }
}
