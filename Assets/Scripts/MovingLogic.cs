using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLogic : MonoBehaviour
{

    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    public int steps = 0;
    private float leftLegAngle = 3f;

    [SerializeField] private GameObject leftLeg = null;
    [SerializeField] private GameObject rightLeg = null;
    [SerializeField] private GameObject leftLegJoint = null;
    [SerializeField] private GameObject rightLegJoint = null;
    [SerializeField] private GameObject enemyHead = null;


    private MeshRenderer mat = null;
    // Start is called before the first frame update
    void Start()
    {
        mat = enemyHead.GetComponent<MeshRenderer>();
    }

    void MoveLegs()
    {
        //  Движение ножек сделать
        if (steps >= 20)
        {
            leftLegAngle = -leftLegAngle;
            steps = -20;
        }
        steps++;

        leftLeg.transform.RotateAround(leftLegJoint.transform.position, transform.right, leftLegAngle);
        rightLeg.transform.RotateAround(rightLegJoint.transform.position, transform.right, -leftLegAngle);
    }

    // Update is called once per frame
    void Update()                                               // здесь реализована                                                            
    {
        if (speed == 0f)
        {
            MoveLegs();
            return;
        }
        if (!Volume.pause)
        {
            // логика движения 

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                    return;
                }


            transform.Translate(0, 0, speed * Time.deltaTime);
            MoveLegs();

        }
    }
}
