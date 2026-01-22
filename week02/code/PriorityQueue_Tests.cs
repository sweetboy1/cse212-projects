using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add several items with different priorities.
    // Expected Result: The item with the highest priority (largest number) should be removed first.
    // Defect(s) Found: Code originally didn’t remove the highest-priority correctly and didn’t remove it from the list.
    public void TestPriorityQueue_HighestPriorityFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 5);
        pq.Enqueue("High", 10);

        // Highest priority (10) should be dequeued first
        Assert.AreEqual("High", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Add several items with the same priority.
    // Expected Result: Items with the same priority are dequeued in FIFO order (first in, first out).
    // Defect(s) Found: Used >= instead of > in comparison, so it broke FIFO ordering for ties.
    public void TestPriorityQueue_TiePriorityFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("First", 5);
        pq.Enqueue("Second", 5);
        pq.Enqueue("Third", 5);

        Assert.AreEqual("First", pq.Dequeue());
        Assert.AreEqual("Second", pq.Dequeue());
        Assert.AreEqual("Third", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue when queue is empty.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: None after fix.
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var pq = new PriorityQueue();

        try
        {
            pq.Dequeue();
            Assert.Fail("Expected exception not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Ensure items are actually removed from the queue after dequeuing.
    // Expected Result: Each Dequeue call returns next highest-priority remaining item.
    // Defect(s) Found: Code did not remove the dequeued item from _queue.
    public void TestPriorityQueue_RemoveAfterDequeue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("High", 10);
        pq.Enqueue("Medium", 5);

        // 1st dequeue: "High"
        Assert.AreEqual("High", pq.Dequeue());
        // 2nd dequeue: "Medium"
        Assert.AreEqual("Medium", pq.Dequeue());
        // 3rd dequeue: "Low"
        Assert.AreEqual("Low", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Intermix enqueue and dequeue operations.
    // Expected Result: Priority logic remains consistent.
    // Defect(s) Found: Loop bounds and comparison caused later elements to be skipped.
    public void TestPriorityQueue_MixedOperations()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("TaskA", 2);
        pq.Enqueue("TaskB", 5);

        Assert.AreEqual("TaskB", pq.Dequeue()); // first removal

        pq.Enqueue("TaskC", 10);
        pq.Enqueue("TaskD", 1);

        Assert.AreEqual("TaskC", pq.Dequeue()); // highest new item
        Assert.AreEqual("TaskA", pq.Dequeue()); // next highest
        Assert.AreEqual("TaskD", pq.Dequeue()); // last remaining
    }
}
