using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runemark.DialogueSystem
{
    public class PlayerPower : MonoBehaviour
    {

        public int power;
        public int EnemyPower1;
        public int WinChance;


        public void WinChance1()
        {
            var chance = power / (power - EnemyPower1)*10;
            WinChance = chance;
        }

        public void Combat()
        {
            if (power <= 10)
            {
                var combat = Random.Range(1, power);

                power = combat;
            }
        }

        public void Update()
        {
            DialogueSystem.SetGlobalVariable("PlayerPower", power);
            DialogueSystem.SetGlobalVariable("WinChance", WinChance);
        }
    }
}

