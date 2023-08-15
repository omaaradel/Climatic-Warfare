using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI livestext;
    private int score;
    public int scoreone;
    public Button retartb;
    public TextMeshProUGUI gotext;
    public bool active=false;
    public bool dead = false;
    private int lives;
    public GameObject mainmenu;
    public GameObject mainmenubg;
    public GameObject instructionmenu;
    private GameObject[] enemies;

    public AudioSource destroyenemysound;
    public AudioSource highscoreceleb;
    public AudioSource killingsound;
    public AudioSource confirmchoicesound;

    // Start is called before the first frame update
    void Start()
    {

    }
    public void startgame()
    {
        //scoretextm.gameObject.SetActive(true);
        //livetextm.gameObject.SetActive(true);
        //seasontextm.gameObject.SetActive(true);
        confirmchoicesound.Play();
        dead = false;
        active = true;
        mainmenu.gameObject.SetActive(false);
        mainmenubg.gameObject.SetActive(false);
        score = 0;
        scoreone = 0;
        lives = 3;
        livestext.text = "Lives: " + lives;
        scoretext.text = "Score: " + score;

    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void sublives()
    {
        lives -= 1;
        if (lives < 1)
        {
            gameover();
        }
        if (lives >= 0)
        {
            livestext.text = "Lives: " + lives;
        }
        else
        {
            livestext.text = "Lives: 0";
        }
    }
    public void addscore(int scoreadded)
    {

        score += scoreadded;
        scoreone++;
        killingsound.Play();
        if (scoreone % 5 == 0) {
            highscoreceleb.Play();
        }
        scoretext.text = "Score  " + score;

    }
    public void gameover()
    {
        Debug.Log("you lost");
        retartb.gameObject.SetActive(true);
        active = false;
        dead = true;
        Time.timeScale = 0;
        gotext.gameObject.SetActive(true);
    }
    public void restart()
    {
        Time.timeScale = 1;
        confirmchoicesound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void quit()
    {
        confirmchoicesound.Play();
        Application.Quit();
    }
    public void startmainmenu()
    {
        confirmchoicesound.Play();
        mainmenu.gameObject.SetActive(true);
        instructionmenu.gameObject.SetActive(false);
    }
    public void startinstruction()
    {
        confirmchoicesound.Play();
        instructionmenu.gameObject.SetActive(true);
        mainmenu.gameObject.SetActive(false);
    }
    public void DestroyAllEnemies()
    {
        if (GameObject.FindGameObjectsWithTag("fallenemy").Length > 0)
        {
            destroyenemysound.Play();
            enemies = GameObject.FindGameObjectsWithTag("fallenemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().DestroyEnemy();
                
            }

        }
        if (GameObject.FindGameObjectsWithTag("springenemy").Length > 0)
        {
            destroyenemysound.Play();
            enemies = GameObject.FindGameObjectsWithTag("springenemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().DestroyEnemy();
            }
        }
        if (GameObject.FindGameObjectsWithTag("summerenemy").Length > 0)
        {
            destroyenemysound.Play();
            enemies = GameObject.FindGameObjectsWithTag("summerenemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().DestroyEnemy();
            }
            
        }
        if (GameObject.FindGameObjectsWithTag("winterenemy").Length > 0)
        {
            destroyenemysound.Play();

            enemies = GameObject.FindGameObjectsWithTag("winterenemy");
            foreach (GameObject enemy in enemies)
            {
                enemy.GetComponent<Enemy>().DestroyEnemy();
            }
            
        }


    }
}
