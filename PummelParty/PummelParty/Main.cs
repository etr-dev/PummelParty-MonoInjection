using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace PummelParty
{
    class Main : MonoBehaviour
    {
        public void Start()
        {
        }
        SpookySpikes ss = new SpookySpikes();
        PlayerList pl = new PlayerList();
        String yourName = "";
        public void Update()
        {

            ss.SpookySpikesCheat(yourName);

            //temp
            pl.getPlayers();
            
        }

        bool togglePlayers = false;
        public void OnGUI()
        {
            GUI.Label(new Rect(0, 50, 150f, 50f), "GAME INJECTED");//Injection label to show when the DLL has been injected successfully

            yourName = GUI.TextField(new Rect(Screen.width - 100, Screen.height / 2 - 20, 100, 20), yourName, 25);//Textbox for user to input their character's name

            if (GUI.Button(new Rect(Screen.width - (int)100f, Screen.height / 2, 100f, 50f), "Show Players"))//A button that toggles the list of Boardgame Players on and off
                togglePlayers = !togglePlayers;
            if(togglePlayers)
                pl.playerButtons(Screen.width-100, Screen.height / 2, 100f, 50f, 0f, true); //A list of BoardGame Players with unique buttons

            if (GUI.Button(new Rect(Screen.width - (int)100f, Screen.height / 2 + 50, 100f, 50f), "End Turn"))
                new EndCurrentTurn();
        }
    }
}