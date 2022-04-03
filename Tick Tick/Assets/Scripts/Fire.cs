using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    Bomb bombScript;
    Score scoreScript;

    [Header("Options")]
    public int boxDistance = 1;

    [Header("Visuals")]
    public GameObject Particles;

    [HideInInspector]
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bombScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Bomb>();
        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();
    }

    void Update()
    {
        if ((Vector2.Distance(transform.position, player.position) < boxDistance))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bombScript.LessTime();
                scoreScript.LessScore();
                Instantiate(Particles, transform.position, transform.rotation);
                bombScript.DestroyItems();
                bombScript.SpawnItems();
            }
        }
    }
}
