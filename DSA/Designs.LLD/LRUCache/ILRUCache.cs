namespace Designs.LLD.LRUCache
{
  public interface ILRUCache<TKey, TValue>
  {
    TValue Get(TKey key);
    void Put(TKey key, TValue value);
  }
}
