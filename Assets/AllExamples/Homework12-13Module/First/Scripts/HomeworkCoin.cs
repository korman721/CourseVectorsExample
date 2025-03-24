using UnityEngine;

public class HomeworkCoin : MonoBehaviour
{
    [SerializeField] private HomeworkGame _game;
    private void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();

        if (ball != null)
        {
            _game.FoundCoin();
            gameObject.SetActive(false);
        }
    }
}
