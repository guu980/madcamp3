using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    bool flag;
    public GameObject[] obj;
    public GameObject obj2;
    GameObject ice;
    GameObject bingsoo;
    int icecount;
    // Start is called before the first frame update
    void Start()
    {
        icecount = 0;
        flag = false;
        obj = new GameObject[4];
        ice = Resources.Load("ice") as GameObject;
        bingsoo = Resources.Load("rice_bowl") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bingrot" && flag == false)
        {
            flag = true;
            if (icecount < 4)
            {
                obj[icecount] = Instantiate(ice, new Vector3(2.13f, 1.39f, 0.93f), Quaternion.identity);
                icecount++;
            } else
            {
                for(int i=0;i<obj.Length;i++)
                {
                    Destroy(obj[i]);
                }
                obj2 = Instantiate(bingsoo, new Vector3(2.13f, 1.39f, 0.93f), Quaternion.identity);
                icecount = 0;
            }

            Debug.Log("Target called!!!");

        } else if (other.gameObject.tag == "Bingrot_Bottom" && flag == true)
        {
            flag = false;
            Debug.Log("Flag off");
        }
    }
}
