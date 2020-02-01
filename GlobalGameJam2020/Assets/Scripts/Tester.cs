using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public BotDeath botDeathTest;
    public bool killBot = false;
    bool tested;

    private void Update()
    {
        if (killBot && !tested)
        {
            Test();
        }

        if (!killBot)
        {
            tested = false;
        }
    }

    void Test()
    {
        botDeathTest.DeathSequence();
        tested = true;
    }
}
