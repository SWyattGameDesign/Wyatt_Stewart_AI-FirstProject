using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	[Description("An Action Task that changes the GameObject's color")]
	public class CamouflageAT : ActionTask {

		public GameObject lizard;
		Color camouflage;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			camouflage = new Color32((byte)Random.Range(0f, 255f), (byte)Random.Range(0f, 255f), (byte)Random.Range(0f, 255f), (byte)255f);
			lizard.GetComponent<Renderer>().material.color = camouflage;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			lizard.GetComponent<Renderer>().material.color = new Color32((byte)9f, (byte)217f, (byte)35f, 255);
            EndAction(true);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}