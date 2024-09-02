using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastHPController : MonoBehaviour
{
    private float fastHP = 1;
    public PlayerController playerController;
    public AudioSource hitSource;
    public AudioSource deathSource;
    private Animator Anim;
    public PolygonCollider2D PG2D;

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            fastHP--;
            hitSource.Play();
            if (fastHP <= 0)
            {
                PG2D.enabled = false;
                Anim.SetTrigger("FastDead");
                deathSource.Play();
                playerController.UpdateScore();
            }
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        _ = playerController == null;
    }
}
