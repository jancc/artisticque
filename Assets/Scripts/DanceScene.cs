using UnityEngine;
using System.Collections;

public class DanceScene : MonoBehaviour {

    bool display;
    public AudioSource normalMusic;
    public AudioSource dubstepMusic;
    public Texture2D[] pictures;
    public int currentPicture;
    public float initialPictureSpeed;
    public float finalPictureSpeed;
    public float finalMusicPitch;
    public float pictureSpeed;

    IEnumerator PlayAnimation()
    {
        yield return new WaitForSeconds(pictureSpeed);

        for (int i = 1; i < pictures.Length; i++)
        {
            currentPicture++;
            float t = (float)i / (float)(pictures.Length);
            pictureSpeed = Mathf.Lerp(initialPictureSpeed, finalPictureSpeed, t);
            dubstepMusic.pitch = Mathf.Lerp(1.0f, finalMusicPitch, t);
            yield return new WaitForSeconds(pictureSpeed);
        }

        Application.LoadLevel("Ingame2");

    }

	void OnStoryTrigger () {

        display = true;
        currentPicture = 0;
        pictureSpeed = initialPictureSpeed;
        normalMusic.volume = 0.0f;
        StartCoroutine("PlayAnimation");

	}

    void OnGUI()
    {
        if (!display)
            return;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), pictures[currentPicture]);
    }
}
