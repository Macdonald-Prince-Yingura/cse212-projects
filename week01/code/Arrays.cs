using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with
    /// 'number' followed by multiples of 'number'.
    /// Example:
    /// MultiplesOf(7, 5) returns {7, 14, 21, 28, 35}
    /// </summary>
    /// <returns>
    /// Array of doubles that are the multiples of the supplied number
    /// </returns>
    public static double[] MultiplesOf(double startingNumber, int count)
    {
        // PLAN:
        // 1. Create an array with the required size.
        // 2. Use a loop to go through each index.
        // 3. Multiply the starting number by (index + 1).
        // 4. Store the result in the array.
        // 5. Return the completed array.

        // Create the array
        double[] result = new double[count];

        // Fill the array with multiples
        for (int i = 0; i < count; i++)
        {
            result[i] = startingNumber * (i + 1);
        }

        // Return the completed array
        return result;
    }

    /// <summary>
    /// Rotates a list to the right by the specified amount.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Find the position where the list should split.
        // 2. Store the last 'amount' values.
        // 3. Store the beginning values.
        // 4. Clear the original list.
        // 5. Add the last part first.
        // 6. Add the beginning part after it.

        // Find split position
        int splitIndex = data.Count - amount;

        // Get the last part of the list
        List<int> lastPart = data.GetRange(splitIndex, amount);

        // Get the first part of the list
        List<int> firstPart = data.GetRange(0, splitIndex);

        // Clear the original list
        data.Clear();

        // Add the rotated parts back
        data.AddRange(lastPart);
        data.AddRange(firstPart);
    }
}