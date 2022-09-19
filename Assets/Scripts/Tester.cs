using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    private void Start()
    {
        Game.Run();
    }

    void Update()
    {
        if(!Bank.isInitialize)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Bank.AddCoins(this,5);
            Debug.Log($"Added 5 coins, coins left {Bank.Coins}");
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            Bank.SpendCoins(this, 10);
            Debug.Log($"Spent 10 coins, coins left {Bank.Coins}");
        }
    }

}
