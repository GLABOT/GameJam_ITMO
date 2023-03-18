using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorGame : MonoBehaviour
{
    public static ReactorGame instance = null;

    private ShowOrHideUI UIManager;

    private RectTransform StartPos;
    private RectTransform EndPos;
    private RectTransform SolveZone;

    private GameObject Pointer;

    private bool endReached;

    public bool miniGameStarted;
    private bool solveZoneGenerated;
    private bool canMovePointer;


    [SerializeField]
    private float speed;

    private void Start()
    {
        if (instance == null)
            instance = this;

        canMovePointer = true;
        StartPos = transform.GetChild(0).GetComponent<RectTransform>(); 
        EndPos = transform.GetChild(1).GetComponent<RectTransform>(); 
        Pointer = transform.GetChild(2).gameObject;
        SolveZone = transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();

        UIManager = GetComponent<ShowOrHideUI>();

    }

    private void Update()
    {

        if (miniGameStarted)
        {

            if (canMovePointer)
                StartCoroutine(MovePointerCoroutine());

            if (!solveZoneGenerated)
            {
                UIManager.Show();
                GenerateSolveZone();
            }
        }
    }

    

    private void GenerateSolveZone()
    {
        int randnum = Random.Range(-250, 250);
        SolveZone.localPosition = new Vector2(randnum, SolveZone.transform.localPosition.y);
        solveZoneGenerated = true;
    }

    private IEnumerator MovePointerCoroutine()
    {
        canMovePointer = false;
        Pointer.LeanMoveLocal(EndPos.localPosition, speed);
        endReached = false;
        yield return new WaitForSeconds(speed);
        endReached = true;
        Pointer.LeanMoveLocal(StartPos.localPosition, speed);
        yield return new WaitForSeconds(speed);
        canMovePointer = true;
    }
}
