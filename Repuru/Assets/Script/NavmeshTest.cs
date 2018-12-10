using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshTest : MonoBehaviour {

    public enum ENEMY_STATE {
        PATROL,
        CHASE,
    };

    public ENEMY_STATE _state;

    private NavMeshAgent _agent;
    [SerializeField] private Transform[] _patrol = null;
    [SerializeField] private Transform _tarPos = null;
    private int i = 0;

	// Use this for initialization
	void Start () {
		_agent = GetComponent < NavMeshAgent > ();
        _state = ENEMY_STATE.PATROL;
	}
	
	// Update is called once per frame
	void Update () {
        switch (_state) {
            case ENEMY_STATE.PATROL:
            if (_agent.remainingDistance <= 0.1f) {
                GoToNextPoint ();
                i++;
                if (i == _patrol.Length) {
                    i = 0;
                }
            }
            break;

            case ENEMY_STATE.CHASE:
            _agent.SetDestination (_tarPos.transform.position);
            break;

            default:
            break;
        }
	}

    void GoToNextPoint () {
		_agent.SetDestination (_patrol[i].transform.position);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.gameObject.tag == "Player") {
            _state = ENEMY_STATE.CHASE;
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.gameObject.tag == "Player") {
            _state = ENEMY_STATE.PATROL;
        }
    }
}
