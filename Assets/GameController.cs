using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int numberOfCutFromLastSpawn;
    public static int totalNumberOfCut;
    public GameObject branchToSpawn;
    public static bool gameover;
    private bool gameAlreadyEnded;
    public List<GameObject> branchesSpawned;
    public GameObject playButton;
    public GameObject dxButton;
    public GameObject sxButton;
    public Text highScoreTextField;
    private int highscore;
    public static float StartTime;
    public static float lifeDecreaseSpeed = 0.00003f;
    public static float lifeIncreaseSpeed = 0.02f;



    // Start is called before the first frame update
    void Start()
    {
        Tree.treeBranchToFade = 0;
        branchesSpawned = new List<GameObject>();
        spawnFirstBranch();
        numberOfCutFromLastSpawn = 0;
        gameAlreadyEnded = false;
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        health_bar_handler.SetHealthBarValue(0.5f);
        StartTime = Time.time;
        totalNumberOfCut = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!gameover)
        {
            float TimerControl = Time.time - StartTime;
            float secsAlive = TimerControl % 60;
            /* decrease healthbar value increasing speed every 2.5 seconds */
            health_bar_handler.SetHealthBarValue(health_bar_handler.GetHealthBarValue() - (lifeDecreaseSpeed * secsAlive));

            /* ad ogni frame controllo se devo spawnare ramo */
            /* ad ogni taglio spawno un ramo */
            if (numberOfCutFromLastSpawn % 2 != 0)
            {
                numberOfCutFromLastSpawn = 0;
                spawnBranch();
            }

        }
        else
        {
            endGame();
        }
    }

    public void spawnFirstBranch()
    {
        /* if sxVsDx < 0 we spawn a branch on the left. if sxVsDx >= 0 we spawn a branch on the right */
        float sxVsDx = Random.Range(-1f, 1f);
        if (sxVsDx < 0) /* sx */
        {
            /* spawna ramo */
            Vector2 spawnPos = new Vector2(-2f, 1.4f);
            branchesSpawned.Add(Instantiate(branchToSpawn, spawnPos, new Quaternion(0, 180, 0, 0)));
        }
        else /* dx */
        {
            /* spawna ramo */
            Vector2 spawnPos = new Vector2(2f, 1.4f);
            branchesSpawned.Add(Instantiate(branchToSpawn, spawnPos, new Quaternion(0, 0, 0, 0)));
        }
    }

    public void spawnBranch()
    {
        /* if sxVsDx < 0 we spawn a branch on the left. if sxVsDx >= 0 we spawn a branch on the right */
        float sxVsDx = Random.Range(-1f, 1f);
        if (sxVsDx < 0) /* sx */
        {
            /* spawna ramo */
            Vector2 spawnPos = new Vector2(-2f, branchesSpawned[branchesSpawned.Count-1].transform.position.y + 3f);
            branchesSpawned.Add(Instantiate(branchToSpawn, spawnPos, new Quaternion(0, 180, 0, 0)));
        }
        else /* dx */
        {
            /* spawna ramo */
            Vector2 spawnPos = new Vector2(2f, branchesSpawned[branchesSpawned.Count - 1].transform.position.y + 3f);
            branchesSpawned.Add(Instantiate(branchToSpawn, spawnPos, new Quaternion(0, 0, 0, 0)));
        }
    }

    private void endGame()
    {
        if (!gameAlreadyEnded)
        {
            gameAlreadyEnded = true;
            if (points_scored_handler.points > highscore)
            {
                /* saves new highscore */
                highScoreTextField.gameObject.SetActive(true);
                highScoreTextField.GetComponent<Text>().text = "New Highscore!\n"+highscore.ToString();
                highscore = points_scored_handler.points;
                PlayerPrefs.SetInt("highscore", points_scored_handler.points);
                PlayerPrefs.Save();
            }
            else
            {
                highScoreTextField.gameObject.SetActive(true);
                highScoreTextField.GetComponent<Text>().text = "Your Highscore\n" + highscore.ToString();
            }

            playButton.SetActive(true);
            dxButton.SetActive(false);
            sxButton.SetActive(false);
        }
    }
}
