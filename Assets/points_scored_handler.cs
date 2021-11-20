using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class points_scored_handler : MonoBehaviour
{
    public static int points;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = points.ToString();
    }
}
