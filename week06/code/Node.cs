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
        // TODO Start Problem 1
        if (value == Data)
        {
            // Value already exists, do nothing
            return; // ignore duplicates
        }
        if (value < Data)
        {
            if (Left is null)
            {
                Left = new Node(value);
            }
            else
            {
                Left.Insert(value);
            }
        }
        else
        {
            if (Right is null)
            {
                Right = new Node(value);
            }
            else
            {
                Right.Insert(value);
            }
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true; // Found the value
        }
        else if (value < Data)
        {
            return Left?.Contains(value) ?? false; // Search in the left subtree
        }
        else
        {
            return Right?.Contains(value) ?? false; // Search in the right subtree
        }

    }

    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left?.GetHeight() ?? 0; // Height of left subtree
        int rightHeight = Right?.GetHeight() ?? 0; // Height of right subtree

        return 1 + Math.Max(leftHeight, rightHeight); // Height of the current node
       
    }
}