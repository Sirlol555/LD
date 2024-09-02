using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowHPController : MonoBehaviour
{
    private float enemyHP = 5;
    private float slowForce = 0.5f;
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
            enemyHP--;
            Anim.SetTrigger("SlowHit");
            hitSource.Play();
            StartCoroutine(HitMove());
            if (enemyHP <= 0)
            {
                PG2D.enabled = false;
                deathSource.Play();
                playerController.UpdateScore();
                GetComponent<Rigidbody2D>().AddForce(transform.right * 0, ForceMode2D.Impulse);
                Anim.SetTrigger("SlowDead");
            }
        }
    }

    private IEnumerator HitMove()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * slowForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
        Anim.SetTrigger("SlowMove");
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
