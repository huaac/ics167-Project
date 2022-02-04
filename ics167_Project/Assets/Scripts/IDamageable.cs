using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// by Aissa Akiyama
/// This is an interface that defines damageable objects. Damageable objects have health that can change at
/// runtime, and a TakeDamage method that takes a damage value.
/// An interface is basically an abstract class, but everything needs to be public and everything needs
/// to be a method. Note that when inheriting from an interface, "overriding" methods need to be public too.
/// </summary>

public interface IDamageable
{
    // Creates private variable "CurrentHealth" + public method "CurrentHealth" that can get/set that variable
    // by just calling the method like a normal variable.
    // e.g. "CurrentHealth = 10" will set CurrentHealth to 10.
    // e.g. "if (CurrentHealth > 10)" will get CurrentHealth value.
    // So yes, this is a function, it just has mechanics automatically implemented by C# getters/setters
    // so it can be used like a variable.
    int CurrentHealth { get; set; }

    void TakeDamage(int damage);
}
