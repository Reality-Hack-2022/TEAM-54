using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Normal.Realtime;

public class ControllerSwitcher : MonoBehaviour
{
  public GameObject XROrigin;
  public RealtimeAvatarManager realtimeAvatarManager;
  public bool XRActive = false;
  public GameObject nightVision;
  public GameObject nightLight;
  public Transform spawnLocation;
  public GameObject CatPlayer;
  public Realtime realtime;
  public AudioSync audioSync;
  public GameObject flashLight;
  
  private bool spawned;


  void Start()
  {
    if(XRActive) {
        XROrigin.SetActive(true);
        nightVision.SetActive(false);
        nightLight.SetActive(false);
    } else {
        XROrigin.SetActive(false);
        realtimeAvatarManager.enabled = false;
        nightVision.SetActive(true);
        nightLight.SetActive(true);
        flashLight.GetComponent<ParallelMovement>().enabled = false;
    }
  }
  void Update()
  {
    if(!spawned && !XRActive && realtime.connected) {
      spawned = true;
      GameObject catPlayer = Instantiate(CatPlayer, spawnLocation.position, spawnLocation.rotation);
      //GameObject pointLight = Instantiate(catPointLight, spawnLocation.position, spawnLocation.rotation);
     //pointLight.parent = catPlayer;
      GameObject catModel = Realtime.Instantiate("CatModel", spawnLocation.position, spawnLocation.rotation);
      catPlayer.GetComponentInChildren<ParallelMovement>().SetOther(catModel.transform.GetChild(0));
      catPlayer.GetComponent<CatController>().SetCatModel(catModel);
      catPlayer.GetComponent<cat>().SetCatModel(catModel);
      catPlayer.GetComponent<CatSounds>().SetAudioSync(audioSync);
      flashLight.SetActive(true);
    }
    if(!spawned && XRActive && realtime.connected) {
      spawned = true;
      flashLight.GetComponent<RealtimeTransform>().RequestOwnership();
    }
  }
}