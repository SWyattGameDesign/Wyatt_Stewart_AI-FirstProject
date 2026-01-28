using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{

	public class SearchActionTask : ActionTask
	{
		public BBParameter<Transform> startPos;
		public BBParameter<Transform> endPos;
		public BBParameter<NavMeshAgent> navAgent;

		public float range;

        bool RandomPoint(Vector3 center, float range, out Vector3 result)
        {
            for (int i = 0; i < 30; i++)
            {
                Vector3 randomPoint = center + Random.insideUnitSphere * range;
                NavMeshHit hit;
                if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
                {
                    result = hit.position;
                    return true;
                }
            }
            result = Vector3.zero;
            return false;
        }


        protected override string OnInit()
		{
			return null;
		}

		protected override void OnExecute()
		{
            

        }

		protected override void OnUpdate()
		{
            Vector3 point;
            if (RandomPoint(agent.transform.position, range, out point))
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            }

        }

		//Called when the task is disabled.
		protected override void OnStop()
		{
			
		}

		//Called when the task is paused.
		protected override void OnPause()
		{
			
		}
	}
}