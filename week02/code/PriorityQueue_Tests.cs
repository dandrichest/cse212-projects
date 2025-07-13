using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
    [TestClass]
    public class PriorityQueueTests
    {
         [TestMethod]
        // Scenario: Enqueue items with unique priorities.
        // Expected Result: Items are dequeued in order of highest priority (lowest number).
        // Defect(s) Found: Items were not returned in correct priority order.
    public void TestPriorityQueue_UniquePriorities()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("Alpha", 5);
            pq.Enqueue("Bravo", 2);
            pq.Enqueue("Charlie", 3);

            Assert.AreEqual("Bravo", pq.Dequeue());
            Assert.AreEqual("Charlie", pq.Dequeue());
            Assert.AreEqual("Alpha", pq.Dequeue());
        }

        [TestMethod]
        // Scenario: Enqueue multiple items with identical highest priority.
        // Expected Result: First inserted item with highest priority is returned.
        // Defect(s) Found: Insertion order was not preserved for items with equal priority.

    public void TestPriorityQueue_DuplicateHighestPriority()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("First", 1);
            pq.Enqueue("Second", 3);
            pq.Enqueue("Third", 1);

            Assert.AreEqual("First", pq.Dequeue());
            Assert.AreEqual("Third", pq.Dequeue());
            Assert.AreEqual("Second", pq.Dequeue());
        }

        [TestMethod]
        // Scenario: Enqueue items, dequeue some, then enqueue more with various priorities.
        // Expected Result: Newly added items should be correctly prioritized.
        // Defect(s) Found: Reordering failed after new insertions; dequeue returned incorrect item.

    public void TestPriorityQueue_MixedTimingInsert()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("One", 4);
            pq.Enqueue("Two", 2);

            Assert.AreEqual("Two", pq.Dequeue());

            pq.Enqueue("Three", 1);
            pq.Enqueue("Four", 5);

            Assert.AreEqual("Three", pq.Dequeue());
            Assert.AreEqual("One", pq.Dequeue());
            Assert.AreEqual("Four", pq.Dequeue());
        }

        [TestMethod]
        // Scenario: Dequeue from an empty queue.
        // Expected Result: Exception should be thrown.
        // Defect(s) Found: No exception was thrown when queue was empty.

    public void TestPriorityQueue_EmptyQueueThrows()
        {
            var pq = new PriorityQueue();
            Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        }

        [TestMethod]
        // Scenario: Enqueue items with negative priorities.
        // Expected Result: Items with more negative values should be returned first.
        // Defect(s) Found: Negative priority handling was incorrect or ignored.

    public void TestPriorityQueue_NegativePriority()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("X", -2);
            pq.Enqueue("Y", -1);
            pq.Enqueue("Z", -3);

            Assert.AreEqual("Z", pq.Dequeue());
            Assert.AreEqual("X", pq.Dequeue());
            Assert.AreEqual("Y", pq.Dequeue());
        }

        [TestMethod]
        // Scenario: Enqueue one item and dequeue it.
        // Expected Result: Same item returned.
        // Defect(s) Found: Single item was not returned correctly or an error occurred.

    public void TestPriorityQueue_SingleEntry()
        {
            var pq = new PriorityQueue();
            pq.Enqueue("Solo", 42);
            Assert.AreEqual("Solo", pq.Dequeue());
        }
    }