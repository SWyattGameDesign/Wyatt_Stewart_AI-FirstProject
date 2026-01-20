using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DrainAT : ActionTask {

		public GameObject valueless;
		public BBParameter<float> value;
		public Transform[] targetTransforms;
		public float speed;
		private int i = 0;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			var colorValue = valueless.GetComponent<Renderer>().material;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if( i <= 2f){ 
				var currentTarget = targetTransforms[i];
                Debug.Log("i is now " + i);
                Vector3 directionToTarget = targetTransforms[i].position - agent.transform.position;
				agent.transform.position += directionToTarget.normalized * speed * Time.deltaTime;

				float distanceToTargets = directionToTarget.magnitude;

				if (distanceToTargets < 0.5f)
				{
					i++;
					if(i == 3)
					{
						i = 0;
					}				
					
				}
			}

			value.value -= 2 * Time.deltaTime;
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}