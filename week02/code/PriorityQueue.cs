public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value with a priority to the back of the queue.
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        _queue.Add(new PriorityItem(value, priority));
    }

    /// <summary>
    /// Remove and return the value with the highest priority (lowest int).
    /// If multiple items share the highest priority, return the one closest to the front.
    /// </summary>
    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index with the minimum priority
        int highPriorityIndex = 0;
        int highestPriority = _queue[0].Priority;

        for (int i = 1; i < _queue.Count; i++)
        {
            if (_queue[i].Priority < highestPriority)
            {
                highestPriority = _queue[i].Priority;
                highPriorityIndex = i;
            }
        }

        var item = _queue[highPriorityIndex];
        _queue.RemoveAt(highPriorityIndex);
        return item.Value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
public class PriorityItem
{
    public string Value { get; }
    public int Priority { get; }

    public PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Priority: {Priority})";
    }
}