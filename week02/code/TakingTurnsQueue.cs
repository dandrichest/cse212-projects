/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Adds a person to the back of the queue. If turns <= 0, they are treated as infinite-turn players.
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Returns the next person from the queue, then requeues them based on turn rules.
    /// - If turns == 1, person is returned and removed.
    /// - If turns > 1, person is returned and requeued with one fewer turn.
    /// - If turns <= 0, person is infinite and requeued unchanged.
    /// Throws an exception if the queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns — don't modify, just requeue
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Finite turns — decrement and requeue
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // else: Turns == 1 — do not requeue

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
