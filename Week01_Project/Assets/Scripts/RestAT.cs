using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class RestAT : ActionTask {

		public BBParameter<Camera> mainCam;
		public BBParameter<Camera> breakCam;
		public BBParameter<float> stress;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			mainCam.value.gameObject.SetActive(false);
			breakCam.value.gameObject.SetActive(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			stress.value -= Time.deltaTime;
			if (stress.value <= 0f )
			{
				EndAction(true);
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			breakCam.value.gameObject.SetActive (false);
			mainCam.value.gameObject.SetActive(true);
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}