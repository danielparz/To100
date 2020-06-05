using System;
using System.Collections.Generic;
using System.Text;

namespace To100
{
    class Solver
    {
        public List<Node> CorrectCombinations { get; set; }
        public Node Root;
        public int NumbersAmount { get; set; }
        public int WantedNumber { get; set; }

        public Solver(int numbersAmount, int wantedNumber)
        {
            NumbersAmount = numbersAmount;
            WantedNumber = wantedNumber;
            CorrectCombinations = new List<Node>();
            Root = new Node(0, 0, wantedNumber);
        }

        public void GenerateVariantsTree(Node node, int num = 1)
        {
            if (num >= NumbersAmount) return;
            int val = num;
            Node newNode;

            if (num > 0)
            {
                for (int i = num; i <= num + (WantedNumber.ToString().Length / 2) + 1; i++)
                {
                    if (i > NumbersAmount) break;

                    if (i != num) val = ConcatNums(val, i);

                    //Warianty dodatnie
                    newNode = new Node(i, val, WantedNumber, node);
                    if (newNode.IsWantedValue) CorrectCombinations.Add(newNode);
                    node.NextNodes.Add(newNode);
                    GenerateVariantsTree(newNode, i);

                    //Warianty ujemne
                    newNode = new Node(i, -val, WantedNumber, node);
                    if (newNode.IsWantedValue) CorrectCombinations.Add(newNode);
                    node.NextNodes.Add(newNode);
                    GenerateVariantsTree(newNode, i);
                }
            }
            else if(num < 0)
            {
                for (int i = -num; (i <= -num + (WantedNumber.ToString().Length / 2) + 1) && (i <= NumbersAmount); i++)
                {
                    if (i != -num) val = -ConcatNums(-val, i);

                    //Warianty dodatnie
                    newNode = new Node(i, val, WantedNumber, node);
                    if (newNode.IsWantedValue) CorrectCombinations.Add(newNode);
                    node.NextNodes.Add(newNode);
                    GenerateVariantsTree(newNode, i);

                    //Warianty ujemne
                    newNode = new Node(i, -val, WantedNumber, node);
                    if (newNode.IsWantedValue) CorrectCombinations.Add(newNode);
                    node.NextNodes.Add(newNode);
                    GenerateVariantsTree(newNode, i);
                }
            }
        }

        private int ConcatNums(int val1, int val2)
        {
            return int.Parse(val1.ToString() + val2.ToString());
        }

        public void ShowAnswer()
        {
            int counter = 1;
            foreach(var node in CorrectCombinations)
            {
                List<Node> variantList = new List<Node>();
                var tempNode = node;

                while (tempNode.PrevNode != null)
                {
                    variantList.Add(node);
                    tempNode = tempNode.PrevNode;
                }

                variantList.Reverse();
                Console.Write($"{counter}) ");
                foreach(var n in variantList)
                {
                    Console.Write($"{n}");
                }
                Console.Write("\n");
                counter++;
            }
        }
    }
}
