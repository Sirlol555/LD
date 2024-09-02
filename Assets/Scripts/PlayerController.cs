using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public PlayerInput PlayerInput;
    public InputAction Move;
    public InputAction Shoot;
    private InputAction Restart;
    private InputAction Quit;


    private bool Moving;
    private float moveDirection;
    public Rigidbody2D PlayerRB2D;
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    private float force = 5f;
    public float cooldown = 0f;
    private bool hasShoot = false;
    public TMP_Text scoreText;
    public TMP_Text highscoreText;
    public TMP_Text livesText;

    private int lives = 3;
    public int score = 0;

    public AudioSource shotSource;
    public AudioSource livesSource;

    // Start is called before the first frame update
    void Start()
    {
        Move = PlayerInput.currentActionMap.FindAction("Move");
        Move.started += Move_Started;
        Move.canceled += Move_canceled;

        Shoot = PlayerInput.currentActionMap.FindAction("Shoot");
        Shoot.started += Shoot_started;
        Shoot.canceled += Shoot_canceled;

        Restart = PlayerInput.currentActionMap.FindAction("Restart");
        Restart.started += Restart_started;

        Quit = PlayerInput.currentActionMap.FindAction("Quit");
        Quit.started += Quit_started;

        scoreText.gameObject.SetActive(true);
        highscoreText.gameObject.SetActive(true);
        livesText.gameObject.SetActive(true);
        livesText.text = "Lives: " + lives.ToString();

        livesSource.Stop();
    }

    private void Quit_started(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    private void Restart_started(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        StopAllCoroutines();
        if(cooldown == 0 && hasShoot == false)
        {
            cooldown = 1;
            hasShoot = true;
            PlayerInput.currentActionMap.FindAction("Shoot").Disable();
        }
        
    }

    private void Shoot_started(InputAction.CallbackContext obj)
    {
        if(cooldown == 0f && hasShoot == false)
        {
            GameObject bulletTemp = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            bulletTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
            shotSource.Play();
            StartCoroutine(ShootTimer());
        }
    }

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        Moving = false;
    }

    IEnumerator ShootTimer()
    {
        yield return new WaitForSeconds(1f);
        GameObject bulletTemp = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        bulletTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
        shotSource.Play();
        StartCoroutine(ShootTimer());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SlowEnemy"))
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            Destroy(collision.gameObject);
            livesSource.Play();
        }

        if (collision.gameObject.CompareTag("MediumEnemy"))
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            Destroy(collision.gameObject);
            livesSource.Play();
        }

        if (collision.gameObject.CompareTag("FastEnemy"))
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            Destroy(collision.gameObject);
            livesSource.Play();
        }


    }

    private void OnDestroy()
    {
        Move.started -= Move_Started;
        Move.canceled -= Move_canceled;
        Shoot.started -= Shoot_started;
        Shoot.canceled -= Shoot_canceled;
        Restart.started -= Restart_started;
        Quit.started -= Quit_started;
    }

    IEnumerator CooldownTimer()
    {
        yield return new WaitForSeconds(1.0f);
        cooldown = 0;
        hasShoot = false;
        PlayerInput.currentActionMap.FindAction("Shoot").Enable();
        StopAllCoroutines();
    }

    private void Move_Started(InputAction.CallbackContext context)
    {
        Moving = true;
    }

    public void UpdateScore()
    {
        score += 200;
        HighScoreUpdate();
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    public void HighScoreUpdate()
    {
        if (PlayerPrefs.HasKey("SavedHighScore"))
        {
            if(score > PlayerPrefs.GetInt("SavedHighScore"))
            {
                PlayerPrefs.SetInt("SavedHighScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("SavedHighScore", score);
        }
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("SavedHighScore").ToString();



    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == true)
        {
            moveDirection = Move.ReadValue<float>();
            PlayerRB2D.velocity = new Vector2(0, moveDirection * 9);
        }
        else
        {
            PlayerRB2D.velocity = Vector2.zero;
        }

        if(cooldown == 1 && hasShoot == true)
        {
            StartCoroutine(CooldownTimer());
        }

        if (lives <= 0)
        {
            SceneManager.LoadScene(0);
        }

    }
}
