using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GemCollector gemCollector;


    [SerializeField] List<Transform> BodyParts = new List<Transform>();
    [SerializeField] public float forwardSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] int startingSize;
    [SerializeField] GameObject bodyPrefab;


    public float minDistance = 0.25f;
    private float bodyDistance;

    private Transform curBodyPart;
    private Transform prevBodyPart;

    private Vector3 startingPos;
    private Vector3 currentPos;
    private Vector3 goalPos;
    private float posDistance;

    
    private Quaternion startingRot;
    private Quaternion currentRot;

    private float zCurrentPos;
    

    private float hyperSpeed;



    void Start()
    {
        startingPos = BodyParts[0].transform.position;
        startingRot = BodyParts[0].transform.rotation;

        for (int i = 0; i < startingSize - 1; i++)
        {
            AddBodyPart();
        }
        hyperSpeed = forwardSpeed * 3;              
    }
    public void MoveForward()
    {

        if (gemCollector.isHyperMode)
        {
            MoveToCenter();
            BodyParts[0].Translate(BodyParts[0].forward * hyperSpeed * Time.deltaTime, Space.World);

        }
        else
        {
            BodyParts[0].Translate(BodyParts[0].forward * forwardSpeed * Time.deltaTime, Space.World);
        }
        

    }

     public void SideRotation()
    {
        if (gemCollector.isHyperMode)
        {
            return;
        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            BodyParts[0].Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        }
        
    }

    public void Movement()
    {
        MoveForward();
        SideRotation();

        for(int i = 1; i< BodyParts.Count; i++)
        {
            curBodyPart = BodyParts[i];
            prevBodyPart = BodyParts[i - 1];

            bodyDistance = Vector3.Distance(prevBodyPart.position, curBodyPart.position);

            Vector3 newPos = prevBodyPart.position;

            float T = Time.deltaTime * bodyDistance * forwardSpeed;


            if (T > 0.5f)
                T = 0.5f;

            curBodyPart.position = Vector3.Slerp(curBodyPart.position, newPos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodyPart.rotation, T);
        } 
      
    }

    public void AddBodyPart()
    {
        Transform newpart = (Instantiate(bodyPrefab, BodyParts[BodyParts.Count - 1].position,
            BodyParts[BodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        BodyParts.Add(newpart);
    }

    void MoveToCenter()
    {
        BodyParts[0].transform.position = Vector3.Lerp(BodyParts[0].transform.position, new Vector3(0, 0, BodyParts[0].transform.position.z),Time.deltaTime*2);

        /*currentPos = BodyParts[0].transform.position;
        
        currentRot = BodyParts[0].transform.rotation;
        goalPos = startingPos + (startingPos + new Vector3(0, 0, BodyParts[0].transform.position.z));
        

        posDistance = Vector3.Distance(currentPos, goalPos);

        float T = Time.deltaTime * posDistance * hyperSpeed;

        transform.position = Vector3.Slerp(currentPos, goalPos, T);
        transform.rotation = Quaternion.Lerp(curBodyPart.rotation,startingRot, T);*/
         
    }

   

   

}
