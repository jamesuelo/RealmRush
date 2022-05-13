using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField]  int startingBalance = 150;
    [SerializeField]  int currentBalance;
[SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance{get{return currentBalance;}}
    // Start is called before the first frame update
    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }

    // Update is called once per frame
    public void Deposit(int amount)
    {
        currentBalance +=Mathf.Abs(amount);
        UpdateDisplay();
    }
    void UpdateDisplay(){
        displayBalance.text = "Gold: " + currentBalance;
    }
    public void Withdraw(int amount)
    {
        currentBalance -=Mathf.Abs(amount);
        UpdateDisplay();

        if(currentBalance <0){
            ReloadScene();
        }
    }

    void ReloadScene(){
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
