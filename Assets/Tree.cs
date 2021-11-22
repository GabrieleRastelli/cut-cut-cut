using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    Vector2 initialPosition;
    public GameController gameController;
    public static int treeBranchToFade;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        treeBranchToFade = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cutTree()
    {
        if (!GameController.gameover)
        {
            health_bar_handler.SetHealthBarValue(health_bar_handler.GetHealthBarValue() + GameController.lifeIncreaseSpeed);

            gameController.numberOfCutFromLastSpawn++;
            points_scored_handler.points++;

            if (transform.position.y >= -1.8f)
            {
                /* moves tree down */
                transform.position = new Vector2(transform.position.x, transform.position.y - 1.5f);
            }
            else
            {
                /* riavvolge albero */
                transform.position = initialPosition;
            }

            /* moves branches down */
            moveBranchesDown();
        }
    }

    public void moveBranchesDown()
    {
        List<GameObject> branchesToRemove = new List<GameObject>();

        foreach (GameObject treeBranch in gameController.branchesSpawned)
        {
            if (treeBranch.transform.position.y < -7f)
            {
                branchesToRemove.Add(treeBranch);
            }
            else
            {
                treeBranch.transform.position = new Vector2(treeBranch.transform.position.x, treeBranch.transform.position.y - 1.5f);
            }
        }

        foreach (GameObject treeBranchToDestroy in branchesToRemove)
        {
            treeBranchToFade--;
            GameController.totalNumberOfCut -= 2;
            gameController.branchesSpawned.Remove(treeBranchToDestroy);
            Destroy(treeBranchToDestroy);
        }
    }

}
