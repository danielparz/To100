using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace To100
{
    class Node
    {
        public int Operation { get; set; }
        public int CurrentValue { get; set; }
        public Node PrevNode { get; set; }
        public List<Node> NextNodes { get; set; }
        public bool IsWantedValue { get; set; }
        public int NodeLvl { get; set; }

        public Node(int nodeLvl, int operation, int wantedNumber, Node prev = null)
        {
            Operation = operation;
            PrevNode = prev;
            CurrentValue = (prev != null) ? (prev.CurrentValue + operation) : 0;
            IsWantedValue = (CurrentValue == wantedNumber);
            NodeLvl = nodeLvl;
            NextNodes = new List<Node>();
        }

        public override string ToString()
        {
            if (Operation > 0)
                if (NodeLvl <= 1) return $"{ Operation }";
                else return $" + { Operation}";
            else if (Operation < 0) return $" - { -1 * Operation }";
            return Operation.ToString();
        }
    }
}
