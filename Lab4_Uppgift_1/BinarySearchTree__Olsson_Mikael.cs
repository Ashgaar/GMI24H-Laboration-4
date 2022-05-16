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

            // Här saknas kod...
        }

        public void Traverse(Action<KeyValuePair<KeyType, ValueType>> action)
        {
            
            // Här saknas kod...
        }

        public bool Contains(KeyType key)
        {
            // Här saknas kod...
            return false;  // Denna rad är endast till för att koden ska gå att bygga.
        }

        public ValueType Get(KeyType key)
        {
            // Här saknas kod... 
            return default(ValueType); // Denna rad är endast till för att koden ska gå att bygga.
        }

        public void Set(KeyType key, ValueType newValue)
        {
            // Här saknas kod...
        }

        public void Remove(KeyType key)
        {
                
            
            // Här saknas kod...

            
        }
    }
}
