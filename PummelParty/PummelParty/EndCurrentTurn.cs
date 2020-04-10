using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PummelParty
{
    class EndCurrentTurn : MonoBehaviour
    {

        GameBoardController control;
        public EndCurrentTurn()
        {
            control = FindObjectsOfType<GameBoardController>()[0];
            endTheTurn();
        }

        private void endTheTurn()
        {
            control.CurPlayer.EndTurn();
            control.EndTurn();
            control.CurPlayer.StartTurn();
        }

    }
}

