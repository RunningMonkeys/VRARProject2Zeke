using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


/// <summary>
/// This class implements the IVirtualButtonEventHandler interface and
/// contains the logic to start animations depending on what 
/// virtual button has been pressed.
/// </summary>
public class buttonAnimation : MonoBehaviour
{
    #region PUBLIC_MEMBERS
	public Animator meAni;
	public AudioSource ach;
	public GameObject virtualB;
    #endregion // PUBLIC_MEMBERS


    #region MONOBEHAVIOUR_METHODS
    void Start()
    {
        virtualB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        virtualB.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
       
    }
	
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			OnButtonPressed(virtualB.GetComponent<VirtualButtonBehaviour>());
		}
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			OnButtonReleased(virtualB.GetComponent<VirtualButtonBehaviour>());
		}
		
	}




    #endregion // MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS
    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
		meAni.Play("Dodge");
		ach.Play();
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);
    }

    /// <summary>
    /// Called when the virtual button has just been released:
    /// </summary>
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
		meAni.Play("Sitting");
        Debug.Log("OnButtonReleased: " + vb.VirtualButtonName);
    }
    #endregion //PUBLIC_METHODS
}
