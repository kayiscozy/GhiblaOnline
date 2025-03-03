using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypoint = 0;
    private bool isMoving = true;
    public string[] morningDialog;
    public string[] nightDialog;
    private DialogSystem dialogSystem;

    void Start()
    {
        dialogSystem = FindObjectOfType<DialogSystem>();
    }

    void Update()
    {
        MoveNPC();
    }

    void MoveNPC()
    {
        if (waypoints.Length == 0 || !isMoving) return;

        Transform target = waypoints[currentWaypoint];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }
    }

    public void StopNPC() { isMoving = false; }
    public void StartNPC() { isMoving = true; }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (TimeController.IsDayTime())
            {
                dialogSystem.StartDialog(morningDialog);
            }
            else
            {
                dialogSystem.StartDialog(nightDialog);
            }
        }
    }
}