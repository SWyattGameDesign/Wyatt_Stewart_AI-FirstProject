using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {

		public BBParameter<Transform> closestPrey;

		public float jumpForce = 3f;
		public float gravityScale = 1f;
		private Vector3 velocity;
		private float groundY = 0f;

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
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            navAgent.SetDestination(closestPrey.value.position);


            velocity.y += Physics.gravity.y * gravityScale * Time.deltaTime;

			if (Vector3.Distance(closestPrey.value.transform.position, agent.transform.position) <= 1f)
			{
				velocity.y = jumpForce;
				agent.transform.position += velocity * Time.deltaTime;
				GameObject prey = closestPrey.value.gameObject;
				prey.SetActive(false);
				closestPrey.value = null;
			}

			if (closestPrey.value == null)
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