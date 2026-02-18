using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class HowlAT : ActionTask {

		public AudioSource howl;
        public BBParameter<Animator> animator;

		private float cooldownTime = 8f;
		private float actionTime = 0f;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            animator.value.SetBool("Howling", true);
			howl.Play();
			actionTime = 0f;


		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			actionTime = actionTime + Time.deltaTime;

            if (actionTime > cooldownTime)
            {
                EndAction(true);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop() {
            animator.value.SetBool("Howling", false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}