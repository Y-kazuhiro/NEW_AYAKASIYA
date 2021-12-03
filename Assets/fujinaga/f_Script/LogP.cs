using System.Collections;
using System.Collections.Generic; // Queue�̂��߂ɕK�v
using UnityEngine;
using System.Text; // StringBuilder�̂��߂ɕK�v

public class LogP : MonoBehaviour
{
    // ���O�����܂ŕێ����邩
    [SerializeField] int m_MaxLogCount = 20;

    // �\���̈�
    [SerializeField] Rect m_Area = new Rect(220, 0, 400, 400);

    // ���O�̕���������Ă������߂�Queue
    Queue<string> m_LogMessages = new Queue<string>();

    // ���O�̕��������������̂Ɏg��
    StringBuilder m_StringBuilder = new StringBuilder();

    void Start()
    {
        // Application.logMessageReceived�Ɋ֐���o�^���Ă����ƁA
        // ���O���o�͂����ۂɌĂ�ł����
        Application.logMessageReceived += LogReceived;
    }

    // ���O���o�͂����ۂɌĂ�ł��炤�֐�
    void LogReceived(string text, string stackTrace, LogType type)
    {
        // ���O��Queue�ɒǉ�
        m_LogMessages.Enqueue(text);

        // ���O�̌�������𒴂��Ă�����A�ŌÂ̂��̂��폜����
        while (m_LogMessages.Count > m_MaxLogCount)
        {
            m_LogMessages.Dequeue();
        }
    }

    void OnGUI()
    {
        // StringBuilder�̓��e�����Z�b�g
        m_StringBuilder.Length = 0;

        // ���O�̕��������������i1���Ƃɖ����ɉ��s��ǉ��j
        foreach (string s in m_LogMessages)
        {
            m_StringBuilder.Append(s).Append(System.Environment.NewLine);
        }

        // ��ʂɕ\��
        GUI.Label(m_Area, m_StringBuilder.ToString());
    }
}