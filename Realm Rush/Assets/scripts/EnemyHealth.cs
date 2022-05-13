using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Add amount to maxhitPoints when enemy dies")]
    [SerializeField] int currentHitpoints = 0;
    [SerializeField] int difficultRamp = 1;
    Enemy enemy;
    // Start is called before the first frame update

    void Start(){
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHitpoints = maxHitPoints;
    }

    void OnParticleCollision(GameObject other){
        ProcessHit();
    }

    void ProcessHit(){
        currentHitpoints--;

        if(currentHitpoints <= 0){
            gameObject.SetActive(false);
            maxHitPoints += difficultRamp;
            enemy.RewardGold();
        }
            

    }
}
