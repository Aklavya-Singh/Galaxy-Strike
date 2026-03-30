using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyDestroyedVFX;
    [SerializeField] private float enemyHitpoints;
    [SerializeField] private int scoreGiven;

    private Scoreboard scoreboard;

    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        enemyHitpoints--;

        if (!(enemyHitpoints <= 0)) return;
        scoreboard.IncreaseScore(scoreGiven);
        Instantiate(enemyDestroyedVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
