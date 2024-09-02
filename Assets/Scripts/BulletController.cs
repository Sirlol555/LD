using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<Rigidbody2D>().AddForce(transform.right * 0, ForceMode2D.Impulse);
        Anim.SetTrigger("BulletHit");
    }

    public void SetIdleAnimation()
    {
        Anim.SetTrigger("BulletIdle");
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
