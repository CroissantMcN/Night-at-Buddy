using System;
using UnityEngine;

// Token: 0x02000004 RID: 4
[Serializable]
public class PowerUsage : MonoBehaviour
{
	// Token: 0x06000010 RID: 16 RVA: 0x00003048 File Offset: 0x00001248
	public PowerUsage()
	{
		this.battery = (float)256;
		this.time = (float)360;
		this.timeString = "12:00 AM";
		this.havePower = true;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x00003088 File Offset: 0x00001288
	public virtual void Start()
	{
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000308C File Offset: 0x0000128C
	public virtual void Update()
	{
		this.time -= Time.deltaTime;
		this.timeInteger = (int)this.time;
		if (this.time > (float)300 && this.time < (float)360)
		{
			this.timeString = "12:00 AM";
		}
		if (this.time > (float)240 && this.time < (float)300)
		{
			this.timeString = "1:00 AM";
		}
		if (this.time > (float)180 && this.time < (float)240)
		{
			this.timeString = "2:00 AM";
		}
		if (this.time > (float)120 && this.time < (float)180)
		{
			this.timeString = "3:00 AM";
		}
		if (this.time > (float)60 && this.time < (float)120)
		{
			this.timeString = "4:00 AM";
		}
		if (this.time > (float)0 && this.time < (float)60)
		{
			this.timeString = "5:00 AM";
		}
		if (this.time < (float)0)
		{
			this.time = (float)0;
			this.timeString = "6:00 AM";
		}
		if (((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.newDoorLcounter = 1;
		}
		if (!((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.newDoorLcounter = 0;
		}
		if (((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.newDoorRcounter = 1;
		}
		if (!((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.newDoorRcounter = 0;
		}
		this.usageCounter = this.newDoorLcounter + this.newDoorRcounter + ((ShowHideCameraButton)this.GetComponent(typeof(ShowHideCameraButton))).lightLcounter + ((ShowHideCameraButton)this.GetComponent(typeof(ShowHideCameraButton))).lightRcounter;
		this.battery -= Time.deltaTime * 0.25f;
		if (((ShowHideCameraButton)this.GetComponent(typeof(ShowHideCameraButton))).weAreWatching)
		{
			this.battery -= Time.deltaTime * 0.5f;
		}
		if (((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.battery -= Time.deltaTime;
		}
		if (((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.battery -= Time.deltaTime;
		}
		if (((Light)this.lightL.GetComponent(typeof(Light))).enabled)
		{
			this.battery -= Time.deltaTime * (float)this.usageCounter;
		}
		if (((Light)this.lightR.GetComponent(typeof(Light))).enabled)
		{
			this.battery -= Time.deltaTime * (float)this.usageCounter;
		}
		if (this.battery != (float)0)
		{
			if (this.usageCounter == 0)
			{
				this.batteryUsageGreen.GetComponent<Renderer>().enabled = false;
				this.batteryUsageYellow.GetComponent<Renderer>().enabled = false;
				this.batteryUsageOrange.GetComponent<Renderer>().enabled = false;
				this.batteryUsageRed.GetComponent<Renderer>().enabled = false;
			}
			if (this.usageCounter == 1)
			{
				this.batteryUsageGreen.GetComponent<Renderer>().enabled = true;
				this.batteryUsageYellow.GetComponent<Renderer>().enabled = false;
				this.batteryUsageOrange.GetComponent<Renderer>().enabled = false;
				this.batteryUsageRed.GetComponent<Renderer>().enabled = false;
			}
			if (this.usageCounter == 2)
			{
				this.batteryUsageGreen.GetComponent<Renderer>().enabled = true;
				this.batteryUsageYellow.GetComponent<Renderer>().enabled = true;
				this.batteryUsageOrange.GetComponent<Renderer>().enabled = false;
				this.batteryUsageRed.GetComponent<Renderer>().enabled = false;
			}
			if (this.usageCounter == 3)
			{
				this.batteryUsageGreen.GetComponent<Renderer>().enabled = true;
				this.batteryUsageYellow.GetComponent<Renderer>().enabled = true;
				this.batteryUsageOrange.GetComponent<Renderer>().enabled = true;
				this.batteryUsageRed.GetComponent<Renderer>().enabled = false;
			}
			if (this.usageCounter == 4)
			{
				this.batteryUsageGreen.GetComponent<Renderer>().enabled = true;
				this.batteryUsageYellow.GetComponent<Renderer>().enabled = true;
				this.batteryUsageOrange.GetComponent<Renderer>().enabled = true;
				this.batteryUsageRed.GetComponent<Renderer>().enabled = true;
			}
			if (this.usageCounter < 0)
			{
				this.usageCounter = 0;
			}
			if (this.usageCounter > 4)
			{
				this.usageCounter = 4;
			}
			if (this.battery < (float)0)
			{
				this.battery = (float)0;
			}
		}
		if (this.battery == (float)0 && this.havePower)
		{
			this.havePower = false;
			this.lightGlobal.GetComponent<Light>().enabled = false;
			this.lightLocal.GetComponent<Light>().GetComponent<Light>().intensity = 0.4f;
			this.lightLocal.GetComponent<AudioSource>().clip = this.noPowerSound;
			this.lightLocal.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x0000364C File Offset: 0x0000184C
	public virtual void OnGUI()
	{
		int num = (int)this.battery;
		GUI.Label(new Rect((float)10, (float)(Screen.height - 32), (float)100, (float)20), num + "%");
		GUI.Label(new Rect((float)10, (float)(Screen.height - 64), (float)100, (float)20), this.timeString);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000036B0 File Offset: 0x000018B0
	public virtual void Main()
	{
	}

	// Token: 0x04000026 RID: 38
	public GameObject doorLbutton;

	// Token: 0x04000027 RID: 39
	public GameObject doorRbutton;

	// Token: 0x04000028 RID: 40
	public GameObject lightL;

	// Token: 0x04000029 RID: 41
	public GameObject lightR;

	// Token: 0x0400002A RID: 42
	public GameObject lightGlobal;

	// Token: 0x0400002B RID: 43
	public GameObject lightLocal;

	// Token: 0x0400002C RID: 44
	public GameObject batteryUsageGreen;

	// Token: 0x0400002D RID: 45
	public GameObject batteryUsageYellow;

	// Token: 0x0400002E RID: 46
	public GameObject batteryUsageOrange;

	// Token: 0x0400002F RID: 47
	public GameObject batteryUsageRed;

	// Token: 0x04000030 RID: 48
	public int usageCounter;

	// Token: 0x04000031 RID: 49
	public int powerUsage;

	// Token: 0x04000032 RID: 50
	public float battery;

	// Token: 0x04000033 RID: 51
	public float time;

	// Token: 0x04000034 RID: 52
	public int timeInteger;

	// Token: 0x04000035 RID: 53
	public string timeString;

	// Token: 0x04000036 RID: 54
	public int newDoorLcounter;

	// Token: 0x04000037 RID: 55
	public int newDoorRcounter;

	// Token: 0x04000038 RID: 56
	public AudioClip noPowerSound;

	// Token: 0x04000039 RID: 57
	public bool havePower;
}
