using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreUI : MonoBehaviour {
    [SerializeField] GameObject highscoreUIElementPrefab;
    [SerializeField] Transform elementWrapper;

    List<GameObject> uiElements = new List<GameObject> ();

    private void OnEnable () {
        HighScoreHanderler.onHighscoreListChanged += UpdateUI;
    }

    private void OnDisable () {
        HighScoreHanderler.onHighscoreListChanged -= UpdateUI;
    }
    private void UpdateUI (List<HighScoreElement> list) {
        for (int i = 0; i < list.Count; i++) {
            HighScoreElement el = list[i];

            if (el != null && el.Point > 0) {
                if (i >= uiElements.Count) {
                    // instantiate new entry
                    var inst = Instantiate (highscoreUIElementPrefab, Vector3.zero, Quaternion.identity);
                    inst.transform.SetParent (elementWrapper, false);

                    uiElements.Add (inst);
                }

                // write or overwrite name & points
                var texts = uiElements[i].GetComponentsInChildren<Text> ();
                texts[0].text = (i+1).ToString();
                texts[1].text = el.playerName;
                texts[2].text = el.Point.ToString ();
            }
        }
    }

}