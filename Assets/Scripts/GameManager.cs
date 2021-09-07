using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject walls;

    [SerializeField] private GameObject window;

    [SerializeField] private Button restartGame;
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button fire;

    [SerializeField] private float timeToSpawnBlock;

    private Vector3 _wallsSpawnPosition;
    private Vector3 _windowSpawnPosition;
    private Window _cachedWindowClass;
   
    
    public void GameOver()
    {
        var restartAnim = restartGame.GetComponent<Animation>();
        var backToMenuAnim = backToMenu.GetComponent<Animation>(); 
        var fireAnim = fire.GetComponent<Animation>(); 
        restartAnim.Play("RestartGameAnim");
        backToMenuAnim.Play("BackToMenuAnim");
        fireAnim.Play("FireButtonDown");
        // Time.timeScale = 0;
    }
    
    private void Start()
    {
        _wallsSpawnPosition = walls.transform.position;
        _windowSpawnPosition = window.transform.position;
        _cachedWindowClass = window.GetComponent<Window>();

        Repeat();
    }

    private void Repeat()
    {
        StartCoroutine(SpawnBlocksWithWindows());
    }

    private IEnumerator SpawnBlocksWithWindows()
    {
        yield return new WaitForSeconds(timeToSpawnBlock); // время появления нового объекта в секундах.

        var randomBias = Random.Range(-5f, 5f);

        window.transform.position = new Vector3(_windowSpawnPosition.x + randomBias,
             _windowSpawnPosition.y, _windowSpawnPosition.z);
        _cachedWindowClass.SetRandomColor();
        
        walls.transform.position = new Vector3(_wallsSpawnPosition.x + randomBias,
            _wallsSpawnPosition.y, _wallsSpawnPosition.z);
        Repeat();
    }
}

