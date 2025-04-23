using NUnit.Framework;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Search;
using Unity.VisualScripting;
using UnityEngine.AI;
using static UnityEditor.Progress;
using NUnit.Framework.Interfaces;

//attach to the player use UGUI
public class Inventory : MonoBehaviour
{
    bool showInventory = false;
   
    //public Rect inventoryRect = new Rect(Screen.width / 2, Screen.height / 2, 400, 400);



    public GameObject EmptyObject;
    private int InventorySize = 12;


    //Player playersHP = new Player();

    public List<Items> inventoryItems;

    public List<Items> QuickItems;
    List<Items> Items = new List<Items>();

    public Button showInventoryMenuButton;
    public Canvas InventoryCanvas;
    public Button Item1;
    public Button Item2;
    public Button Item3;
    public Button Item4;


    //public GameObject bullet1; //red
    //public GameObject bullet2; //green
    //public GameObject bullet3; //blue
    //public float speed;
    //public Transform bulletSpawnPoint;



    public void Awake()
    {
        InitalizeInventory();
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            showInventory = (showInventory) ? false : true;
            OpenInventory();
            UpdateInventory();
        }
        if (Input.GetKeyDown("1"))
        {
            useItem(inventoryItems[0]);
            RemoveFromInventory(1, inventoryItems[0].ToString());
            UpdateInventory();
        }
        if (Input.GetKeyDown("2"))
        {
            useItem(inventoryItems[1]);
            RemoveFromInventory(1, inventoryItems[1].ToString());
            UpdateInventory();
        }
        if (Input.GetKeyDown("3"))
        {
            useItem(inventoryItems[2]);
            RemoveFromInventory(1, inventoryItems[2].ToString());
            UpdateInventory();
        }
        if (Input.GetKeyDown("4"))
        {
            useItem(inventoryItems[3]);
            RemoveFromInventory(1, inventoryItems[3].ToString());
            UpdateInventory();
        }
        Item1.onClick.AddListener(ClickItem1);
        Item2.onClick.AddListener(ClickItem2);
        Item3.onClick.AddListener(ClickItem3);
        Item4.onClick.AddListener(ClickItem4);
    }


    private void InitalizeInventory()
    {
        OpenInventory();
        inventoryItems = new List<Items>(); //or  inventoryItems = new List<Items>(InventorySize);
        QuickItems = new List<Items>(); //or  QuickItems = new List<Items>(4);

        for (int i = 0; i < InventorySize; i++)
        {
            inventoryItems.Add(new Items());
        }
        
        for (int i = 0; i < 4; i++)
        {
            QuickItems.Add(new Items());
        }
        

        
        

    }

    public void AddToInventory(int HowMany, GameObject NewItem)
    {


        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].name == NewItem.name)
            {

                int value = inventoryItems[i].Quantity + HowMany;
                inventoryItems[i].Quantity = value;
                print("InventoryItems Name: " + inventoryItems[i].name);
                break;
            }
            else if (inventoryItems[i].name == "Empty")
            {
                string Value = NewItem.name;
               
                Items createIt = new Items(HowMany, NewItem);
                Items.Add(createIt);
                break;
            }
        }
    }

    public void RemoveFromInventory(int HowMany, string ItemName)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].Name.Equals(ItemName))
            {
                int value = inventoryItems[i].Quantity - HowMany;
                inventoryItems[i].Quantity = value;

                if (inventoryItems[i].Quantity <= 0)
                {
                    inventoryItems[i] = new Items(0, EmptyObject);
                    // if method took in a GameObject callled ItemName then do below
                    //inventoryItems[i] = new Item(0, EmptyObject);
                }
                break;
            }
        }

        /*
        for (int i = 0; i < QuickItems.Count; i++)
        {
            if (QuickItems[i].Name.Equals(ItemName))
            {
                if (QuickItems[i].Quantity == 0)
                { QuickItems[i] = new Items(); }
            }
        }
        */
    }

    void OpenInventory()
    {
        if (showInventory)
        {
            InventoryCanvas.gameObject.SetActive(true);
        }
        else
        {
            InventoryCanvas.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        int inventoryAmount = 1;
        if (other.gameObject.tag.Equals("Item"))
        {
            if (inventoryItems[11].Name != "Empty")
            {
                Debug.Log("Inventory is full");
                return;
            }

            //if (InventoryItems.Contains == other.gameObject.name)
            {
                //inventoryAmount = other.gameObject.GetComponent.amount;
            }

            AddToInventory(inventoryAmount, other.gameObject);
            other.gameObject.SetActive(false);
        }
            UpdateInventory();
    }


    //useItem method
    public void useItem(Items playerItems)  //remove quantity
    {

        if (name == "Empty") { return; }
        else if (name == "Staff")
        {
            gameObject.GetComponent<ProjectileScript>().Bullet2 = true;
           
        }
        else if (name == "Bomb")
        {
            gameObject.GetComponent<ProjectileScript>().Bullet1 = true;
        }

        else if (name == "Gun")
        {
            gameObject.GetComponent<ProjectileScript>().Bullet3 = true;
        }
        else if (name == "Wand")
        {
            gameObject.GetComponent<ProjectileScript>().Bullet3 = true;
        }




        if (playerItems.Name == "LongPotion_2")
        {
            gameObject.GetComponent<PlayerHealth>().currentHealth += 10;
        }
        if (playerItems.Name == "HandlePotion.012")
        {
            gameObject.GetComponent<PlayerHealth>().currentHealth += 20;
        }
        if (playerItems.Name == "LongHandlePotion.008")
        {
            gameObject.GetComponent<PlayerHealth>().currentHealth += 30;
        }

        RemoveFromInventory(1, name);
    }




    void ClickItem1()
    {
        useItem(inventoryItems[0]);
        RemoveFromInventory(1, inventoryItems[0].ToString());
        UpdateInventory();
    }
    void ClickItem2()
    {
        useItem(inventoryItems[1]);
        RemoveFromInventory(1, inventoryItems[1].ToString());
        UpdateInventory();
    }
    void ClickItem3()
    {
        useItem(inventoryItems[2]);
        RemoveFromInventory(1, inventoryItems[2].ToString());
        UpdateInventory();
    }
    void ClickItem4()
    {
        useItem(inventoryItems[3]);
        RemoveFromInventory(1, inventoryItems[3].ToString());
        UpdateInventory();
    }
    void UpdateInventory()
    {
        Item1.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItems[0].ToString();
        Item2.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItems[1].ToString();
        Item3.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItems[2].ToString();
        Item4.GetComponentInChildren<TextMeshProUGUI>().text = inventoryItems[3].ToString();
    }



    /*
    void OnGUI()
    {
        if (showInventory)
        {
            inventoryRect = GUI.Window(0, inventoryRect, InventoryGUI, "Inventory");
        }
    }

    void InventoryGUI(int ID)
    {
        GUILayout.BeginArea(new Rect(0, 50, 400, 400));

        GUILayout.BeginHorizontal();
        if (GUILayout.Button(inventoryItems[0].ToString(), GUILayout.Height(75)))
        {
            RemoveFromInventory(1, name);
        }
        //GUILayout.Button(itemCount[0].Value.ToString() + " " + invItems[0].name, GUILayout.Height(75));
        if (GUILayout.Button(inventoryItems[1].ToString(), GUILayout.Height(75)))
        {
            RemoveFromInventory(1, name);
        }
        GUILayout.Button(inventoryItems[2].ToString(), GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(inventoryItems[3].ToString(), GUILayout.Height(75));
        GUILayout.Button(inventoryItems[4].ToString(), GUILayout.Height(75));
        GUILayout.Button(inventoryItems[5].ToString(), GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(inventoryItems[6].ToString(), GUILayout.Height(75));
        GUILayout.Button(inventoryItems[7].ToString(), GUILayout.Height(75));
        GUILayout.Button(inventoryItems[8].ToString(), GUILayout.Height(75));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(QuickItems[0].Name, GUILayout.Height(50));
        GUILayout.Button(QuickItems[1].Name, GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button(QuickItems[2].Name, GUILayout.Height(50));
        GUILayout.Button(QuickItems[3].Name, GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.EndArea();
    }
    */
    
}
