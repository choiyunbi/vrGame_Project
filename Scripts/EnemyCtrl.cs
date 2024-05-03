using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject hitEffet;
    private int HP;
    private GameObject player;
    private NavMeshAgent navMesh;
    private Animator ani;
    private bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        HP = 10;
        player = GameObject.Find("OVRPlayerController");
        navMesh = GetComponent<NavMeshAgent>();
        ani = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 2.0f)
        {
            navMesh.Stop();
            if(isAttack == false)
            {
                ani.SetBool("Idle", true);
                StartCoroutine(Attack());
            }
        }
    }
    IEnumerator Attack() 
    {
        isAttack = true;
        yield return new WaitForSeconds(3.0f);
        ani.SetBool("Attack", true);
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("Attack", false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Bullet")) {
            GameObject effect = Instantiate(hitEffet, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(effect, 2.0f);
            HP -= 10;
            if (HP <= 0f) {
                Destroy(gameObject);
                player.GetComponent<PlayerControl>().ScoreUp(1);
            }
        }
    }
}