/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private Queue<Person> _queue = new();

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Enqueue(person);
    }

    public Person Dequeue()
    {
        return _queue.Dequeue();
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }
    public int Length => _queue.Count;

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}