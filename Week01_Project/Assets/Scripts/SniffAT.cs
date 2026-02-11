using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {


	public class SniffAT : ActionTask {

		//set initial variables to create an overlap sphere so we can seek out prey

        public float scanRadius;
		public float initialScanRadius;
		public LayerMask targetMask;
		public float scanSpeed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			scanRadius = initialScanRadius; //make sure that the scan radius goes back to the default when this action task is reset.
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			GameObject closestPrey = null;
			
			DrawCircle(agent.transform.position, scanRadius, Color.red, 8); //visualize the scan radius

			scanRadius += scanSpeed * Time.deltaTime;

			Collider[] prey = Physics.OverlapSphere(agent.transform.position, scanRadius, targetMask); //set up a sphere that will expand and search out only objects on the "prey" layer
			foreach (Collider preyItem in prey)
			{
				GameObject preyObject = preyItem.gameObject;
				

				if (preyObject == null)
				{
					Debug.LogError("Failed to get transform component off of prey item [" + preyItem.gameObject.name + "].");
					continue;
				}
				if(preyObject != null)
				{
					float startDistance = Mathf.Infinity;
					float currentDistance = Vector3.Distance(preyObject.transform.position, agent.transform.position);
					if (currentDistance < startDistance)
					{
						startDistance = currentDistance;
						closestPrey = preyObject;
					}
				}

				if (Vector3.Distance(preyObject.transform.position, agent.transform.position) < 20f )
				{
					EndAction(true);
				}
			}


			

		}
        private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
        {
            Vector3 startPoint, endPoint;
            int anglePerPoint = 360 / numberOfPoints;
            for (int i = 1; i <= numberOfPoints; i++)
            {
                startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i - 1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i - 1)));
                startPoint = center + startPoint * radius;
                endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
                endPoint = center + endPoint * radius;
                Debug.DrawLine(startPoint, endPoint, colour);
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