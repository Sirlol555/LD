using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float randomNumber;
    private float randomEnemy;
    private float slowForce = 0.5f;
    private float mediumForce = 1f;
    private float fastForce = 1.5f;
    public GameObject slowPrefab;
    public GameObject mediumPrefab;
    public GameObject fastPrefab;
    public Transform enemySpawnPoint1;
    public Transform enemySpawnPoint2;
    public Transform enemySpawnPoint3;
    public Transform enemySpawnPoint4;
    public Transform enemySpawnPoint5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator RandomSpawning()
    {
        yield return new WaitForSeconds(2f);
        randomNumber = Random.Range(0, 5);
        randomEnemy = Random.Range(0, 3);
        if (randomNumber == 0)
        {
            if (randomEnemy == 0)
            {
                GameObject enemyTemp = Instantiate(slowPrefab, enemySpawnPoint1.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
            }
            if (randomEnemy == 1)
            {
                GameObject enemyTemp = Instantiate(mediumPrefab, enemySpawnPoint1.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
            }
            if (randomEnemy == 2)
            {
                GameObject enemyTemp = Instantiate(fastPrefab, enemySpawnPoint1.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * fastForce, ForceMode2D.Impulse);
            }
        }
        if (randomNumber == 1)
        {
            if(randomEnemy == 0)
            {
                GameObject enemyTemp = Instantiate(slowPrefab, enemySpawnPoint2.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 1)
            {
                GameObject enemyTemp = Instantiate(mediumPrefab, enemySpawnPoint2.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
            }
            if(randomEnemy ==2)
            {
                GameObject enemyTemp = Instantiate(fastPrefab, enemySpawnPoint2.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * fastForce, ForceMode2D.Impulse);
            }
        }
        if (randomNumber == 2)
        {
            if(randomEnemy == 0)
            {
                GameObject enemyTemp = Instantiate(slowPrefab, enemySpawnPoint3.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 1)
            {
                GameObject enemyTemp = Instantiate(mediumPrefab, enemySpawnPoint3.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 2)
            {
                GameObject enemyTemp = Instantiate(fastPrefab, enemySpawnPoint3.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * fastForce, ForceMode2D.Impulse);
            }
        }
        if(randomNumber == 3)
        {
            if (randomEnemy == 0)
            {
                GameObject enemyTemp = Instantiate(slowPrefab, enemySpawnPoint4.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
            }
            if (randomEnemy == 1)
            {
                GameObject enemyTemp = Instantiate(mediumPrefab, enemySpawnPoint4.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 2)
            {
                GameObject enemyTemp = Instantiate(fastPrefab, enemySpawnPoint4.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * fastForce, ForceMode2D.Impulse);
            }
        }
        if(randomNumber == 4)
        {
            if(randomEnemy == 0)
            {
                GameObject enemyTemp = Instantiate(slowPrefab, enemySpawnPoint5.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * slowForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 1)
            {
                GameObject enemyTemp = Instantiate(mediumPrefab, enemySpawnPoint5.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * mediumForce, ForceMode2D.Impulse);
            }
            if(randomEnemy == 2)
            {
                GameObject enemyTemp = Instantiate(fastPrefab, enemySpawnPoint5.position, transform.rotation);
                enemyTemp.GetComponent<Rigidbody2D>().AddForce(transform.right * -1 * fastForce, ForceMode2D.Impulse);
            }
        }
        StopAllCoroutines();
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomSpawning());
    }
}
