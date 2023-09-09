using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public string tagObject;
    public float speed;
    public Transform targetPlayer;
    public ZombieCount zombie;
    public LayerMask layer;
    

    Animator animator;

    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (targetPlayer == null)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
        //navMeshAgent.destination = targetPlayer.position;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1, layer))
        {
            
            Time.timeScale = 0;
            zombie.fail = true;

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagObject)
        {
            animator.SetTrigger("Death");
            Destroy(other.gameObject);
            //navMeshAgent.isStopped = true;
            speed = 0;
            zombie.zomCount++;
            StartCoroutine(clearObject());
            
        }
    }
    IEnumerator clearObject()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
