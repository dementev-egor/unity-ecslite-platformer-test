namespace DefaultNamespace
{
    public static class Extensions
    {
        public static System.Numerics.Vector3 ToSystemV3(this UnityEngine.Vector3 v)
        {
            return new System.Numerics.Vector3(v.x, v.y, v.z);
        }
        
        public static UnityEngine.Vector3 ToUnityV3(this System.Numerics.Vector3 v)
        {
            return new UnityEngine.Vector3(v.X, v.Y, v.Z);
        }
    }
}