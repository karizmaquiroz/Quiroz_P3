using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//attached to bullet prefab

public enum RangedAction { BuffDebuff, ChangeHP, ActivateEnv, None };
public enum RangedType { Weapon, None };
public enum MovementType { Basic, Drop, None };


public class BulletItems : MonoBehaviour
{
    public class itemRanged : MonoBehaviour
    {
        public int Amount, Value;
        public float Weight, Speed, DropSpeed;
        public string Name, Stat;
        public RangedAction rangedAction = RangedAction.None;
        public RangedType rangedType = RangedType.None;
        public MovementType moveType = MovementType.None;

        void Start()
        {
        }

        //void BuffDebuffStat(GameObject other)
        //{
        //    other.SendMessage("BuffDebuffStat", new KeyValuePair<string, int>(Stat, Amount));
        //}

        void ChangeHealth(GameObject other)
        {
            other.SendMessage("ChangeHealth", Amount);
        }



        void BasicMovement()
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        }

        void DropMovement()
        {
            transform.Translate(new Vector3(0, DropSpeed, 1) * (Time.deltaTime * Speed));
        }

        void Update()
        {
            switch (moveType)
            {
                case MovementType.Basic:
                    BasicMovement();
                    break;
                case MovementType.Drop:
                    DropMovement();
                    break;
            }
        }

        void OnTriggerEnter(Collider col)
        {
            //Debug.Log (col.gameObject.name);
            switch (col.gameObject.tag)
            {
                case "Enemy":
                    Debug.Log("Enemy " + rangedType.ToString() + ", " + rangedAction.ToString() + ", " + col.gameObject.name);
                    if (rangedType == RangedType.Weapon)
                    {
                        if (rangedType != RangedType.None)
                        {
                            if (rangedAction == RangedAction.ChangeHP)
                                ChangeHealth(col.gameObject);

                        }
                    }
                    break;
                case "Environment":
                    if (rangedType != RangedType.None)
                    {
                        if (rangedAction == RangedAction.ChangeHP)
                            ChangeHealth(col.gameObject);
                    }
                    break;
                case "Untagged":
                    Debug.Log("Nothing");
                    break;
            }

            Destroy(gameObject);
        }

    }

}
