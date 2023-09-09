using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public GameObject Bullet;

    public float nextFire = 0.0f;

    public float fireRate = 0.1f;

    public AudioSource fireSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
            StartCoroutine(HideMuzzle(0.12f));
            fireSound.Play();
        }
    }
        public void Fire()
        {
            Instantiate(Bullet, transform.position, transform.rotation);
        }
        IEnumerator HideMuzzle(float secondUntilDestroy)
        {
            yield return new WaitForSeconds(secondUntilDestroy);
        }
    }

