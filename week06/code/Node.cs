public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    /// <summary>
    /// Problem 1: Insert Unique Values Only
    /// Update the Insert function to only allow unique values to be added to the tree.
    /// </summary>
    public void Insert(int value)
    {
        // Problem 1 Solution: Prevent duplicates by using "else if (value > Data)" instead of just "else"
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)  // Changed from "else" to prevent duplicates
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        // If value == Data, do nothing (skip duplicates)
    }

    /// <summary>
    /// Problem 2: Contains
    /// Implement the Contains function to search for a value in the tree.
    /// </summary>
    public bool Contains(int value)
    {
        // Base case: found the value
        if (value == Data)
            return true;
        
        // If value is less than current node's data, search left subtree
        if (value < Data)
        {
            // If left subtree is null, value doesn't exist
            if (Left is null)
                return false;
            // Recursively search left subtree
            return Left.Contains(value);
        }
        else // value > Data
        {
            // If right subtree is null, value doesn't exist
            if (Right is null)
                return false;
            // Recursively search right subtree
            return Right.Contains(value);
        }
    }

    /// <summary>
    /// Problem 4: Tree Height
    /// Implement the GetHeight function to get the height of the tree.
    /// The height of any tree (or subtree) is defined as one plus the height 
    /// of either the left subtree or the right subtree (whichever one is bigger).
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = 0;
        int rightHeight = 0;
        
        // Get height of left subtree (if it exists)
        if (Left is not null)
            leftHeight = Left.GetHeight();
        
        // Get height of right subtree (if it exists)
        if (Right is not null)
            rightHeight = Right.GetHeight();
        
        // Height = 1 (current node) + max of left/right subtree heights
        return 1 + Math.Max(leftHeight, rightHeight);
    }
    
    /// <summary>
    /// Helper method for Problem 3 (Traverse Backwards)
    /// This needs to be added to the Node class for the traversal to work.
    /// </summary>
    public IEnumerable<int> TraverseBackwards()
    {
        // First traverse right subtree (larger values)
        if (Right is not null)
        {
            foreach (var value in Right.TraverseBackwards())
            {
                yield return value;
            }
        }
        
        // Then yield current node
        yield return Data;
        
        // Finally traverse left subtree (smaller values)
        if (Left is not null)
        {
            foreach (var value in Left.TraverseBackwards())
            {
                yield return value;
            }
        }
    }
}
