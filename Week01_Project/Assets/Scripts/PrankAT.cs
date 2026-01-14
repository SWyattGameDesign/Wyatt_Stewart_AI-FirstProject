using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	[Description("An action task where the UI changes by placing new images on the UI after a given time.")]
	public class PrankAT : ActionTask {

		public Sprite newImage;
		public Image currentImage;
		public Sprite returnImage;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			currentImage.sprite = newImage;
			currentImage.rectTransform.sizeDelta = new Vector2(600,600);
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {


		}

		//Called when the task is disabled.
		protected override void OnStop() {
			currentImage.sprite = returnImage;
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}