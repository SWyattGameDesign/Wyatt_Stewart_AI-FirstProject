using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using System.Collections.Generic;


namespace NodeCanvas.Tasks.Actions {

	public class PatrolClassAT : ActionTask {

		private NavMeshAgent navAgent;
		public List<Transform> patrolPoints;
		public int patrolPointIndex = 0;

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
			navAgent.SetDestination(patrolPoints[patrolPointIndex].position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(!navAgent.pathPending && navAgent.remainingDistance < 0.25f)
			{
				Debug.Log("We have arrived");
				patrolPointIndex++;

				if(patrolPointIndex >= patrolPoints.Count)
				{
					patrolPointIndex=0;
				}

				Vector3 nextPosition = patrolPoints[patrolPointIndex].position;
				navAgent.SetDestination(nextPosition);
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