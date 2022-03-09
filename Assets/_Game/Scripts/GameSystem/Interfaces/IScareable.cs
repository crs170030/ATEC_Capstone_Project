using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScareable<T>
{
    void ReduceResolve(T reduceAmount);
}
