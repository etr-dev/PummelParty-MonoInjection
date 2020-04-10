using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PummelParty
{
    class RollNumber
    {
        BoardPlayer target;

        public RollNumber(BoardPlayer player, int numberToRoll)
        {
            target = player;
            forceRoll(numberToRoll);
        }

        private void forceRoll(int num)
        {
            target.HitDice(num);
            target.Move(num);
        }
    }
}
