using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolRobot : MonoBehaviour {

    public enum PATROL_ROBOT_STATE {
        PATROL,  //パトロール
        CHASE,   //追う
        RETURN,  //戻る
    };

    public PATROL_ROBOT_STATE _state;

    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _patrol = null;
    [SerializeField] private Transform _tarPos = null;
    [SerializeField] private Transform _prePos; //元の場所

    private int i = 0;

	// Use this for initialization
	void Start () {
		_agent = GetComponent < NavMeshAgent > ();
        _state = PATROL_ROBOT_STATE.PATROL;
	}
	
	// Update is called once per frame
	void Update () {
        switch (_state) {
            case PATROL_ROBOT_STATE.PATROL:   //パトロール
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f) {
                Invoke ("GoToNextPoint", 1f);
                i++;
                if (i == _patrol.Length) {
                    i = 0;
                }
            }
            break;

            case PATROL_ROBOT_STATE.CHASE:    //追う
            _agent.SetDestination (_tarPos.transform.position);
            break;

            case PATROL_ROBOT_STATE.RETURN:   //戻る
            _agent.SetDestination (_prePos.transform.position);
            if (transform.localPosition.x == _prePos.transform.localPosition.x) {
                i = 0;
                _state = PATROL_ROBOT_STATE.PATROL;
            }
            break;
        }
	}

    void GoToNextPoint () {
		_agent.SetDestination (_patrol[i].transform.position);
    }

    void OnTriggerEnter (Collider other) {
        //プレイヤーを発見したら
        if (other.gameObject.tag == "Player") {
            Debug.Log ("パトロールロボット：お前はもう死んでいる");
        }
    }
}
