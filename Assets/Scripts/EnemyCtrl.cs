using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    
    public GameObject HitEffect;
    private int HP;
    private int HouseHp;
    private GameObject Player;
    private GameObject House;
    private GameObject director;
    private NavMeshAgent navMesh;
    private Animator ani;
    private bool isAttack;

    void Start()
    {
        HP = 30;
        HouseHp = 100;
        Player = GameObject.Find("Player");
        House = GameObject.Find("HouseCtrl");
        director = GameObject.Find("GameDirector");
        navMesh = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        navMesh.destination = House.transform.position;
    }

    void Update()
    {
        float Distance = Vector3.Distance(House.transform.position, transform.position);
        if (Distance <= 2.0f) {
            navMesh.Stop();
            if (isAttack == false) {
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
        isAttack = false;
        ani.SetBool("Attak", false);
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Bullet")) {
            GameObject hitEffect = Instantiate(HitEffect, coll.transform.position, Quaternion.Euler(coll.transform.position));
            Destroy(coll.gameObject);
            Destroy(hitEffect, 2.0f);
            HP -= 10;
            if (HP <= 0) {
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.CompareTag("House")) {
            GameObject hitEffect = Instantiate(HitEffect, coll.transform.position, Quaternion.Euler(coll.transform.position));
            Debug.Log("Attacked!");
            Destroy(gameObject);
            Destroy(hitEffect, 2.0f);
            HouseHp -= 10;
            this.director.GetComponent<GameDirector>().HitHouse();
            if (HouseHp <= 0) {
                Destroy(coll.gameObject);
            }
        }
    }
}
