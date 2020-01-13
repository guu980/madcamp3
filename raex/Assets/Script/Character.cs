using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Start is called before the first frame update
    private int count;
    // public int characterId;
    public GameObject gameObject;

    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other){

        if(other.gameObject.tag == "cube"){
            Destroy(this.gameObject);
            count++;
            Debug.Log("count : " + count);
        }
        if(count == 2){
            Application.LoadLevel("GameOverScene");
        }


    }
}
