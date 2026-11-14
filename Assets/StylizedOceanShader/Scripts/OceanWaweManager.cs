using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanWaweManager : MonoBehaviour
{


 

    


    public Material waterMat;
   
    public void Update()
    {
        waterMat.SetFloat("_GlobalTime", Time.timeSinceLevelLoad);
       
    }

  
   public Vector3 gersnerWaweReturn(Vector3 Pos)
    {
        return gerstnerDisplacement(Pos, waterMat.GetFloat("_Phase"), waterMat.GetFloat("_Gravity"), waterMat.GetFloat("_Depth"), waterMat.GetVector("_Direction1"), waterMat.GetVector("_Direction2"), waterMat.GetVector("_Direction3"), waterMat.GetVector("_Direction4"), waterMat.GetFloat("_Amplitude1"), waterMat.GetFloat("_Amplitude2"), waterMat.GetFloat("_Amplitude3"), waterMat.GetFloat("_Amplitude4"), waterMat.GetVector("_TimeScale") * Time.timeSinceLevelLoad * waterMat.GetFloat("_MasterTime"));
    }


    public static float frequancy(float gravity,Vector3 Direction,float Depth)
    {
        float freq = Mathf.Sqrt((gravity * Direction.magnitude) * (float)System.Math.Tanh((double)(Depth * Direction.magnitude)));
        return freq;
    }


    public static float theta(Vector3 Position,float Phase,float gravity, Vector3 Direction, float Depth,float amplitude,float time)
    {
        float th = ((Direction.x * Position.x + Direction.z * Position.z) - (frequancy(gravity, Direction, Depth) * time)) - Phase;
        return th;
    }
    public static Vector3 gerstnerWawe(Vector3 Position, float Phase, float gravity, Vector3 Direction, float Depth, float amplitude, float time)
    {
        float Theta = theta(Position, Phase, gravity, Direction, Depth, amplitude, time);

        float x =( Mathf.Sin(Theta) *  ((Direction.x - Direction.magnitude) * amplitude /(float)System.Math.Tanh((double)(Depth * Direction.magnitude)))) * -1;
        float y = Mathf.Cos(Theta) * amplitude;
        float z = (Mathf.Sin(Theta) * ((Direction.z - Direction.magnitude) * amplitude / (float)System.Math.Tanh((double)(Depth * Direction.magnitude)))) * -1;

        return new Vector3(x, y, z);
    }

    public Vector3 gerstnerDisplacement(Vector3 Position,float Phase,float Gravity,float Depth,Vector3 Direction1, Vector3 Direction2, Vector3 Direction3, Vector3 Direction4,float Amplitude1, float Amplitude2, float Amplitude3, float Amplitude4,Vector4 TimeScale)
    {
        Vector3 Displace = gerstnerWawe(Position, Phase, Gravity, Direction1, Depth, Amplitude1 * waterMat.GetFloat("_MasterAmplitude"), TimeScale.x) + gerstnerWawe(Position, Phase, Gravity, Direction2, Depth, Amplitude2 * waterMat.GetFloat("_MasterAmplitude"), TimeScale.y) + gerstnerWawe(Position, Phase, Gravity, Direction3, Depth, Amplitude3 * waterMat.GetFloat("_MasterAmplitude"), TimeScale.z) + gerstnerWawe(Position, Phase, Gravity, Direction4, Depth, Amplitude4 * waterMat.GetFloat("_MasterAmplitude"), TimeScale.w);
        return Displace + Position;
    }

}
