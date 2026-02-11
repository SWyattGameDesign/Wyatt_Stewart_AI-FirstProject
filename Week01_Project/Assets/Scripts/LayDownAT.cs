using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class LayDownAT : ActionTask {

		public BBParameter<float> energy;
		public float restValue;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if (energy.value <= 0f)
            {
                energy.value = 0f;
            }
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			energy.value += restValue * Time.deltaTime;
			if (energy.value >= 100f)
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