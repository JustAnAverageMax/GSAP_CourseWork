using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Agent : MonoBehaviour
{
    public bool blendWeight = false;
    public bool blendPriority = false;
    public float priorityThreshold = 0.2f;
    public bool blendPipeline = false;
    public float maxSpeed;
    public float maxAccel;
    public float maxRotation;
    public float maxAngularAccel;
    public float orientation;
    public float rotation;
    public Vector3 velocity;
    protected Steering steering;
    [SerializeField] private GameObject player;
    private Dictionary<int, List<Steering>> groups;
    public bool isEnable = false;
	void Start ()
    {
        velocity = Vector3.zero;
        steering = new Steering();
        groups = new Dictionary<int, List<Steering>>();
	}
	public virtual void Update ()
    {
        if (isEnable)
        {
            transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
        }
    }
    public void SetSteering (Steering steering)
    {
        this.steering = steering;
    }

    public void SetSteering (Steering steering, float weight)
    {
        this.steering.linear += (weight * steering.linear);
        this.steering.angular += (weight * steering.angular);
    }
    public void SetSteering (Steering steering, int priority)
    {
        if (!groups.ContainsKey(priority))
        {
            groups.Add(priority, new List<Steering>());
        }
        groups[priority].Add(steering);
    }
    public void SetSteering (Steering steering, bool pipeline)
    {
        if (!pipeline)
        {
            this.steering = steering;
            return;
        }
    }
    private Steering GetPrioritySteering ()
    {
        Steering steering = new Steering();
        List<int> gIdList = new List<int>(groups.Keys);
        gIdList.Sort();
        foreach (int gid in gIdList)
        {
            steering = new Steering();
            foreach (Steering singleSteering in groups[gid])
            {
                steering.linear += singleSteering.linear;
                steering.angular += singleSteering.angular;
            }
            if (steering.linear.magnitude > priorityThreshold ||
                    Mathf.Abs(steering.angular) > priorityThreshold)
            {
                return steering;
            }
        }
        return steering;
    }
}
