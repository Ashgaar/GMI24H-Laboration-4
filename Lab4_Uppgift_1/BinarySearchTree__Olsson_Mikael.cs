using System;
using System.Collections.Generic;
using LaborationInterfaces;

namespace Olsson_Mikael
{
    public class BinarySearchTree<KeyType, ValueType>
        : ISortedDictionary<KeyType, ValueType>
        where KeyType : IComparable<KeyType>
    {
        private class Node
        {
            internal KeyType Key;
            internal ValueType Value;
            internal Node Left = null, Right = null;
        }

        private Node root = null;

        public int Count { get; private set; }

        public void Add(KeyType key, ValueType value)
        {
            Add(key, value, ref root);
        }

        private void Add(KeyType key, ValueType value, ref Node subroot)
        {
            if(subroot == null)
            {
                subroot = new Node() { Key = key, Value = value };
                Count++;
            }
            else if(key.CompareTo(subroot.Key) < 0)
            {
                Add(key, value, ref subroot.Left);
            }
            else if(key.CompareTo(subroot.Key) > 0)
            {
                Add(key, value, ref subroot.Right);
            }
            else
            {
                throw new ArgumentException($"Key: {key} already exists.");
            }
        }

        public void Traverse(Action<KeyValuePair<KeyType, ValueType>> action)
        {
            Traverse(action, root);
        }
        
        private void Traverse(Action<KeyValuePair<KeyType, ValueType>> action, Node subroot)
        {
            if (subroot == null)
            {
                return;
            }
            //Algorithm Inorder(tree)
            //1.Traverse the left subtree, i.e., call Inorder(left-subtree)
            //2.Visit the root.
            //3.Traverse the right subtree, i.e., call Inorder(right-subtree)
            
            //inorder traversal
            Traverse(action, subroot.Left);
            action(new KeyValuePair<KeyType, ValueType>(subroot.Key, subroot.Value));
            Traverse(action, subroot.Right);

            //preorder traversal
            //action(new KeyValuePair<KeyType, ValueType>(subroot.Key, subroot.Value));
            //Traverse(action, subroot.Left);
            //Traverse(action, subroot.Right);

            //postorder traversal
            //Traverse(action, subroot.Left);
            //Traverse(action, subroot.Right);
            //action(new KeyValuePair<KeyType, ValueType>(subroot.Key, subroot.Value));
        }

        public bool Contains(KeyType key)
        {
            return Contains(key, root);
        }

        private bool Contains(KeyType key, Node subroot)
        {
            if (subroot == null)
            {
                return false;
            }
            else if (key.CompareTo(subroot.Key) < 0)
            {
                return Contains(key, subroot.Left); 
            }
            else if (key.CompareTo(subroot.Key) > 0)
            {
                return Contains(key, subroot.Right);
            }
            else
            {
                return true;
            }
        }

        public ValueType Get(KeyType key)
        {
            return Get(key, root);
        }

        private ValueType Get(KeyType key, Node subroot)
        {
            if (subroot == null)
            {
                throw new ArgumentException($"Key: {key} not found.");
            }
            else if (key.CompareTo(subroot.Key) < 0)
            {
                return Get(key, subroot.Left);
            }
            else if (key.CompareTo(subroot.Key) > 0)
            {
                return Get(key, subroot.Right);
            }
            else
            {
                return subroot.Value;
            }
        }
        public void Set(KeyType key, ValueType newValue)
        {
            Set(key, newValue, ref root);
        }

        private void Set(KeyType key, ValueType newValue, ref Node subroot)
        {
            if (subroot == null)
            {
                throw new ArgumentException($"Key: {key} not found.");
            }
            else if (key.CompareTo(subroot.Key) < 0)
            {
                Set(key, newValue, ref subroot.Left);
            }
            else if (key.CompareTo(subroot.Key) > 0)
            {
                Set(key, newValue, ref subroot.Right);
            }
            else
            {
                subroot.Value = newValue;
            }
        }

        public void Remove(KeyType key)
        {
            Remove(key, ref root);
        }

        private void Remove(KeyType key, ref Node subroot)
        {
            if (subroot == null)
            {
                throw new ArgumentException($"Key: {key} not found.");
            }
            else if (key.CompareTo(subroot.Key) < 0)
            {
                Remove(key, ref subroot.Left);
            }
            else if (key.CompareTo(subroot.Key) > 0)
            {
                Remove(key, ref subroot.Right);
            }
            else
            {
                if (subroot.Left == null && subroot.Right == null)
                {
                    subroot = null;
                }
                else if (subroot.Left == null)
                {
                    subroot = subroot.Right;
                }
                else if (subroot.Right == null)
                {
                    subroot = subroot.Left;
                }
                else
                {
                    Node temp = subroot.Right;
                    while (temp.Left != null)
                    {
                        temp = temp.Left;
                    }
                    subroot.Key = temp.Key;
                    subroot.Value = temp.Value;
                    Remove(temp.Key, ref subroot.Right);
                }
                Count--;
            }
        }
    }
}
