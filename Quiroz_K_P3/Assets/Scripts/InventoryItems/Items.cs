using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Items : MonoBehaviour
{
 

    [SerializeField] int quantity;
    [SerializeField] GameObject go; 
    

   
    public Items(int quantity, GameObject gObject)
    {
        this.quantity = quantity;
        go = gObject;
        name = gObject.name;
        //name = n;
    }
    
    public Items()
    {
        quantity = 0;
        name = "Empty";
    }

    
    public GameObject GObject
    {
        get { return go; }
        set { go = value; }
    }
    

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return go.name + ": " + quantity + "\n";
        
    }

}

