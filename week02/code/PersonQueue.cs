/// <summary>
/// A basic implementation of a FIFO queue for Person objects.
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Adds a person to the back of the queue (FIFO).
    /// </summary>
    public void Enqueue(Person person)
    {
        _queue.Add(person);  // Add to the end of the list
    }

    /// <summary>
    /// Removes and returns the person at the front of the queue.
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The queue is empty.");

        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty() => Length == 0;

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
