using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRSlider : MonoBehaviour
{
    public float fillTime = 1f;
    private Slider mySlider; 
    private float timer;
    private bool gazedAt;
    private Coroutine fillBarRoutine;
    private float Speed = 1.0f;
    public GameObject Target;
    private Transform TargetTrans;
    public GameObject WayPoint;
    private Transform WayPointTrans;
    public bool check = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveFloat = 0f;


    // Start is called before the first frame update
    void Start()
    {
        mySlider = GetComponent<Slider>();
        if(mySlider == null){
            Debug.Log("Please add a Slider component to this gameobject");
        }
        TargetTrans = Target.transform;
        WayPointTrans = WayPoint.transform;
        // positionIdx = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(check == true){
            moveFloat += Time.deltaTime*1.5f;
            if(moveFloat >= 1f)
            {
                moveFloat = 0f;
                check = false;
            }
            else
            {
                TargetTrans.position = Vector3.Lerp(startPosition, endPosition, moveFloat);
                // Target.transform.position = WayPoint.transform.position;
            }
        }      

    }

    public void PointerEnter() {
        gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());

    }
    public void PointerExit(){
        gazedAt = false;
        if(fillBarRoutine != null){
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        mySlider.value = 0f;

        
    }
    private IEnumerator FillBar() {
        timer = 0f;
        while (timer < fillTime){
            timer += Time.deltaTime;
            mySlider.value = timer / fillTime;
            yield return null;
            
            //if the user is still looking at the bar, go on to the next iteration of the loop.
            if(gazedAt){
                continue;
            }

            //사용자가 바를 더이상 쳐다보지 않을 때, 타이머와 바를 리셋하고 leave the function
            timer = 0f;
            mySlider.value = 0f;
            yield break;
        }
        //바가 다 채워졌을 때 실행

        OnBarFilled();

    }
    private void OnBarFilled() {
        Debug.Log("Do something!!");
        check = true;
        startPosition = TargetTrans.position;
        endPosition = WayPointTrans.position;
    }
}
