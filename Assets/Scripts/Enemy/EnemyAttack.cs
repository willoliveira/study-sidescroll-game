using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int damageTouch = 15;

    private PlayerHealth pHealth;

    // Use this for initialization
    void Start() {
        pHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            pHealth = coll.gameObject.GetComponent<PlayerHealth>();
            pHealth.TakeDamage(damageTouch);
        }
    }
}
