using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PummelParty
{
    class ManipulateKeys
    {

        BoardPlayer target;
        public ManipulateKeys(BoardPlayer player, int keys) //Give or take keys
        {
            target = player;
            if(keys > 0) //if positive, then give keys to player
            {
                //give keys to player
                giveKeys(keys);
            }
            else
            {
                //take keys from player
                takeKeys(Math.Abs(keys));
            }
        }

        public ManipulateKeys(BoardPlayer player, String choice) //Manipulate trophies
        {
            target = player;
            if (choice == "give") //if positive, then give keys to player
            {
                //give keys to player
                giveTrophy();
            }
            else
            {
                //take keys from player
                takeTrophy();
            }
        }

        private void giveKeys(int keys)
        {
            target.GiveGold(keys, true);
        }

        private void takeKeys(int keys)
        {
            target.RemoveGold(keys, false, false);
        }

        private void giveTrophy()
        {
            //target.GiveTrophy()
        }

        private void takeTrophy()
        {
            target.RemoveTrophy();
        }

    }
}
