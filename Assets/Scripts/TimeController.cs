using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float dayDuration = 1800f; // 30 Minuten für 1 Ingame-Tag
    private Light sun;
    private float time;
    public NPCController[] npcs;

    void Start()
    {
        sun = GetComponent<Light>();
    }

    void Update()
    {
        time += Time.deltaTime;
        float rotation = (time / dayDuration) * 360f;
        sun.transform.rotation = Quaternion.Euler(rotation - 90, 0, 0);

        AdjustLighting();
        ControlNPCs();
    }

    void AdjustLighting()
    {
        float intensity = Mathf.Clamp01(Mathf.Cos(sun.transform.rotation.eulerAngles.x * Mathf.Deg2Rad));
        sun.intensity = intensity;
    }

    void ControlNPCs()
    {
        if (time < dayDuration / 2) 
        {
            foreach (NPCController npc in npcs) { npc.StartNPC(); }
        }
        else 
        {
            foreach (NPCController npc in npcs) { npc.StopNPC(); }
        }
    }
}