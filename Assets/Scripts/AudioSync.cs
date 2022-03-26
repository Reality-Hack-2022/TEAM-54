using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class AudioSync : RealtimeComponent<AudioModel>
{
    public AudioClip[] multiplayerClips;

    protected override void OnRealtimeModelReplaced(AudioModel previousModel, AudioModel currentModel) {
        if (previousModel != null) {
            // Unregister from events
            previousModel.incrementDidChange -= AudioChanged;
        }
        
        if (currentModel != null) {
            // Register for events so we'll know if the color changes later
            currentModel.incrementDidChange += AudioChanged;
        }
    }

    private void AudioChanged(AudioModel model, int value) {
        Debug.Log("inc: "+ model.increment);
        Debug.Log("ind: "+ model.audioClipIndex);
        Debug.Log("position: "+ model.worldPosition);
        PlayCurrentAudio();
    }

    private void PlayCurrentAudio() {
        AudioSource.PlayClipAtPoint(multiplayerClips[model.audioClipIndex], model.worldPosition);
    }

    public void PlayClip(int clipIndex, Vector3 position) {
        model.audioClipIndex = clipIndex;
        model.worldPosition = position;
        model.increment += 1;
    }
}
