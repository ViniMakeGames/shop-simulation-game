using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class DialogueBoxUI : MonoBehaviour
    {
        [SerializeField] private float _textAnimationSpeed = 1f;

        private List<string> _textToDisplay;

        private bool _displayingTextAnimation;

        [SerializeField] private TextMeshProUGUI _textUI;

        public void DisplayText(string text) => DisplayText(new List<string>() { text });
        public void DisplayText(List<string> text)
        {
            gameObject.SetActive(true);
            _textToDisplay = text;
            StartCoroutine(DisplayTextAnimation());
        }

        private IEnumerator DisplayTextAnimation()
        {
            _displayingTextAnimation = true;
            
            var text = _textToDisplay[0];
            _textToDisplay.RemoveAt(0);

            var lettersDisplayed = 0;
            var totalLetters = text.Length;

            _textUI.text = text;
            _textUI.maxVisibleCharacters = 0;
            
            while (lettersDisplayed < totalLetters)
            {
                var t = 0f;
                while (t < 1f)
                {
                    t += _textAnimationSpeed * Time.deltaTime;
                    yield return null;
                }
                
                lettersDisplayed++;
                _textUI.maxVisibleCharacters = lettersDisplayed;
                yield return null;
            }

            _displayingTextAnimation = false;
        }

        public bool NextDialogue()
        {
            if (_displayingTextAnimation)
            {
                _displayingTextAnimation = false;
                StopAllCoroutines();
                _textUI.maxVisibleCharacters = _textUI.text.Length;
                return true;
            }

            if (_textToDisplay.Count <= 0)
            {
                gameObject.SetActive(false);
                return false;
            }
            
            StartCoroutine(DisplayTextAnimation());
            return true;
        }
    }
}
