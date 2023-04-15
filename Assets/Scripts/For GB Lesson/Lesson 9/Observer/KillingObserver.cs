using TMPro;
using UnityEngine;
using Asteroids;

public class KillingObserver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemyKillsText;
    
    private int enemyKillsCounter;
 
    private void Start()
    {
        enemyKillsCounter = 0;
    }
    

    public void Lister(Enemy enemy)
    {
        enemy.NotifyObserversEvent += HandleEvent;

    }

    private void HandleEvent()
    {
        enemyKillsCounter++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        enemyKillsText.text = enemyKillsCounter.ToString();
    }
}