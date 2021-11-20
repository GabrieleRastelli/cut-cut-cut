using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btn_left_handler : MonoBehaviour
{
    public Lumberjack lumberjack;
    public Tree tree;
    public void cutTreeLeft()
    {
        if (!GameController.gameover)
        {
            if (lumberjack.position.Equals("dx"))
            {
                /* in this case we have to switch character position */
                lumberjack.position = "sx";
                lumberjack.transform.position = lumberjack.sxPosition;
                lumberjack.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            lumberjack.animator.Play("lumberjack_cut");
            tree.cutTree();
        }
    }
}
