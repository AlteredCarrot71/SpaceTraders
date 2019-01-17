using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;

// This class is used implement a max sized list
public class PresizedList<T> : List<T>
{
    // Private declarations
    public readonly int maxSize;

    // Returns whether more elements can be added to this list.
    public bool HasRoom()
    {
        return base.Count < maxSize;
    }

    public PresizedList(int _maxSize) : base()
    {
        maxSize = _maxSize;
    }

    public new void Add(T item)
    {
        if (item == null) 
        {
            throw new ArgumentException(ResourceLoader.GetForViewIndependentUse().GetString("Agrument/Invalid/Null"));
        }
        else if (Count == maxSize)
        {
            throw new ArgumentException(ResourceLoader.GetForViewIndependentUse().GetString("Agrument/ReachedMaxSize"));
        }
        else
        {
            base.Add(item);
        }
    }
}
