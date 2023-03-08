using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hapara_Cache_Exercise
{
    internal class LRUCache
    {
        private int capacity;
        private Dictionary<int, int> activeCache;
        private List<int> lastUsedKeys;

        public LRUCache(int _capacity)
        {
            if (_capacity <= 0)
                throw new Exception("Please ensure that the value passed on to LRUCache constructor is > 0.");

            capacity = _capacity;
            lastUsedKeys = new(_capacity);
            activeCache = new(_capacity);

            Console.WriteLine("New LRUCache being created with capacity {0}", capacity);
        }

        public void put(int key, int value)
        {
            Console.WriteLine("PUT: key {0} value {1}", key, value);
            int lastKeyRemoved = AddToRecentKeys(key);

            if (!activeCache.ContainsKey(key) && activeCache.Count >= capacity)
            {
                activeCache.Remove(lastKeyRemoved);
                Console.WriteLine("Removed key {0} from dictionary", lastKeyRemoved);
            }

            activeCache[key] = value;
            Console.WriteLine("Added or Updated key {0} with value {1} from dictionary", key, value);
            return;
        }

        public int get(int key) 
        {
            Console.WriteLine("GET: key {0}", key);
            if (!activeCache.ContainsKey(key))
                return -1;

            AddToRecentKeys(key);

            return activeCache[key];
        }
        public int delete(int key)
        {
            Console.WriteLine("DELETE: key {0}", key);
            if (!activeCache.ContainsKey(key))
                return -1;

            int deletedValue = activeCache[key];
            activeCache.Remove(key);
            DeleteFromRecentKeys(key);

            return deletedValue;
        }

        private int AddToRecentKeys(int key)
        {
            
            int keyIndex = lastUsedKeys.FindIndex(k => k == key);
            if (keyIndex > -1)
            {
                lastUsedKeys.RemoveAt(keyIndex);
            }

            int lastKeyRemoved = TrimList(lastUsedKeys, capacity - 1);

            lastUsedKeys.Add(key);

            return lastKeyRemoved;
        }
        private void DeleteFromRecentKeys(int key)
        {
            lastUsedKeys.Remove(key);
        }

        private int TrimList(List<int> list, int capacity)
        {
            int lastKeyRemoved = -1;
            while (lastUsedKeys.Count > capacity)
            {
                lastKeyRemoved = lastUsedKeys[0];
                lastUsedKeys.RemoveAt(0);
            }

            return lastKeyRemoved;
        }
    }
}
