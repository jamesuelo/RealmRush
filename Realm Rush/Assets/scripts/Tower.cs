using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    void Start(){
        StartCoroutine(Build());
    }
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay=1f;
    public bool CreateTower(Tower towerprefab, Vector3 pos)
    {
    Bank bank = FindObjectOfType<Bank>();
        if (bank == null)
        {
            return false;
        }
        if (bank.CurrentBalance >= cost)
        {
            Instantiate(towerprefab, pos, Quaternion.identity);
            bank.Withdraw(cost);
            return true;
        }
        return false;

    }

    IEnumerator Build(){
        foreach(Transform child in transform){
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child){
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach(Transform child in transform){
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach(Transform grandchild in child){
                grandchild.gameObject.SetActive(true);
            }
        }

    }
}
