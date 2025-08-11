using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Mixer âm thanh để điều chỉnh âm lượng
    [SerializeField] private Slider volumeSlider;    // Slider để điều chỉnh âm lượng

    private void Start()
    {
        // Đặt giá trị ban đầu cho slider từ mixer
        float currentVolume;
        audioMixer.GetFloat("MasterVolume", out currentVolume);
        volumeSlider.value = currentVolume;
    }

    public void SetVolume(float volume)
    {
        // Cập nhật giá trị âm lượng trong mixer
        audioMixer.SetFloat("MasterVolume", volume);
    }
}