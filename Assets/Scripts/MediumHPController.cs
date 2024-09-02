using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MediumHPController : MonoBehaviour
{
    private float mediumHP = 3;
    private float mediumForce = 1f;
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
            mediumHP--;
            Anim.SetTrigger("MediumHit");
            hitSource.Play();
            StartCoroutine(HitMove());
            if (mediumHP <= 0)
            {
                PG2D.enabled = false;
                Anim.SetTrigger("MediumDead");
                deathSource.Play();
                playerController.UpdateScore();
            }
        }
    }

    private IEnumerator HitMove()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * mediumForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
        Anim.SetTrigger("MediumWalk");
        StopAllCoroutines();
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
