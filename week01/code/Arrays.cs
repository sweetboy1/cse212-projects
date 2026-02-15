public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    // Plan:
    // 1. Create an array of length 'count' to hold results.
    // 2. Loop i from 0 to count-1.
    // 3. For each i, set result[i] = number * (i + 1).
    // 4. Return the result array.

    public static double[] MultiplesOf(double number, int count)
    {
        // Step 1: create array
        double[] multiples = new double[count];

        // Step 2 & 3: fill array
        for (int i = 0; i < count; i++)
        {
            multiples[i] = number * (i + 1);
        }

        // Step 4: return
        return multiples;
    }


    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    // Plan:
    // 1. Use GetRange to get the last 'amount' elements.
    // 2. Use GetRange to get the first (data.Count - amount) elements.
    // 3. Clear the original list.
    // 4. Add the last part first then add the first part (so list is rotated right).
    // Note: amount is between 1 and data.Count (inclusive).

    public static void RotateListRight<T>(List<T> data, int amount)
    {
        // Safety: optional but good to handle trivial cases
        if (data == null || data.Count <= 1 || amount % data.Count == 0)
            return;

        // Normalize amount in case it's equal to data.Count
        amount = amount % data.Count;

        // Get the last 'amount' elements
        var lastPart = data.GetRange(data.Count - amount, amount);

        // Get the first part
        var firstPart = data.GetRange(0, data.Count - amount);

        // Clear original list and add rotated sequence
        data.Clear();
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }

}
