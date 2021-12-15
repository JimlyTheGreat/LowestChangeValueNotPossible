using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
	public class Program
	{
		public static void Main(string[] args)
		{

			//int[] array = new int[] { 1, 2, 5, 7, 14, 15, 22 };

			//NonConstructibleChange(array);

			DoubleLinkedList list = new DoubleLinkedList(0);

            //Random random = new Random();

            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(random.Next(1, 100));
            //}

            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(7);
            list.Add(4);
            list.Add(5);
            list.Add(1);
			list.Add(1);
			list.Add(15);
			list.Add(13);
			list.Add(7);
			list.Add(12);
			list.Add(42);

            list.Sort();

			list.DisplayValues();
		}


		public static int NonConstructibleChange(int[] coins)
		{
			if (coins.Length == 0)
			{
				return 1;
			}

			//After finding all of the combinations, check for the lowest positive integer > 0, not included within the list of combinations.
			//Need variations without repetition.

			LinkedList<int> allCombinations = new LinkedList<int>();

			for (int i = 0; i < coins.Length; i++)
			{
				for (int j = 0; j < coins.Length; j++)
				{
					if (j != i)
					{
						allCombinations.AddLast(coins[i] + coins[j]);
					}
				}
			}

			//foreach (int item in allCombinations)
			//{
			//	if (allCombinations.Count + 1 < allCombinations.Count)
			//	{
			//		if (item != allCombinations.)
			//	}
			//}



			return -1;
		}
	}

	public class Node
	{
		public int value;
		public Node parrentNode;
		public Node childNode;

		public Node(int Value)
		{
			value = Value;
		}

	}

	public class DoubleLinkedList
	{
		Node rootNode;
		Node endNode = new Node(0);
		Node currentNode = new Node(0);

		int totalNodes = 1;

		public DoubleLinkedList(int RootValue)
		{
			rootNode = new Node(RootValue);
			currentNode = rootNode;
			endNode = rootNode;
		}

		public void Add(int value)
		{
			Node nodeToAdd = new Node(value);

			endNode.parrentNode = nodeToAdd;
			nodeToAdd.childNode = endNode;
			endNode = nodeToAdd;
			totalNodes++;
		}

		public void DisplayValues()
		{
			currentNode = rootNode;

			for (int i = 0; i < totalNodes; i++)
			{
				if (currentNode != null)
				{
					Console.WriteLine(currentNode.value);
					currentNode = currentNode.parrentNode;
				}
			}

		}


		public int Peek()
		{
			return endNode.value;
		}
		public static Node GetNext(Node node)
		{
			return node.parrentNode;
		}
		public void Sort()
		{
			SwapNodes(endNode);
		}


		//0 1 2 3 7 4 5 1
		public void InsertAtIndex(int value, int index)
        {
			currentNode = rootNode;

			for(int i = 0; i < index; i++)
            {
				currentNode = currentNode.parrentNode;
            }

			Node nodeToInsert = new Node(value);

			nodeToInsert.childNode = currentNode;
			nodeToInsert.parrentNode = currentNode.parrentNode;

			currentNode.childNode.value = nodeToInsert.value;
			currentNode = nodeToInsert;

            Console.WriteLine(currentNode.value);

        }


		public void SortDecending()
        {
			int lowestValue = 0;
			currentNode = rootNode;

			int lowestPositionIndex = 0;

			if(currentNode.value < lowestValue)
            {
				if (currentNode.value < lowestValue)
				{
					lowestValue = currentNode.value;
				}
				currentNode = currentNode.parrentNode;
			}

        }
		


		public void SwapNodes(Node nodeToSwap)
		{
			currentNode = nodeToSwap;
			while (currentNode != null && currentNode.childNode != null)
			{
				//Swaps the node values if the next node has a greater value
				if (currentNode.value < currentNode.childNode.value)
				{

					//VERY IMPORTANT: You have to redefine all of these values and create a new node.
					//Otherwise this will not work, the way C# handles setting things equal will break this if you don't create an entirely new node and it creates an infinite loop.

					//Node tempCurrent = new Node(currentNode.value);
					//tempCurrent.parrentNode = currentNode.parrentNode;
					//tempCurrent.childNode = currentNode.childNode;

					//Node tempChild = new Node(currentNode.childNode.value);
					//tempChild.parrentNode = currentNode.childNode.parrentNode;
					//tempChild.childNode = currentNode.childNode.childNode;

					//currentNode.childNode = tempCurrent;
					//currentNode.parrentNode = tempChild;

					//Try values only.

					int temp = currentNode.childNode.value;

					currentNode.childNode.value = currentNode.value;

					currentNode.value = temp;

					currentNode = currentNode.childNode;

					SwapNodes(currentNode);
				}
				else
				{
					while(currentNode.parrentNode != null)
					{
						if (currentNode.parrentNode.value > currentNode.value)
						{
							currentNode = currentNode.parrentNode;
						}
                        else
                        {
							currentNode = currentNode.parrentNode;
							SwapNodes(currentNode);
                        }
					}
					break;
				}
			}
		}

		//This is fucking things up.
		public void SetEndNode()
		{
			currentNode = rootNode;
			while (currentNode.parrentNode != null)
			{
				currentNode = currentNode.parrentNode;
			}

			rootNode = currentNode;
		}
	}
}