using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text scoreText;
    public Text timeText;
    public Spawner enemySpawner;
    public Spawner chestSpawner;
    public Animator hudAnimator;
    public Text resultScoreText;
    public Text ammoText;
    public GameObject playerPrefab;
    public GameObject spawnPoint;
    public PacManAttack attack;

    private GameObject player;
    long score = 0;
    float timer = 0;
    bool isDead = false;

    // Use this for initialization
    void Start()
    {
        InitGame();
        InvokeRepeating("SetScore", 0.01f, 0.25f);
    }

    private void InitGame()
    {
        scoreText.text = "Score: 0";
        SpawnPlayer();
        attack = player.GetComponent<PacManAttack>();
        print("Spawning Things");
        enemySpawner.spawnAll();
        chestSpawner.spawnAll();
        print("Finished");
    }

    private void SpawnPlayer()
    {
        player = Instantiate(playerPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            HandleInput();
            updateTime();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SetScore()
    {
        updateScore(1);
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Space))
        {
            attack.shoot();
        }
    }

    public void dead()
    {
        isDead = true;
        hudAnimator.SetTrigger("DeadTrigger");
        resultScoreText.text = "You survived " + Mathf.RoundToInt(timer % 60) + " seconds! \n Press X to start new Game";
        DestroyAll();
    }

    private void DestroyAll()
    {
        Destroy(player);
        foreach (var item in FindObjectsOfType<GhostBehaviour>())
        {
            Destroy(item.gameObject);
        }
    }

    private void updateTime()
    {
        timer += Time.deltaTime;
        float minutes = Mathf.Floor(timer / 60);


        float seconds = Mathf.RoundToInt(timer % 60);
        string minutesText = minutes < 10 ? "0" + minutes : minutes + "";
        string secondsText = seconds < 10 ? "0" + seconds : seconds + "";
        timeText.text = "Time: " + minutesText + ":" + secondsText;
    }

    public void updateScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }
}
