using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PummelParty
{
    class PlayerList : MonoBehaviour
    {

        BoardPlayer me = new BoardPlayer(); //Our player instance.
        List<BoardPlayer> players = new List<BoardPlayer>(); //List of players.
        Boolean[] buttons = null;


        public PlayerList()
        {
            getPlayers();
        }
        public void getPlayers() //Loads all players and gets our player instance.
        {
            players.Clear();
            players.AddRange(FindObjectsOfType<BoardPlayer>());
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].GamePlayer.Name == "Rape")//change this to text box entry later
                {
                    me = players[i];
                }
            }
            return;
        }

        bool toggleOptions = false;
        int playerNumber;
        public void playerButtons(int xPos, int yPos, float buttonWidth, float buttonHeight, float spacing, bool showButton)//(0,0) is top left, (Screen.width,Screen.width) is bottom right
        {

            if (showButton)
            {
                for (int k = 0; k < players.Count; k++)
                {
                    if (GUI.Button(new Rect(xPos - (int)buttonWidth, yPos + (k * (int)buttonHeight) + spacing, buttonWidth, buttonHeight), players[k].GamePlayer.Name))//LIST OF PLAYERS if you click one then it show options such as: kill, givekeys,take keys 
                    {
                        toggleOptions = !toggleOptions;
                        playerNumber = k;

                    }
                        //Every button in this if statement is shown on the 3rd column so:
                        //3rd Col             |2nd Col           |1st Col
                        //xPos - 2*buttonWidth|xPos - buttonWidth|xPos

                        //kill                |Player1           |ListPlayers
                        //give                |Player2           |EndTurn1
                        //take                |                  |
                }


                if (toggleOptions)
                {


                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + spacing, buttonWidth, buttonHeight), "Kill Player"))//kill player
                    {
                        buttonClickAction(players[playerNumber], "kill");
                    }
                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + buttonHeight + spacing, buttonWidth, buttonHeight), "Give a Key"))//give 1 key
                    {
                        buttonClickAction(players[playerNumber], "give");
                    }
                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + 2 * buttonHeight + spacing, buttonWidth, buttonHeight), "Remove a Key"))//take 1 key
                    {
                        buttonClickAction(players[playerNumber], "take");
                    }
                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + 3 * buttonHeight + spacing, buttonWidth, buttonHeight), "Give Trophy"))//take 1 key
                    {
                        buttonClickAction(players[playerNumber], "giveTrophy");
                    }
                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + 4 * buttonHeight + spacing, buttonWidth, buttonHeight), "Remove Trophy"))//take 1 key
                    {
                        buttonClickAction(players[playerNumber], "takeTrophy");
                    }
                    if (GUI.Button(new Rect(xPos - 2 * (int)buttonWidth, yPos + (playerNumber * (int)buttonHeight) + 5 * buttonHeight + spacing, buttonWidth, buttonHeight), "Roll a 1"))//take 1 key
                    {
                        buttonClickAction(players[playerNumber], "rollNumber");
                    }

                }
            }
        }


        private void buttonClickAction(BoardPlayer player, String choice)
        {
                switch(choice){
                    case "kill": new KillPlayer(player); //on button click kill that player
                        break;
                    case "give": new ManipulateKeys(player, 1); //give 1 key to player
                        break;
                    case "take": new ManipulateKeys(player, -1); //remove 1 key from a player
                        break;
                    case "giveTrophy": new ManipulateKeys(player, "give"); //give 1 key to player
                        break;
                    case "takeTrophy": new ManipulateKeys(player, "take"); //remove 1 key from a player
                        break;
                    case "rollNumber": new RollNumber(player, 1); //roll a specific number on dice
                        break;


            }
        }


    }
}
