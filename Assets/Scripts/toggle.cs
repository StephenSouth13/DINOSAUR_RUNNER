using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class Toggle : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer; // Mixer âm thanh để điều chỉnh âm lượng
    [SerializeField] private Toggle muteToggle;      // Toggle để bật/tắt âm thanh

    private void Start()
    {
        // Đặt trạng thái ban đầu cho toggle từ mixer
        float currentVolume;
        audioMixer.GetFloat("MasterVolume", out currentVolume);
        muteToggle.isOn = currentVolume <= -80f; // Giả sử -80 là mức tắt tiếng
    }

    public void ToggleMute(bool isMuted)
    {
        // Cập nhật giá trị âm lượng trong mixer
        if (isMuted)
        {
            audioMixer.SetFloat("MasterVolume", -80f); // Tắt tiếng
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", 0f); // Bật tiếng về mức bình thường
        }
    }
}