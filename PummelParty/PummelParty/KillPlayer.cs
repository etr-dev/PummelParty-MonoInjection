using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PummelParty
{
    class KillPlayer : MonoBehaviour
    {
        BoardPlayer target;

        public KillPlayer(BoardPlayer player)
        {
            target = player;
            damageTarget(30);
        }

        private void damageTarget(int dmgAmount)
        {
            GUI.Label(new Rect(Screen.width / 4, Screen.height / 2, 250f, 100f), "damageTarget has been called"); // Should work and when injected you will see this text in the middle of the screen

            target.ApplyDamage(dmgAmount);
        }

    }
}
