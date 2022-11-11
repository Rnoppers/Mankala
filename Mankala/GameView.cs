using System;
using System.Collections.Generic;
using System.Text;

namespace Mankala
{
    class GameView : GameObserver
    {
        private Game gameState;

        public void Update(Game subject)
        {
            this.gameState = subject;
            gameState = subject;

            // call methods to draw the new state of the playingfield
            Console.WriteLine(DrawBoard());
        }



        private string DrawBoard()
        {
            PlayingBoard board = gameState.thePlayBoard;
            Pit[] pits = board.pits;


            int pitLength = LargestPit(pits);
            string outputBoard = "";


            int index = 0;


            foreach (Pit pit in pits)
            {
                outputBoard = outputBoard + DrawPit(pit, pitLength, index) + " ";
                index++;
            }

            return (outputBoard.Replace("@", Environment.NewLine));
            
        }

        private string DrawPit(Pit pit, int length, int index)
        {
            int pitContent = pit.stones.Count;
            string output = IndentPitContent(length, pitContent.ToString());

            //list of characters used to indicate the options during play

            string indexPrefix = index + ": ";


            if (pit is CollectingPit)
            {
                // if the pit is a Collectingpit, start a new line (@ represents newline).
                return ("@" + indexPrefix + "{" + output + "}");
            }
            return (indexPrefix + "[" + output + "]");
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
