using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScore : MonoBehaviour
{
    Score scoreScript;

    void Start()
    {
        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();

        scoreScript.ResetScore();
    }
}
