/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (FIFO). When GetNextPerson is called, the next person in the queue 
/// is returned and then placed back into the back of the queue unless they have run 
/// out of turns. A turns value of 0 or less means the person has infinite turns. 
/// If the queue is empty, an InvalidOperationException is thrown.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a new person to the queue.
    /// </summary>
    /// <param name="name">Person's name.</param>
    /// <param name="turns">Number of turns. 0 or less means infinite turns.</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Returns the next person in the queue and cycles them to the back,
    /// unless they have run out of turns. If turns are infinite, they always
    /// return to the back. Throws an exception if queue is empty.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // People with infinite turns (<= 0) always go back to the queue.
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // People with finite turns (1 or more) lose one turn and only rejoin if turns remain.
        else
        {
            person.Turns -= 1;
            if (person.Turns > 0)
            {
                _people.Enqueue(person);
            }
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
