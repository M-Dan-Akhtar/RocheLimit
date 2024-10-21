using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReportBug : MonoBehaviour
{
    public void OpenReportForm(){
        Application.OpenURL("https://docs.google.com/forms/d/1DxLnIiXgiS9QOjuHSF4elq3vRDFLG7o0IK-X3okBRps/edit");
    }
}
