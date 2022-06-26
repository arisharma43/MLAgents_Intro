using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class MoveToGoalAgent : Agent{

    [SerializeField] private Transform targetTransform;
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material loseMaterial;
    [SerializeField] private MeshRenderer floorMeshRenderer;


    public override void OnEpisodeBegin(){
<<<<<<< HEAD
        //transform.localPosition=Vector3.zero;
        transform.localPosition = new Vector3(Random.Range(-3f, +1f), 0, Random.Range(-2f, 2f));
        targetTransform.localPosition = new Vector3(Random.Range(2.6f, 5f), 0, Random.Range(-2f, 2f));
=======
        transform.localPosition=Vector3.zero;
        //transform.localPosition = new Vector3(Random.range(-3f, +1f), 0, Random.range(-2f, 2f));
        //targetTransform.localPosition = new Vector3(Random.range(-3f, +1f), 0, Random.range(-2f, 2f));
>>>>>>> b5c3618 (First commit, fixed project with nn model, includes .gitignore(may need to be updated))
    }

    public override void CollectObservations(VectorSensor sensor){
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(targetTransform.localPosition);
    }
    
    public override void OnActionReceived(ActionBuffers actions){
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float moveSpeed=3f;
        transform.localPosition += new Vector3(moveX,0,moveZ)*Time.deltaTime*moveSpeed;

    }

    public override void Heuristic(in ActionBuffers actionsOut){
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }


    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
        //Debug.Log(collision);
=======
        Debug.Log(collision);
>>>>>>> b5c3618 (First commit, fixed project with nn model, includes .gitignore(may need to be updated))
        if (collision.transform.tag=="Goal")
        {
            SetReward(1f);
            floorMeshRenderer.material = winMaterial;
            EndEpisode();
        }else if (collision.transform.tag == "Wall")
        {
            SetReward(-1f);
            floorMeshRenderer.material = loseMaterial;
            EndEpisode();
        }
    }

}
