using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;


namespace NodeCanvas.Tasks.Actions {

	public class CountdownAT : ActionTask {

		public BBParameter<float> time;
		private float remainingTime;

        public TMP_Text remainingTimeText; //Text element to display time
        public TMP_Text Minutes;
        public TMP_Text Seconds;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			remainingTime = time.value;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            float minutesF = Mathf.FloorToInt(remainingTime / 60);
            float secondsF = Mathf.FloorToInt(remainingTime % 60);

            if (remainingTime - Time.deltaTime > 0.00000000000000f)
			{
				remainingTimeText.gameObject.SetActive(true);
				remainingTime -= Time.deltaTime;
			} else
			{
				remainingTimeText.gameObject.SetActive(false);
			}


			Minutes.text = minutesF.ToString("0");
            Seconds.text = secondsF.ToString("00");
            remainingTimeText.text = minutesF.ToString() + ":" + secondsF.ToString("00");
			time.value = remainingTime;
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}