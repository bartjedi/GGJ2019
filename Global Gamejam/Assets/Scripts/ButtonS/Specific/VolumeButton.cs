using UnityEngine;

public class VolumeButton : ButtonScript
{
    /// <summary>
    /// Call this function to trigger the specific event for this button
    /// </summary>
	override public void Trigger(GameObject player)
    {
        base.Break();
        AudioManager.instance.CrazyAudio();
    }
}