using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameView : Observer
    {
        private Game gameState;

        public void Update(Subject subject)
        {
            // call methods to draw the new state of the playingfield
            
            //this.gameState = subject;
        }



        private void DrawBoard()
        {
            PlayingBoard board = gameState.thePlayBoard;
            Pit[] pits = board.pits;

            int pitLength = LargestPit(pits);

            string collectingPit = "{";
            string outputBoard;

            outputBoard =
                " @" +
                " @" +
                " @" +
                " @" +
                " @";


            outputBoard = outputBoard.Replace("@", System.Environment.NewLine);
            
        }

        private string IndentPitContent(int length, string text)
        {
            int indentAmount = length - text.Length;
            string leftIndent = RepeatString(" ", "", indentAmount/2);
            // length based on leftIndent-length, due to rounding down of the division-operator on ints.
            string rightIndent = RepeatString(" ", "", indentAmount - indentAmount/2);

            //the target-text is put inbetween the indents, so it can be put in the middle.
            return (leftIndent + text + rightIndent);
        }

        private string RepeatString(string target, string intersperseWith, int times)
        {
            string output = "";
            for (int i = 0; i < times; i++)
            {
                output += target + intersperseWith;
            }

            return output;
        }

        private int LargestPit(Pit[] pits)
        {
            int max = 0;

            foreach (Pit pit in pits)
            {
                int noOfStones = pit.stones.Count;
                if (noOfStones > max)
                {
                    max = noOfStones; 
                }
            }
            return max;
        }
    }



}
