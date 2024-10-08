using UnityEngine;

// ����� �� ����
public class QuitGame : MonoBehaviour
{
    // ������ ������ �� ����
    public KeyCode quitKey;

    void Update()
    {
        if (Input.GetKeyDown(quitKey))
            Quit();
    }

    // ������� ������ �� ���� (� ����������� �� ���� ��� �������� ����)
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
    }
}
