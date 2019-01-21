using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PoliceRobot : MonoBehaviour {

    private enum POLICE_ROBOT_STATE
    {
        LOOKOUT, //見張り
        CHASE,   //追う
        RETURN,  //戻る
    }

    private POLICE_ROBOT_STATE _state;

    private NavMeshAgent _agent;

    [SerializeField] private Transform _tarPos; //プレイヤー
    [SerializeField] private Transform _prePos; //元の場所

    // Use this for initialization
    void Start () {
        _agent = GetComponent < NavMeshAgent > ();
        _state = POLICE_ROBOT_STATE.LOOKOUT;
    }

    //初期化
    void Initialization () {
        transform.rotation = _prePos.rotation;
    }

    // Update is called once per frame
    void Update () {
        switch (_state) {
            case POLICE_ROBOT_STATE.LOOKOUT:  //見張り
            break;

            case POLICE_ROBOT_STATE.CHASE:    //追う
            _agent.SetDestination (_tarPos.transform.position);
            break;

            case POLICE_ROBOT_STATE.RETURN:   //戻る
            _agent.SetDestination (_prePos.transform.position);

            //見張りの場所に戻ったら
            if (transform.localPosition.x == _prePos.transform.localPosition.x) {
                _state = POLICE_ROBOT_STATE.LOOKOUT;
                Initialization ();
            }
            break;
        }
    }

    void OnTriggerEnter (Collider other) {
        //プレイヤーを発見したら
        if (other.gameObject.tag == "Player") {
            _state = POLICE_ROBOT_STATE.CHASE;　//追う
            FindObjectOfType < StopRobot > ()._state = StopRobot.STOP_ROBOT_STATE.CHASE;
            FindObjectOfType < PatrolRobot > ()._state = PatrolRobot.PATROL_ROBOT_STATE.CHASE;
            Debug.Log ("止まれ！！逃がすな！");
        }
    }

    void OnTriggerExit (Collider other) {
        //プレイヤーを見失ったら
        if (other.gameObject.tag == "Player") {
            _state = POLICE_ROBOT_STATE.RETURN; //戻る
            FindObjectOfType < StopRobot > ()._state = StopRobot.STOP_ROBOT_STATE.RETURN;
            FindObjectOfType < PatrolRobot > ()._state = PatrolRobot.PATROL_ROBOT_STATE.RETURN;
            Debug.Log ("ちっ、見失ったか");
        }
    }
}

