using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class PanelManager : MonoBehaviour {

	public Animator initiallyOpen;

	private int m_OpenParameterId;
	private Animator m_Open;
	private GameObject m_PreviouslySelected;

	const string k_OpenTransitionName = "Open";
	const string k_ClosedStateName = "Closed";
	[SerializeField] GameObject menu;
	
	private GameObject main;
	private Animator main_anim;
	private GameObject controller;
	private Animator controller_anim;
	private GameObject window;
	private Animator window_anim;
	private GameObject window2;
	private Animator window2_anim;
	private GameObject audio;
	private Animator audio_anim;

	private void Start()
	{
		main = menu.transform.GetChild(0).GetChild(6).gameObject;
		main_anim = main.GetComponent<Animator>();

		controller = menu.transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
		controller_anim = controller.GetComponent<Animator>();

		window = menu.transform.GetChild(0).GetChild(3).gameObject;
		window_anim = window.GetComponent<Animator>();

		window2 = menu.transform.GetChild(0).GetChild(4).gameObject;
		window2_anim = window2.GetComponent<Animator>();

		audio = menu.transform.GetChild(0).GetChild(0).GetChild(1).gameObject;
		audio_anim = audio.GetComponent<Animator>();
	}

	public void OnEnable()
	{
		m_OpenParameterId = Animator.StringToHash (k_OpenTransitionName);

		if (initiallyOpen == null)
			return;

		OpenPanel(initiallyOpen);
	}

	public void OpenPanel (Animator anim)
	{
		if (m_Open == anim)
			return;

		anim.gameObject.SetActive(true);
		var newPreviouslySelected = EventSystem.current.currentSelectedGameObject;

		anim.transform.SetAsLastSibling();

		CloseCurrent();

		m_PreviouslySelected = newPreviouslySelected;

		m_Open = anim;
		m_Open.SetBool(m_OpenParameterId, true);

		GameObject go = FindFirstEnabledSelectable(anim.gameObject);

		SetSelected(go);
	}

	static GameObject FindFirstEnabledSelectable (GameObject gameObject)
	{
		GameObject go = null;
		var selectables = gameObject.GetComponentsInChildren<Selectable> (true);
		foreach (var selectable in selectables) {
			if (selectable.IsActive () && selectable.IsInteractable ()) {
				go = selectable.gameObject;
				break;
			}
		}
		return go;
	}

	public void CloseCurrent()
	{
		if (m_Open == null)
			return;

		m_Open.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(m_Open));
		m_Open = null;
	}

	public void CloseCurrent(Animator anim)
	{
		if (anim.gameObject == null)
			return;

		anim.SetBool(m_OpenParameterId, false);
		SetSelected(m_PreviouslySelected);
		StartCoroutine(DisablePanelDeleyed(anim));
	}

	IEnumerator DisablePanelDeleyed(Animator anim)
	{
		bool closedStateReached = false;
		bool wantToClose = true;
		while (!closedStateReached && wantToClose)
		{
			if (!anim.IsInTransition(0))
				closedStateReached = anim.GetCurrentAnimatorStateInfo(0).IsName(k_ClosedStateName);

			wantToClose = !anim.GetBool(m_OpenParameterId);

			yield return new WaitForEndOfFrame();
		}

		if (wantToClose)
			anim.gameObject.SetActive(false);
	}

	private void SetSelected(GameObject go)
	{
		EventSystem.current.SetSelectedGameObject(go);
	}

	public void CloseAll()
	{
		main_anim.SetBool("Open", false);

		if (controller_anim != null)
			CloseCurrent(controller_anim);

		if (window_anim != null)
			CloseCurrent(window_anim);

		if (window2_anim != null)
			CloseCurrent(window2_anim);

		if (audio_anim != null)
			CloseCurrent(audio_anim);

		m_Open = null;
	}
}
