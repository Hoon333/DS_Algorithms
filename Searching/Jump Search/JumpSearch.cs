// C# program to implement Jump Search. 

/*Time Complexity : O(√n)
Auxiliary Space : O(1)
*/


/*Important Points
- Works only sorted arrays.
- The optimal size of a block to be jumped is (√ n). This makes the time complexity of Jump Search O(√ n).
- The time complexity of Jump Search is between Linear Search ( ( O(n) ) and Binary Search ( O (Log n) ).
- Binary Search is better than Jump Search, but Jump search has an advantage that we traverse back only once 
  (Binary Search may require up to O(Log n) jumps, consider a situation where the element to be searched is 
  the smallest element or smaller than the smallest). So in a system where binary search is costly, we use Jump Search.
*/

using System; 
public class JumpSearch 
{ 
	public static int jumpSearch(int[] arr, int x) 
	{ 
		int n = arr.Length; 

		// Finding block size to be jumped 
		int step = (int)Math.Floor(Math.Sqrt(n)); 

		// Finding the block where element is 
		// present (if it is present) 
		int prev = 0; 
		while (arr[Math.Min(step, n)-1] < x) 
		{ 
			prev = step; 
			step += (int)Math.Floor(Math.Sqrt(n)); 
			if (prev >= n) 
				return -1; 
		} 

		// Doing a linear search for x in block 
		// beginning with prev. 
		while (arr[prev] < x) 
		{ 
			prev++; 

			// If we reached next block or end of 
			// array, element is not present. 
			if (prev == Math.Min(step, n)) 
				return -1; 
		} 

		// If element is found 
		if (arr[prev] == x) 
			return prev; 

		return -1; 
	} 

	// Driver program to test function 
	public static void Main() 
	{ 
		int[] arr = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 
					34, 55, 89, 144, 233, 377, 610}; 
		int x = 55; 

		// Find the index of 'x' using Jump Search 
		int index = jumpSearch(arr, x); 

		// Print the index where 'x' is located 
		Console.Write("Number " + x + 
							" is at index " + index); 
	} 
} 
