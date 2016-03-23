using UnityEngine;
using System.Collections;

/*
 * Holds user account information so we
 * know who's logged indexer.
 */
public class UserAccount : MonoBehaviour {
	private bool loggedIn = false;

	private int uID;
	private string username;

    public static UserAccount instance;

	/* This string is changed on each successful login.
	 * It's used to validate that a person is who they
	 * say they are.
	 */
	private string sessionCode;

    private void Awake() {
        instance = this;
    }

    public static UserAccount getInstance() {
        return instance;
    }

	public int getUID() {
		return uID;
	}

	public string getUsername() {
		return username;
	}

	public string getSessionCode() {
		return sessionCode;
	}

	public bool isLoggedIn() {
		return loggedIn;
	}

	GameObject LogIn;
	GameObject LogOut;
	private void Start() {
		LogIn = transform.GetChild(0).gameObject;
		LogOut = transform.GetChild(1).gameObject;
	}

	public void logIn() {
        LogIn.SetActive(false);
        LogOut.SetActive(true);
	}

    public void logOut() {
        LogIn.SetActive(true);
        LogOut.SetActive(false);
    }
}
