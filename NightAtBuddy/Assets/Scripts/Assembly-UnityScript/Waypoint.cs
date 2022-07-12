using System;
using UnityEngine;

// Token: 0x02000006 RID: 6
[Serializable]
public class Waypoint : MonoBehaviour
{
	// Token: 0x06000019 RID: 25 RVA: 0x000044DC File Offset: 0x000026DC
	public Waypoint()
	{
		this.randomMinimumTime = 20f;
		this.randomMaximumTime = 50f;
		this.timeLeft = (float)360;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00004514 File Offset: 0x00002714
	public virtual void Update()
	{
		if (this.objectToMove.transform.position == this.transform.position && !this.lolo)
		{
			this.lolo = true;
			this.huhu = UnityEngine.Random.Range(1, 5);
			this.hoho = UnityEngine.Random.Range(1, 5);
			this.timeLeft = (float)UnityEngine.Random.Range(1, 5);
			this.time = true;
		}
		if (this.time)
		{
			this.timeLeft -= Time.deltaTime;
		}
		if (this.timeLeft < (float)0)
		{
			this.timeLeft = (float)0;
		}
		if (this.timeLeft == (float)0)
		{
			this.timeLeft = 0.1f;
			this.time = false;
			this.jojo = 3;
		}
		if (this.jojo == 3 && this.objectToMove.transform.position != this.forward.transform.position)
		{
			this.moveSpeed = 3;
			this.target = this.forward.transform;
			this.FollowTransform();
		}
		if (Vector3.Distance(this.objectToMove.transform.position, this.forward.transform.position) < 2.5f)
		{
			this.freeze = true;
		}
		if (Vector3.Distance(this.objectToMove.transform.position, this.forward.transform.position) > 2.5f)
		{
			this.freeze = false;
		}
		if (this.jojo == 3 && this.objectToMove.transform.position == this.forward.transform.position)
		{
			this.jojo = 0;
			if (this.lolo)
			{
				this.lolo = false;
			}
		}
		if (this.randomDirection != 0)
		{
			this.moveSpeed = 3;
			this.target = this.forward.transform;
			this.FollowTransform();
			((Waypoint)this.forward.GetComponent(typeof(Waypoint))).activated = true;
		}
		if (this.tictoc)
		{
			this.randomTime = (int)((float)this.randomTime - Time.deltaTime);
		}
		if (this.randomTime < 0)
		{
			this.randomTime = 0;
		}
		if (this.objectToMove.transform.position == this.transform.position && this.activated)
		{
			this.activated = false;
			this.randomTime = (int)UnityEngine.Random.Range(this.randomMinimumTime, this.randomMaximumTime);
			this.tictoc = true;
			if (this.tictoc && !this.picked)
			{
				this.randomDirection = UnityEngine.Random.Range(1, 5);
				this.tictoc = false;
			}
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000047EC File Offset: 0x000029EC
	public virtual void FollowTransform()
	{
		Debug.DrawLine(this.target.position, this.objectToMove.transform.position, Color.yellow);
		this.objectToMove.transform.rotation = Quaternion.Lerp(this.objectToMove.transform.rotation, this.target.rotation, (float)this.moveSpeed * Time.deltaTime);
		this.objectToMove.transform.position = Vector3.Lerp(this.objectToMove.transform.position, this.target.position, (float)this.moveSpeed * Time.deltaTime);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00004898 File Offset: 0x00002A98
	public virtual void Main()
	{
	}

	// Token: 0x0400005F RID: 95
	public GameObject objectToMove;

	// Token: 0x04000060 RID: 96
	public GameObject forward;

	// Token: 0x04000061 RID: 97
	public GameObject backward;

	// Token: 0x04000062 RID: 98
	public GameObject left;

	// Token: 0x04000063 RID: 99
	public GameObject right;

	// Token: 0x04000064 RID: 100
	public int moveSpeed;

	// Token: 0x04000065 RID: 101
	public float randomMinimumTime;

	// Token: 0x04000066 RID: 102
	public float randomMaximumTime;

	// Token: 0x04000067 RID: 103
	public int randomTime;

	// Token: 0x04000068 RID: 104
	public int randomDirection;

	// Token: 0x04000069 RID: 105
	public bool activated;

	// Token: 0x0400006A RID: 106
	public bool tictoc;

	// Token: 0x0400006B RID: 107
	public bool picked;

	// Token: 0x0400006C RID: 108
	public int rotationSpeed;

	// Token: 0x0400006D RID: 109
	private Transform target;

	// Token: 0x0400006E RID: 110
	public bool lolo;

	// Token: 0x0400006F RID: 111
	public int huhu;

	// Token: 0x04000070 RID: 112
	public int hoho;

	// Token: 0x04000071 RID: 113
	public bool time;

	// Token: 0x04000072 RID: 114
	public float timeLeft;

	// Token: 0x04000073 RID: 115
	public int jojo;

	// Token: 0x04000074 RID: 116
	public bool freeze;
}
