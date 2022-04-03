using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    Animator panellAnim;
    private GameObject Panell;

    [Header("Options")]
    public int boxDistance = 1;
    public string sceneToTransferTo;
    public bool hasTransition = true;

    [HideInInspector]
    public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Panell = GameObject.FindGameObjectWithTag("panell");
        panellAnim = Panell.GetComponent<Animator>();
    }

    void Update()
    {
        if ((Vector2.Distance(transform.position, player.position) < boxDistance))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(End());
            }
        }
    }

    IEnumerator End()
    {
        if (hasTransition == true)
        {
            panellAnim.SetTrigger("Change");
        }
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToTransferTo);
    }
}
