using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEditor.Experimental.GraphView;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolAT : ActionTask {

		public BBParameter<float> speed;
		public BBParameter<float> energy;

		public float rotateSpeed;
		public BBParameter<int> currentWaypoint = 0;


		public BBParameter<Transform[]> waypoints;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			Vector3 directionToMove = waypoints.value[currentWaypoint.value].transform.position - agent.transform.position;

                
			Quaternion rotateTo = Quaternion.LookRotation(directionToMove, Vector3.up);

				
			agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, rotateTo, rotateSpeed * Time.deltaTime);

			agent.transform.position = Vector3.MoveTowards(agent.transform.position, waypoints.value[currentWaypoint.value].transform.position, Time.deltaTime * speed.value);

            if (Vector3.Distance(waypoints.value[currentWaypoint.value].transform.position, agent.transform.position) < 0.5f)
			{ 

                currentWaypoint.value++;
                if (currentWaypoint.value >= waypoints.value.Length)
                {
                    currentWaypoint = 0;
                }
                EndAction(true);


            }






        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}