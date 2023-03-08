using Hapara_Cache_Exercise;

LRUCache cache = new LRUCache(2 /* capacity */);

cache.put(1, 1);
cache.put(2, 2);
Console.WriteLine("Get 1: {0}", cache.get(1));     // returns 1
cache.put(3, 3);    // evicts key 2
Console.WriteLine("Get 2: {0}", cache.get(2));     // returns -1 (not found)
cache.put(4, 4);    // evicts key 1
Console.WriteLine("Get 1: {0}", cache.get(1));       // returns -1 (not found)
Console.WriteLine("Get 3: {0}", cache.get(3));        // returns 3
Console.WriteLine("Get 4: {0}", cache.get(4));        // returns 4
Console.WriteLine("Delete 3: {0}", cache.delete(3));    // returns 3
Console.WriteLine("Get 3: {0}", cache.get(3));        // returns -1 (not found)

/* Extra Tests */
/*
cache.put(1, 1);
cache.put(2, 4);
cache.put(3, 6);
Console.WriteLine("Get 2: {0}", cache.get(2));
Console.WriteLine("Get 1: {0}", cache.get(1));
cache.put(2, 3);
cache.put(4, 7);
Console.WriteLine("Get 2: {0}", cache.get(2));
Console.WriteLine("Get 3: {0}", cache.get(3));
Console.WriteLine("Get 4: {0}", cache.get(4));
Console.WriteLine("Delete 2: {0}", cache.delete(2));
cache.put(5, 1);
cache.put(6, 2);
Console.WriteLine("Get 5: {0}", cache.get(5));
Console.WriteLine("Get 4: {0}", cache.get(4));
*/
