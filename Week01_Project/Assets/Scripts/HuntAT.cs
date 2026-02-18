using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask {

		public BBParameter<bool> preyFound;
		public BBParameter<float> speed;
		public BBParameter<Transform> closestPrey;
		public Transform wolfTransform;
		public BBParameter<GameObject> preyObject;

		public float rotateSpeed;

		private NavMeshAgent navAgent;
		
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute()
		{
			
						
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            closestPrey.value = preyObject.value.transform;
            navAgent.SetDestination(preyObject.value.transform.position);

            Vector3 directionToMove = preyObject.value.transform.position - agent.transform.position;
            Quaternion rotateTo = Quaternion.LookRotation(directionToMove, Vector3.up);


            agent.transform.rotation = Quaternion.RotateTowards(agent.transform.rotation, rotateTo, rotateSpeed * Time.deltaTime);

			//agent.transform.position = Vector3.MoveTowards(agent.transform.position, preyObject.value.transform.position, Time.deltaTime * speed.value);
			navAgent.speed += speed.value;

			if(Vector3.Distance(agent.transform.position, preyObject.value.transform.position) < 10f)
			{
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