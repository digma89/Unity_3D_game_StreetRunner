using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

// reference to manage my scenes
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    // PRIVATE INSTANCE VARIABLES ++++++++++++++++++
    private float time = 50;
    private int _livesValue;
    private int _scoreValue;
    private bool _gameOver = false;

    public GameObject Enemy;
    public float numEnemies = 50f;

    [Header("UI Objects")]
    public Text LivesLabel;
    public Text ScoreLabel;
    public Text GameOverLabel;
    public Text FinalScoreLabel;
    public Button RestartButton;

    private GameObject[] _spawns;
    private List<GameObject> _enemies = new List<GameObject>();
    private int _currentSpawnIndex = 0;
    
    // PUBLIC PROPERTIES +++++++++++++++++++++++++++
    public int LivesValue
    {
        get
        {
            return this._livesValue;
        }

        set
        {
            this._livesValue = value;
            if (this._livesValue <= 0)
            {
                this.LivesLabel.text = "Lives: " + 0;
                this._endGame();
            }
            else
            {
                this.LivesLabel.text = "Lives: " + this._livesValue;
            }
        }
    }

    public int ScoreValue
    {
        get
        {
            return this._scoreValue;
        }

        set
        {
            this._scoreValue = value;
            this.ScoreLabel.text = "Score: " + this._scoreValue;
        }
    }


    // Use this for initialization
    void Start()
    {
        _spawns = GameObject.FindGameObjectsWithTag("SpawnPoint");
        for (int i = 0; i < numEnemies; i++)
        {
            GameObject spwn = _spawns[this.GetRespawnIndex()];
            GameObject en = Instantiate(Enemy, spwn.transform.position, Quaternion.identity) as GameObject;
            _enemies.Add(en);
        }

        //RestartButton.onClick.AddListener(RestartButton_Click);
        this.LivesValue = 5;
        this.ScoreValue = 0;
        this.GameOverLabel.gameObject.SetActive(false);
        this.FinalScoreLabel.gameObject.SetActive(false);
        this.RestartButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        time -= Time.deltaTime;
        if (time <= 0 && _gameOver) {
            Debug.Log("timer!!");
            time = 0;
            SceneManager.LoadScene("Main");
        }

        for (int i = 0; i < numEnemies; i++)
        {
            if (_enemies[i].gameObject.activeInHierarchy == false)
            {
                GameObject spwn = _spawns[this.GetRespawnIndex()];
                _enemies[i].transform.position = spwn.transform.position;
                _enemies[i].SetActive(true);
            }
        }
    }

    private int GetRespawnIndex() {
        int numSpawns = this._spawns.Length;
        if (this._currentSpawnIndex == numSpawns - 1) {
            this._currentSpawnIndex = 0;
        }
        int _ret = this._currentSpawnIndex;
        this._currentSpawnIndex++;
        return _ret;
    }

    private void _endGame()
    {       
           _gameOver = true;
           Cursor.lockState = CursorLockMode.None;
           Cursor.visible = true;
           this.GameOverLabel.gameObject.SetActive(true);
           this.FinalScoreLabel.text = "Final Score: " + this.ScoreValue;
           this.FinalScoreLabel.gameObject.SetActive(true);
           this.RestartButton.gameObject.SetActive(true);
           GameObject.Find("Player").GetComponent<FirstPersonController>().enabled = false;
    }


    public void RestartButton_Click()
    {
        Debug.Log("You have clicked the button!");        
        SceneManager.LoadScene("Main");
        _gameOver = false;
    }
}