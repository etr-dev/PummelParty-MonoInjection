using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Windows.Input;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;

namespace PummelParty
{
    public class SpookySpikes : MonoBehaviour
    {
        String yourName = "";
        SpookySpikesPlayer me = new SpookySpikesPlayer(); //Our player instance.
        List<GameObject> spikes = new List<GameObject>(); //List of spike objects.
        List<SpookySpikesPlayer> players = new List<SpookySpikesPlayer>(); //List of players.
        
        public void SpookySpikesCheat(String name)
        {
            yourName = name;
            getPlayers(); //Load all game players and grab self.
            if (players.Count() > 0 && me != null)
            {
                getSpikes(); //Load all spike Objects into the list.
                GameObject spike = shouldAct(); //Check if spike is in distance.
                if (spike == null) //If no spikes are in distance, do nothing.
                    return;
                int curState = (int)typeof(SpookySpikesPlayer).GetField("curState", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(me); //Get private field for movement state.
                if (curState == 0) //Check player is not currently crouching or jumping.
                {
                    if (spike.transform.parent.position.y > 0.75f) //Check whether we should Crouch or Jump.
                    {
                        me.StartCoroutine("Crouch"); //make our player crouch.
                    }
                    else
                    {
                        me.StartCoroutine("Jump"); //make our player jump.
                    }
                }
            }
        }

        GameObject shouldAct() //Returns a spike gameobject if within range, else return null.
        {
            for (int i = 0; i < spikes.Count; i++)
            {
                float distance = (spikes[i].transform.position.x - me.transform.position.x); //Get spikes distance from our player
                if (distance > -3 && distance < 0)
                {
                    return spikes[i];
                }
            }
            return null;
        }

        void getPlayers() //Loads all players and gets our player instance.
        {
            players.Clear();
            players.AddRange(FindObjectsOfType<SpookySpikesPlayer>());
            for (int i = 0; i < players.Count(); i++)
            {
                if (players[i].GamePlayer.Name == yourName)
                {
                    me = players[i];
                }
            }
            return;
        }

        void getSpikes() //Loads all spike gameobjects.
        {
            spikes.Clear();
            foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
            {
                if (gameObj.name == "HitCollider")
                {
                    spikes.Add(gameObj);
                }
            }
            return;
        }
    }
}