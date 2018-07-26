using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

    [ActionCategory("MyAction")]
    [Tooltip("准心后坐力的移动")]
    public class PostMove : FsmStateAction
    {
        [RequiredField]
        public FsmGameObject x;
        public FsmGameObject _X;
        public FsmGameObject y;
        public FsmGameObject _Y;

        public float time;

        public bool resetOnExit;

        private Vector2 xDefault;
        private Vector2 _xDefault;
        private Vector2 yDefault;
        private Vector2 _yDefault;
        private float timer;

        public override void Reset()
        {
            x = null;
            _X = null;
            y = null;
            _Y = null;
            time = 2f;
            resetOnExit = true;
        }
        // Code that runs on entering the state.
        public override void OnEnter()
        {
            xDefault = x.Value.transform.position;
            _xDefault = _X.Value.transform.position;
            yDefault = y.Value.transform.position;
            _yDefault = _Y.Value.transform.position;
            timer = 0;
            DoPostMove();
        }

        // Code that runs every frame.
        public override void OnUpdate()
        {
            timer += Time.deltaTime;
            DoPostMove();
        }

        void DoPostMove()
        {
            if(timer<=time)
            {
                float distance = Random.Range(-1, 3);
                x.Value.transform.position += new Vector3(distance, 0, 0);
                _X.Value.transform.position += new Vector3(-distance, 0, 0);
                y.Value.transform.position += new Vector3(0, distance, 0);
                _Y.Value.transform.position += new Vector3(0, -distance, 0);
            }
            else
            {
                float distance = Random.Range(-0.5f, 0.5f);
                x.Value.transform.position += new Vector3(distance, 0, 0);
                _X.Value.transform.position += new Vector3(-distance, 0, 0);
                y.Value.transform.position += new Vector3(0, distance, 0);
                _Y.Value.transform.position += new Vector3(0, -distance, 0);
            }

        }

        public override void OnExit()
        {
            if(resetOnExit)
            {
                x.Value.transform.position = xDefault;
                _X.Value.transform.position = _xDefault;
                y.Value.transform.position = yDefault;
                _Y.Value.transform.position = _yDefault;
            }
        }
    }

}
