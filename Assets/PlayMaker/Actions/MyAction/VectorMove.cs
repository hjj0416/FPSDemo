using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

[ActionCategory("MyAction")]
    [Tooltip("移动指定的Vector3向量位置")]
    public class VectorMove : FsmStateAction
{
        [RequiredField]
        [Tooltip("The GameObject to position.")]
        public FsmOwnerDefault gameObject;

        public FsmVector3 vector;

        public Space space;

        public override void Reset()
        {
            gameObject = null;
            vector = null;

            space = Space.Self;
        }

        // Code that runs on entering the state.
        public override void OnEnter()
	{
            DoMoveVector();
	}

	// Code that runs every frame.
	public override void OnUpdate()
	{
		
	}
        void DoMoveVector()
        {
            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            if(go==null)
            {
                return;
            }
            Vector3 position;

            if(vector.IsNone)
            {
                position = space == Space.World ? go.transform.position : go.transform.localPosition;
            }
            else
            {
                position = vector.Value;
            }

        }

}

}
