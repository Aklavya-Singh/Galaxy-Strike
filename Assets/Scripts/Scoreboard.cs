using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreboardText;
    
    private int playerScore;
    
    public void IncreaseScore(int amount)
    {
        playerScore += amount;
        scoreboardText.text = playerScore.ToString();
    } 
}
