using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Register : MonoBehaviour {
    private static string URL = "https://classdb.it.mtu.edu/~arfanten/SuperBroomball/register.php";

    //public GameObject UserAccount;

    public static InputField username;
    public static InputField password;

    public static void pressed() {
        string name = username.text;
        string pass = password.text;

        string hashedPass = MD5Hash.Md5Sum(pass);

        UserAccount.getInstance().StartCoroutine(registerAccount(name, hashedPass));
    }

    private static IEnumerator registerAccount(string name, string pass) {
        WWWForm form = new WWWForm();
        form.AddField("username", name);
        form.AddField("password", pass);

        WWW download = new WWW(URL, form);
        yield return download;

        if (!string.IsNullOrEmpty(download.error)) {
            Debug.Log("Error: " + download.error);
        } else {
            Debug.Log(download.text);

            //Login.pressed();
        }
    }
}
