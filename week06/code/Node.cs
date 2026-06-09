public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: only insert if value is unique
        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)  // changed from else to else if — blocks duplicates
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // if value == Data, do nothing (duplicate ignored)
    }

    public bool Contains(int value)
    {
        // Problem 2: recursively search left or right based on value
        if (value == Data)
            return true;
        else if (value < Data)
            return Left is not null && Left.Contains(value);
        else
            return Right is not null && Right.Contains(value);
    }

    public int GetHeight()
    {
        // Problem 4: height = 1 + the taller of left or right subtrees
        int leftHeight  = Left  is null ? 0 : Left.GetHeight();
        int rightHeight = Right is null ? 0 : Right.GetHeight();
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}