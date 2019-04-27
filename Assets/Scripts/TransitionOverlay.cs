using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LD44Game
{
    public class TransitionOverlay : MonoBehaviour
    {
        [SerializeField] Image overlay;
        [SerializeField] Color color;
        [SerializeField] float duration = .5f;

        private void Awake()
        {
            overlay.color = color;
        }

        // Sets the fade. 1 being opaque, 0 being completely transparent
        public void SetFade(float fade)
        {
            Color color = overlay.color;
            color.a = fade;
            overlay.color = color;
        }

        // Sets the time it takes for fade to complete
        public void SetDuration(float duration)
        {
            this.duration = duration;
        }

        public Coroutine Fade(int target)
        {
            return StartCoroutine(FadeCoroutine(target));
        }

        IEnumerator FadeCoroutine(int target)
        {
            overlay.CrossFadeAlpha(target, duration, false);
            Debug.Log("Target: " + target + " Duration: " + duration);
            yield return new WaitForSeconds(duration);
        }
    }
}