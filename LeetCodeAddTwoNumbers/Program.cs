using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace LeetCodeAddTwoNumbers
{
    class Program
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            public Solution()
            {
                var node1 = new ListNode(2,  
                    new ListNode(4, 
                        new ListNode(3)));
                var node2 = new ListNode(5,
                    new ListNode(6,
                        new ListNode(4)));

                var x = AddTwoNumbers(node1, node2);


            }


            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                var number1 = GetNumberFromLinkedList(l1);
                var number2 = GetNumberFromLinkedList(l2);

                var result = number1 + number2;

                var asLinkedList = ConvertNumberToReverseLinkedList(result);
                return asLinkedList;
            }



            private BigInteger GetNumberFromLinkedList(ListNode l1)
            {
                var currentNode = l1;
                var builtNumber = new StringBuilder();

                while (currentNode != null)
                {
                    builtNumber.Append(currentNode.val);
                    currentNode = currentNode.next;
                }

                var realNumber = new StringBuilder();
                for (int i = builtNumber.Length - 1; i > -1; i--)
                    realNumber.Append(builtNumber[i]);

                return BigInteger.Parse(realNumber.ToString());
            }


            private ListNode ConvertNumberToReverseLinkedList(BigInteger toBeConverted)
            {
                var asString = toBeConverted.ToString();

                ListNode first = null;
                ListNode current = null;

                for (int i = asString.Length - 1; i > -1; i--)
                {
                    // convert ASCII to number
                    var val = Convert.ToInt32(asString[i] - 48);

                    var listNode = new ListNode(val);
                    if (first == null)
                        first = listNode;
                    if (current != null)
                        current.next = listNode;
                    current = listNode;
                }

                return first;
            }
        }





        static void Main(string[] args)
        {
            var x = new Solution();
        }
    }
}
