public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create a new array with 'length' size to hold the multiples.
        double[] result = new double[length];

        // Step 2: Loop through the array using an index.
        // For each index i, calculate number * (i+1) to get the i multiple.
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); // Store multiple at index i
        }

        // Step 3: Return the filled array.
            return result;

    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Identify the slice to move from end to front.
        // We need the last 'amount' elements: start index = data.Count - amount
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Step 2: Remove those last 'amount' elements from the list.
        data.RemoveRange(data.Count - amount, amount);

        // Step 3: Insert that 'tail' at the beginning of the list.
        data.InsertRange(0, tail);

        // Note: This modifies the original list in-place as required.

    }
}
