/*
write by haoboxuxu
personal blog : www.haoboxuxu.top
*/
using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class Barrel : MonoBehaviour
{
    public Shader curShader;
    private Material curMaterial;
    public float Intensity_x = 0;
    public float Intensity_y = 0;
    public float P_x = 1.0f;
    public float P_y = 1.0f;
	public float distortion = (float)-0.7;
	public float cubicDistortion = (float)0.4;
    public float scale = 1;
    #region Properties
    Material material
    {
        get
        {
            if (curMaterial == null)
            {
                curMaterial = new Material(curShader);
                curMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            return curMaterial;
        }
    }
    #endregion

	void Start()
	{
		curShader = Shader.Find ("Custom/Barrel");
		if (!SystemInfo.supportsImageEffects)
		{
			enabled = false;
			return;
		}

		if (!curShader && !curShader.isSupported)
		{
			enabled = false;
		}
	}
	void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (curShader != null)
		{
			Graphics.Blit(sourceTexture, destTexture, material);
		}
		else
		{
			Graphics.Blit(sourceTexture, destTexture);
		}
	}
    void Update()
    {
        material.SetFloat("_Intensity_x", Intensity_x);
        material.SetFloat("_Intensity_y", Intensity_y);
        material.SetFloat("_P_x", P_x);
        material.SetFloat("_P_y", P_y);
        material.SetFloat("_distortion", distortion);
        material.SetFloat("_cubicDistortion", cubicDistortion);
        material.SetFloat("_scale", scale);
    }
    void OnDisable()
    {
        if (curMaterial)
        {
            DestroyImmediate(curMaterial);
        }
    }
}
