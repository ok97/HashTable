using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }
    }
    class MyMapNode<K, V>
    { /* UC1:- Ability to find frequency of words in a sentence like “To be or not to be”
               - Use LinkedList to do the Hash Table Operation.
               - To do this we create MyMapNode with Key Value Pair and create LinkedList of MyMapNode.
        */

        private readonly int size; // only read value
        private readonly LinkedList<KeyValue<K, V>>[] items; // maintaining list of linkedlist based on the array size 
                                                             //array size 5 each index create one linked list
        public MyMapNode(int size) //constructor
        {
            this.size = size; //
            this.items = new LinkedList<KeyValue<K, V>>[size]; // constructor create new linked list but size is specify hash table
        }

        protected int GetArrayPosition(K key) //Create Method
        {                                   //% size we are gives within reange size value we create an array
            int hash = key.GetHashCode(); // int hash = key.GetHashCode();  //                               
            int position = key.GetHashCode() % size; //GetHashCode predfine method size= array size and array insex 0 to 4
            return Math.Abs(position); //get positive index value/number using Math.Abs method //

        }
        public V Get(K key) // create Get method to use what is value of the key //return value
        { // V is Value
            try
            {
                int position = GetArrayPosition(key);
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
                foreach (KeyValue<K, V> item in linkedList) //fetch
                {
                    if (item.Key.Equals(key)) //Check key same or not
                    {
                        return item.Value;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
            try
            {
                int position = GetArrayPosition(key); // call GaetArrayPosition method
                LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position); //call GetLinkedList create empty linkedlist array index number position
                KeyValue<K, V> item = new KeyValue<K, V> //Prepared key value pair
                { Key = key, Value = value }; //Assign key and Value
                linkedList.AddLast(item); //adding items linked list
               // Console.WriteLine($"{item.Key}=> { item.Value}"); //print key and item/ value
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /* UC2:- Ability to find frequency of words in a large paragraph phrase “Paranoids are not 
                     paranoid because they are paranoid but because they keep putting themselves 
                     deliberately into paranoid avoidable situations”
                     - Use hashcode to find index of the words in the para.
                     - Create LinkedList for each index and store the words and its frequency.
                     - Use LinkedList to do the Hash Table Operation.
                     - To do this create MyMapNode with Key Value Pair and create LinkedList of MyMapNode.
            */
        internal void Set(K key, V value) //createn Set Method
        {
            try
            {
                int position = GetArrayPosition(key);// position = call GaetArrayPosition method
                var linkedList = GetLinkedList(position); // Call method and 
                KeyValue<K, V> temp = new KeyValue<K, V>();
                foreach (KeyValue<K, V> item in linkedList)
                {
                    if (item.Key.Equals(key))
                    {
                        temp = item;
                    }
                }
                temp.Value = value;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }  
    }
    class Run //class
    {
        static void Main(string[] args) //main method
        {
            Console.WriteLine("Hash Table");
            
            /*UC1*/
            //MyMapNode<string, string> hashtable = new MyMapNode<string, string>(5); //create MyMapNode class object adn passing key and value and size
            //hashtable.Add("0", "To"); //add key and value
            //hashtable.Add("1", "be");
            //hashtable.Add("2", "or");
            //hashtable.Add("3", "not");
            //hashtable.Add("4", "to");
            //hashtable.Add("5", "be");
            //Console.WriteLine("\nShowing Value using Key using Get Method");
            //Console.WriteLine($"{hashtable.Get("3")}"); //show the specific value from hashtable.


            /* UC2:- Ability to find frequency of words in a large paragraph phrase “Paranoids are not 
                     paranoid because they are paranoid but because they keep putting themselves 
                     deliberately into paranoid avoidable situations”
                     - Use hashcode to find index of the words in the para.
                     - Create LinkedList for each index and store the words and its frequency.
                     - Use LinkedList to do the Hash Table Operation.
                     - To do this create MyMapNode with Key Value Pair and create LinkedList of MyMapNode.
            */

            MyMapNode<string, int> hashtable = new MyMapNode<string, int>(5);
            string input = "Paranoids are are not paranoid because they are paranoid but because they \n               keep putting themselves deliberately into paranoid avoidable situations\n";
            Console.WriteLine($"Statement is:- {input}");
            try
            {
                string[] inputArray = input.Split(); // split input statement using Split method

                foreach (string word in inputArray) //itterat word in inputArray
                {
                    if (hashtable.Get(word) == 0)
                    {
                        hashtable.Add(word, 1); //Add ing key and value
                    }
                    else
                    {
                        int value = hashtable.Get(word) + 1; //add 1
                        hashtable.Set(word, value); //set word and value
                    }
                }
                string[] newInputArray = inputArray.Distinct().ToArray(); //Unique value store not reapeat value
                foreach (var word in newInputArray)
                {
                    Console.WriteLine("Frequency of Word ccurrence :- \"" + word + "\" is :- " + hashtable.Get(word)); //print word and count
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
