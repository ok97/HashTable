using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MyMapNode<K, V>
    { /* UC1:- Ability to find frequency of words in a sentence like “To be or not to be”
               - Use LinkedList to do the Hash Table Operation.
               - To do this we create MyMapNode with Key Value Pair and create LinkedList of MyMapNode.
        */
        public struct KeyValue<k, v> //data type key and value
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }
        private readonly int size; // only read value
        private readonly LinkedList<KeyValue<K, V>>[] items; // maintaining list of linkedlist based on the array size 
                            //array size 5 each index create one linked list
        public MyMapNode(int size) //constructor
        {
            this.size = size; //
            this.items = new LinkedList<KeyValue<K, V>>[size]; // constructor create new linked list but size is specify hash table
        }

        protected int GetArrayPosition(K key) //Create Method
        {                                    //% size we are gives within reange size value we create an array
            int hash = key.GetHashCode();  //                               
            int position = key.GetHashCode() % size; //GetHashCode predfine method size= array size and array insex 0 to 4
            return Math.Abs(position); //get positive index value/number using Math.Abs method //

        }
        public V get(K key) //create Get method to use what is value of the key //return value
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position) // create GetLinkedList method
        {

            LinkedList<KeyValue<K, V>> linkedList = items[position]; //itc check exist or not linked list

            if (linkedList == null) //linked list == null or empty
            {
                linkedList = new LinkedList<KeyValue<K, V>>(); //create new linked list

                items[position] = linkedList; //assign to index number and linkedList
            }

            return linkedList;
        }

        public void Add(K key, V value) //Create Add mEthod to adding Key and Value
        {
            int position = GetArrayPosition(key); // call GaetArrayPosition method
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); //call GetLinkedList create empty linkedlist array index number position
            KeyValue<K, V> item = new KeyValue<K, V> //Prepared key value pair
            { Key = key, Value = value }; //Assign key and Value
            linkedList.AddLast(item); //adding items linked list
            Console.WriteLine($"{item.Key}   { item.Value}"); //print key and item/ value

        }     

               
    }
    class Run
    {
        static void Main(string[] args)
        {
            MyMapNode<string, string> hashtable = new MyMapNode<string, string>(5); //create MyMapNode class object adn passing key and value and size

            hashtable.Add("0", "To"); //add key and value
            hashtable.Add("1", "be");
            hashtable.Add("2", "or");
            hashtable.Add("3", "not");
            hashtable.Add("4", "to");
            hashtable.Add("5", "be");

            Console.ReadLine();


        }
    }
    
}
