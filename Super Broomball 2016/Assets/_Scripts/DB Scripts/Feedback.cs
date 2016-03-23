using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Feedback : MonoBehaviour {
    public static Text feedbackString;

    public static void setFeedback(string str) {
        feedbackString.text = "*" + str + "*";
    }

    public static string getFeedback() {
        return feedbackString.text;
    }
}
