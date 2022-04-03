using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Bomb : MonoBehaviour
{
    Animator panelAnim;
    private GameObject Panel;
    Score scoreScript;

    Animator panellAnim;
    private GameObject Panell;

    private bool Died = false;

    private float number = 0.5f;
    private float numberr = 1.5f;

    [Header("Timer Settings")]
    public float Countdown;
    public float timeTillRedBomb;
    public float timeTillFasterRedBomb;
    public TextMeshProUGUI countdownDisplay;

    [Header("Item Settings")]
    public float timeAddedWithWater;
    public float timeSubtractedWithFire;

    [Header("Item Pattern Settings")]
    public GameObject[] itemPatterns;

    [Header("Bomb Sprite Settings")]
    public Image timeBomb;
    public Sprite Normal;
    public Sprite Red;
    public GameObject BoomBomb;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip Boom;

    private float countdownAsSec;

    public void Awake()
    {
        Destroy(GameObject.FindWithTag("Title"));
    }
    
    public void Start()
    {
        Time.timeScale = 1f;

        Panel = GameObject.FindGameObjectWithTag("panel");
        panelAnim = Panel.GetComponent<Animator>();

        Panell = GameObject.FindGameObjectWithTag("panell");
        panellAnim = Panell.GetComponent<Animator>();

        scoreScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<Score>();

        SpawnItems();
        StartCoroutine(RedTimer());
    }
    
    public void Update()
    {
        countdownAsSec = Mathf.FloorToInt(Countdown % 60);
        countdownDisplay.text = (countdownAsSec.ToString());
        if (Countdown > 0)
        {
            Countdown -= Time.deltaTime;
        } else if (Died == false)
        {
            StartCoroutine(End());
        }
    }

    public void MoreTime()
    {
        Countdown += timeAddedWithWater;
    }

    public void LessTime()
    {
        Countdown -= timeSubtractedWithFire;
    }

    public void DestroyItems()
    {
        GameObject[] itemF = GameObject.FindGameObjectsWithTag("Fire");
        foreach (GameObject item in itemF)
            GameObject.Destroy(item);
        Destroy(GameObject.FindWithTag("Water"));
    }

    public void SpawnItems()
    {
        int rand = Random.Range(0, itemPatterns.Length);
        Instantiate(itemPatterns[rand], transform.position, Quaternion.identity);
    }

    IEnumerator End()
    {
        Died = true;
        DestroyItems();
        BoomBomb.SetActive(false);
        Time.timeScale = 1f;
        panelAnim.SetTrigger("Change");
        yield return new WaitForSeconds(number);
        audioSource.PlayOneShot(Boom);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(numberr);
        Time.timeScale = 1f;
        panellAnim.SetTrigger("Change");
        scoreScript.HighScore();
        yield return new WaitForSeconds(1);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Death");
    }

    IEnumerator RedTimer()
    {
        yield return new WaitForSeconds(timeTillRedBomb);
        timeBomb.sprite = Red;
        Time.timeScale = 2f;
        yield return new WaitForSeconds(timeTillFasterRedBomb);
        Time.timeScale = 3f;
    }
}
