using UnityEngine;
using TMPro;

public class GoalTextAutoHide : MonoBehaviour
{
    [Header("Message")]
    [TextArea] public string message = "Goal: Destroy all the bots!";

    [Header("Show window (seconds since scene load)")]
    public float showFrom = 0f;   // A
    public float showTo   = 3f;   // B

    [Tooltip("If true, uses real time (ignores Time.timeScale). "
           + "If false, uses game time (affected by pauses/slow-mo).")]
    public bool ignoreTimeScale = false;

    [Header("Auto-run")]
    public bool scheduleOnStart = true; // run A→B automatically on scene start

    TMP_Text label;
    float realtimeSceneStart; // baseline for unscaled time since scene load

    void Awake()
    {
        label = GetComponent<TMP_Text>();
        // lets us compute "unscaled seconds since scene load"
        realtimeSceneStart = Time.realtimeSinceStartup - Time.timeSinceLevelLoad;
    }

    void Start()
    {
        gameObject.SetActive(true);
        if (scheduleOnStart)
            ScheduleWindow(showFrom, showTo, message);
    }

    // Call this to schedule any custom window later
    public void ScheduleWindow(float from, float to, string text = null)
    {
        if (text != null && label) label.text = text;
        StopAllCoroutines();
        StartCoroutine(ShowBetween(from, to));
    }

    // Old API still supported: show immediately for N seconds (game time)
    public void Show(string text, float seconds)
    {
        if (label) label.text = text;
        ScheduleWindow(CurrentTime() , CurrentTime() + seconds, null);
    }

    System.Collections.IEnumerator ShowBetween(float from, float to)
    {
        if (to <= from) { gameObject.SetActive(false); yield break; }

        // wait until we reach 'from'
        while (CurrentTime() < from)
            yield return null;

        gameObject.SetActive(true);

        // stay visible until 'to'
        while (CurrentTime() < to)
            yield return null;

        gameObject.SetActive(false);
    }

    float CurrentTime()
    {
        if (!ignoreTimeScale)
            return Time.timeSinceLevelLoad; // game time

        // unscaled seconds since scene load
        return Time.realtimeSinceStartup - realtimeSceneStart;
    }
}
