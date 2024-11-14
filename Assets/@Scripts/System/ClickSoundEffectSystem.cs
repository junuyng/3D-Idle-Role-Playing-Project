
    using UnityEngine;
    using UnityEngine.UI;

    public class ClickSoundEffectSystem
    {
        
        private AudioSource source;
        private AudioClip clip;
 
        public ClickSoundEffectSystem(Button button,AudioSource source , AudioClip clip)
        {

            this.source = source;
            this.clip = clip;
            button.onClick.AddListener(PlaySoundEffect);
        }

        public void PlaySoundEffect()
        {
            source.PlayOneShot(clip);
        }
    }
