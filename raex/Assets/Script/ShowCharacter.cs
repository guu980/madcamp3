using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCharacter : MonoBehaviour
{
    public int characterId = 0;
    public GameObject Target;
    private Transform TargetTrans;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveFloat = 0f;
    private Transform transform;
    public bool check = true;

    void Start()
    {
        // if(characterId == 1){
        //     transform.position = new Vector3(1f, -0.9f, -4.5f);
        // }
        // else if(characterId == 2){
        //     transform.position = new Vector3(-2f, -0.53f, -4.5f);
        // }
    

        TargetTrans = Target.transform;
        startPosition = TargetTrans.position;
        
        if(characterId == 1){
            endPosition = new Vector3(1f, 1.5f, -9f);
        }
        else if(characterId == 2){
            endPosition = new Vector3(-2f, 1.6f, -9f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(check == true){
            moveFloat += Time.deltaTime*1.0f;
            if(moveFloat >= 1f){
                moveFloat = 0f;
                check = false;
            }
            else{
                TargetTrans.position = Vector3.Lerp(startPosition, endPosition, moveFloat);
            }
        }

    
    }
}
