namespace C_Sharp_Examples.InterviewSamples
{
    public class DeleteNode
    {
        public void DeleteANode(ref LinkedListNode nodeToDelete)
        {
            /* Any references to the input node have now effectively been reassigned to its Next node.
             *  In our example, we "deleted" the node assigned to the variable b, but in actuality we just gave 
             *  it a new value (2) and a new Next! If we had another pointer to b somewhere else in our 
             *  code and we were assuming it still had its old value (8), that could cause bugs.
                If there are pointers to the input node's original next node, those pointers now point to a 
                "dangling" node (a node that's no longer reachable by walking down our list). 
                In our example above, c is now dangling. If we changed c, we'd never encounter 
                that new value by walking down our list from the head to the tail. */
            var nextNode = nodeToDelete.Next;
            nodeToDelete.Value = nextNode.Value;
            nodeToDelete.Next = nextNode.Next;
        }
    }

    public class LinkedListNode
    {
        public int Value { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int value)
        {
            Value = value;
        }
    }
}
