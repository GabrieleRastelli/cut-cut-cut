using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_right_handler : MonoBehaviour
{
    public Lumberjack lumberjack;
    public Tree tree;
    public void cutTreeRight()
    {
        if (!GameController.gameover)
        {
            if (lumberjack.position.Equals("sx"))
            {
                /* in this case we have to switch character position */
                lumberjack.position = "dx";
                lumberjack.transform.position = lumberjack.dxPosition;
                lumberjack.transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            lumberjack.animator.Play("lumberjack_cut");
            tree.cutTree();
        }
    }
}
