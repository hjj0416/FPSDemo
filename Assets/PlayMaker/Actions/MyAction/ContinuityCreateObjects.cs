using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("MyAction")]
[Tooltip("连续创建某一物体例如子弹")]
public class ContinuityCreateObjects : FsmStateAction
{
        [RequiredField]
        [Tooltip("GameObject to create. Usually a Prefab.")]
        public FsmGameObject gameObject;

        [Tooltip("Optional Spawn Point.")]
        public FsmGameObject spawnPoint;

        public FsmFloat time;

        private float t;

        public override void Reset()
        {
            gameObject = null;
            spawnPoint = null;
            time = 1f;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
        {
            DoCreate();
            t = time.Value;
        }

        public override void OnUpdate()
        {
            t -= Time.deltaTime;
            if (t<=0)
            {
                DoCreate();
                t = time.Value;
            }
        }

        void DoCreate()
        {
            var newObject = (GameObject)Object.Instantiate(gameObject.Value, spawnPoint.Value.transform.position, Quaternion.Euler(spawnPoint.Value.transform.eulerAngles));
        }
    }

}
