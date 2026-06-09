public static class Trees
{
    /// <summary>
    /// Given a sorted list, create a balanced BST by always inserting
    /// the middle element first, then recursing on each half.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Finds the middle index between first and last, inserts that value
    /// into the BST, then recurses on the left half and right half.
    /// No sublists are created — only indices are passed.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Problem 5: base case — nothing left to insert
        if (first > last)
            return;

        // Find and insert the middle element
        int mid = (first + last) / 2;
        bst.Insert(sortedNumbers[mid]);

        // Recurse on left half (elements before mid)
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recurse on right half (elements after mid)
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}