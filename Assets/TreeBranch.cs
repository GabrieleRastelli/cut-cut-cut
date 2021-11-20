using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBranch : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /* tree branch doesn't move if hitten */
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
