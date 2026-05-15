using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with distinct priorities: ("low", 1), ("high", 10), ("mid", 5).
    //           Dequeue all three.
    // Expected Result: "high", "mid", "low"  (strict priority order)
    // Defect(s) Found: 1) Loop used "Count - 1" so the last-added item ("mid" at index 2) was
    //                     never examined, causing wrong winner selection.
    //                  2) RemoveAt was never called so the item was never removed from the list,
    //                     meaning every subsequent Dequeue returned the same wrong value.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);
        priorityQueue.Enqueue("mid", 5);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("mid", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue three items where two share the highest priority:
    //           ("first", 5), ("second", 5), ("third", 1).
    //           Dequeue all three.
    // Expected Result: "first", "second", "third"  (FIFO ordering for tied priorities)
    // Defect(s) Found: Loop used ">=" which updated highPriorityIndex whenever a later item
    //                  matched the current best, causing "second" to incorrectly beat "first"
    //                  even though "first" arrived earlier. Changed to strict ">" to keep the
    //                  first (earliest) occurrence when priorities tie.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);
        priorityQueue.Enqueue("third", 1);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
        Assert.AreEqual("third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from an empty queue.
    // Expected Result: InvalidOperationException thrown with message "The queue is empty."
    // Defect(s) Found: None — this path was already correct in the original code.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception of type {e.GetType()} caught: {e.Message}");
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item and dequeue it; then verify the queue is empty.
    // Expected Result: The single item's value is returned; a subsequent Dequeue throws.
    // Defect(s) Found: RemoveAt was missing, so after dequeuing the only item the queue
    //                  still had Count == 1 and the second Dequeue would return the same
    //                  value instead of throwing.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("only", 7);

        Assert.AreEqual("only", priorityQueue.Dequeue());

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: All items have the same priority: ("a", 3), ("b", 3), ("c", 3).
    //           Dequeue all three.
    // Expected Result: "a", "b", "c"  (pure FIFO since all priorities are equal)
    // Defect(s) Found: Same ">=" tie-breaking defect as Test 2; last-inserted item would
    //                  always win, reversing the expected FIFO order.
    public void TestPriorityQueue_5()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("a", 3);
        priorityQueue.Enqueue("b", 3);
        priorityQueue.Enqueue("c", 3);

        Assert.AreEqual("a", priorityQueue.Dequeue());
        Assert.AreEqual("b", priorityQueue.Dequeue());
        Assert.AreEqual("c", priorityQueue.Dequeue());
    }
}