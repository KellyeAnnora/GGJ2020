using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runemark.DialogueSystem
{
    public class PlayerPower : MonoBehaviour
    {

        public int playerPower;
        public int combatPower;


        public void Combat()
        {
            if (playerPower <= 10)
            {
                var combat = Random.Range(1, playerPower);

                combatPower = combat;
            }
        }

        public void Update()
        {
            DialogueSystem.SetGlobalVariable("PlayerPower", combatPower);
            //DialogueSystem.SetGlobalVariable("WinChance", WinChance);
        }
    }
}

