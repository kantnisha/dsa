namespace Designs.LLD.LRUCache
{
  public class LRUCache<TKey, TValue> : ILRUCache<TKey, TValue>
  {
    private const int DefaultCapacity = 2;
    Dictionary<TKey, TValue> store;
    private int capacity;
    private TKey recentlyUsed;

    public LRUCache()
    {
      store = new Dictionary<TKey, TValue>(DefaultCapacity);
      capacity = DefaultCapacity;
    }

    public LRUCache(int capacity)
    {
      this.capacity = capacity;
      store = new Dictionary<TKey, TValue>(capacity);
    }

    public TValue Get(TKey key)
    {
      if (store.TryGetValue(key, out TValue value))
      {
        recentlyUsed = key;
        return value;
      }

      return default(TValue);
    }

    public void Put(TKey key, TValue value)
    {
      if(store.Count < capacity)
      {
        if(store.TryGetValue(key, out value))
        {
          store[key] = value;
        }
        else
        {
          store.Add(key, value);
        }
      }
      else
      {
        foreach(var kv in store)
        {
          if(Comparer<TKey>.Default.Compare(kv.Key, recentlyUsed) == 0)
          {
            store.Remove(recentlyUsed);
            store.Add(key, value);
          }
        }
      }
    }
  }
}
