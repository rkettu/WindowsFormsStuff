using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Player
    {
        string name = "";
        int score = 0;
        public void saveInfo(string playerName, int result)
        {
            name = playerName;
            score = result;
        }

        public string getName()
        {
            return name;
        }

        public int getScore()
        {
            return score;
        }
    }

}
