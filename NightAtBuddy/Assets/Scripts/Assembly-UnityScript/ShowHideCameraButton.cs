using System;
using UnityEngine;

// Token: 0x02000005 RID: 5
[Serializable]
public class ShowHideCameraButton : MonoBehaviour
{
	// Token: 0x06000015 RID: 21 RVA: 0x000036B4 File Offset: 0x000018B4
	public ShowHideCameraButton()
	{
		this.weAreGood = true;
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000036C4 File Offset: 0x000018C4
	public virtual void Start()
	{
		int num = 90;
		Quaternion localRotation = this.cameraHolder.transform.localRotation;
		float num2 = localRotation.x = (float)num;
		Quaternion quaternion = this.cameraHolder.transform.localRotation = localRotation;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0000370C File Offset: 0x0000190C
	public virtual void Update()
	{
		if (this.mobileInput)
		{
			this.mobileDoorL.active = true;
			this.mobileLightL.active = true;
			this.mobileDoorR.active = true;
			this.mobileLightR.active = true;
		}
		if (!this.mobileInput)
		{
			this.mobileDoorL.active = false;
			this.mobileLightL.active = false;
			this.mobileDoorR.active = false;
			this.mobileLightR.active = false;
		}
		this.screenLocalRotationX = this.cameraHolder.transform.rotation.x;
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit = default(RaycastHit);
			if (Physics.Raycast(ray, out raycastHit))
			{
				if (raycastHit.transform.name == "ScreenButton" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0)
				{
					this.screenCounter++;
					if (this.screenCounter > 1)
					{
						this.screenCounter = 0;
					}
				}
				if ((raycastHit.transform.name == "DoorButtonL" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0) || (raycastHit.transform.name == "doorLtouch" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0))
				{
					this.doorL.GetComponent<AudioSource>().clip = this.doorMoveSound;
					this.doorL.GetComponent<AudioSource>().Play();
					this.doorLcounter++;
					if (this.doorLcounter > 1)
					{
						this.doorLcounter = 0;
					}
					if (((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).whoToMove.transform.position == ((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).spawnPointFive.transform.position && !((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
					{
						((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).whoToMove.transform.position = ((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).spawnNeutral.position;
						((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).whoToMove.transform.rotation = ((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).spawnNeutral.rotation;
						((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).youAreDead = false;
					}
				}
				if ((raycastHit.transform.name == "DoorButtonR" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0) || (raycastHit.transform.name == "doorRtouch" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0))
				{
					this.doorR.GetComponent<AudioSource>().clip = this.doorMoveSound;
					this.doorR.GetComponent<AudioSource>().Play();
					this.doorRcounter++;
					if (this.doorRcounter > 1)
					{
						this.doorRcounter = 0;
					}
				}
				if ((raycastHit.transform.name == "LightButtonL" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0) || (raycastHit.transform.name == "lightLtouch" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0))
				{
					this.lightLcounter++;
					if (this.lightLcounter > 1)
					{
						this.lightLcounter = 0;
					}
					this.lightLbutton.GetComponent<AudioSource>().clip = this.switchButtonSound;
					this.lightLbutton.GetComponent<AudioSource>().Play();
					if (this.lightLcounter == 1 && !((Light)this.lightL.GetComponent(typeof(Light))).enabled)
					{
						((Light)this.lightL.GetComponent(typeof(Light))).enabled = true;
					}
					if (this.lightLcounter == 0 && ((Light)this.lightL.GetComponent(typeof(Light))).enabled)
					{
						((Light)this.lightL.GetComponent(typeof(Light))).enabled = false;
					}
				}
				if ((raycastHit.transform.name == "LightButtonR" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0) || (raycastHit.transform.name == "lightRtouch" && ((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery != (float)0))
				{
					this.lightRcounter++;
					if (this.lightRcounter > 1)
					{
						this.lightRcounter = 0;
					}
					this.lightRbutton.GetComponent<AudioSource>().clip = this.switchButtonSound;
					this.lightRbutton.GetComponent<AudioSource>().Play();
					if (this.lightRcounter == 1 && !((Light)this.lightR.GetComponent(typeof(Light))).enabled)
					{
						((Light)this.lightR.GetComponent(typeof(Light))).enabled = true;
					}
					if (this.lightRcounter == 0 && ((Light)this.lightR.GetComponent(typeof(Light))).enabled)
					{
						((Light)this.lightR.GetComponent(typeof(Light))).enabled = false;
					}
				}
				if (raycastHit.transform.name == "CameraOneButton")
				{
					this.transform.position = this.cameraPositionOne.transform.position;
					this.transform.rotation = this.cameraPositionOne.transform.rotation;
					this.GetComponent<AudioSource>().clip = this.switchCameraSound;
					this.GetComponent<AudioSource>().Play();
				}
				if (raycastHit.transform.name == "CameraTwoButton")
				{
					this.transform.position = this.cameraPositionTwo.transform.position;
					this.transform.rotation = this.cameraPositionTwo.transform.rotation;
					this.GetComponent<AudioSource>().clip = this.switchCameraSound;
					this.GetComponent<AudioSource>().Play();
				}
				if (raycastHit.transform.name == "CameraThreeButton")
				{
					this.transform.position = this.cameraPositionThree.transform.position;
					this.transform.rotation = this.cameraPositionThree.transform.rotation;
					this.GetComponent<AudioSource>().clip = this.switchCameraSound;
					this.GetComponent<AudioSource>().Play();
				}
				if (raycastHit.transform.name == "CameraFourButton")
				{
					this.transform.position = this.cameraPositionFour.transform.position;
					this.transform.rotation = this.cameraPositionFour.transform.rotation;
					this.GetComponent<AudioSource>().clip = this.switchCameraSound;
					this.GetComponent<AudioSource>().Play();
				}
				if (raycastHit.transform.name == "RestartButton")
				{
					Application.LoadLevel(Application.loadedLevelName);
				}
				if (raycastHit.transform.name == "ExitButton")
				{
					Application.Quit();
				}
			}
		}
		if (this.screenCounter == 0 && this.cameraHolder.transform.localRotation.x != (float)0)
		{
			float x = this.cameraHolder.transform.localRotation.x - Time.deltaTime * (float)4;
			Quaternion localRotation = this.cameraHolder.transform.localRotation;
			float num = localRotation.x = x;
			Quaternion quaternion = this.cameraHolder.transform.localRotation = localRotation;
		}
		if (this.screenCounter == 1 && this.cameraHolder.transform.localRotation.x != 0.9f)
		{
			float x2 = this.cameraHolder.transform.localRotation.x + Time.deltaTime * (float)4;
			Quaternion localRotation2 = this.cameraHolder.transform.localRotation;
			float num2 = localRotation2.x = x2;
			Quaternion quaternion2 = this.cameraHolder.transform.localRotation = localRotation2;
		}
		if (this.cameraHolder.transform.localRotation.x < (float)0)
		{
			this.GetComponent<AudioSource>().clip = this.screenOnSound;
			this.GetComponent<AudioSource>().Play();
			int num3 = 0;
			Quaternion localRotation3 = this.cameraHolder.transform.localRotation;
			float num4 = localRotation3.x = (float)num3;
			Quaternion quaternion3 = this.cameraHolder.transform.localRotation = localRotation3;
			this.weAreWatching = true;
		}
		if (this.cameraHolder.transform.localRotation.x > 0.9f)
		{
			this.GetComponent<AudioSource>().clip = this.screenOffSound;
			this.GetComponent<AudioSource>().Play();
			float x3 = 0.9f;
			Quaternion localRotation4 = this.cameraHolder.transform.localRotation;
			float num5 = localRotation4.x = x3;
			Quaternion quaternion4 = this.cameraHolder.transform.localRotation = localRotation4;
			this.weAreWatching = false;
		}
		if (this.doorLcounter == 0 && !((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened = true;
		}
		if (this.doorLcounter == 1 && ((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened = false;
		}
		if (this.doorRcounter == 0 && !((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened = true;
		}
		if (this.doorRcounter == 1 && ((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened = false;
		}
		if (((PowerUsage)this.GetComponent(typeof(PowerUsage))).battery == (float)0)
		{
			((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).weAreGood = false;
			((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened = false;
			((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened = false;
			((Light)this.lightL.GetComponent(typeof(Light))).enabled = false;
			((Light)this.lightR.GetComponent(typeof(Light))).enabled = false;
			this.screen.active = false;
			this.transform.position = this.cameraPositionOne.transform.position;
			this.transform.rotation = this.cameraPositionOne.transform.rotation;
			this.screenOfComputer.active = false;
			if (!((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).gameOver && !((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).done)
			{
				this.darkness.active = true;
			}
			if (!this.done)
			{
				((FreddyBearAI)this.bear.GetComponent(typeof(FreddyBearAI))).suddenAttackPosition = UnityEngine.Random.Range(1, 5);
				this.done = true;
			}
		}
		if (this.transform.position == this.cameraPositionOne.transform.position || this.weAreWatching)
		{
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000044D8 File Offset: 0x000026D8
	public virtual void Main()
	{
	}

	// Token: 0x0400003A RID: 58
	public Transform cameraHolder;

	// Token: 0x0400003B RID: 59
	public float screenLocalRotationX;

	// Token: 0x0400003C RID: 60
	public int screenCounter;

	// Token: 0x0400003D RID: 61
	public int doorLcounter;

	// Token: 0x0400003E RID: 62
	public int doorRcounter;

	// Token: 0x0400003F RID: 63
	public int lightLcounter;

	// Token: 0x04000040 RID: 64
	public int lightRcounter;

	// Token: 0x04000041 RID: 65
	public GameObject doorLbutton;

	// Token: 0x04000042 RID: 66
	public GameObject doorRbutton;

	// Token: 0x04000043 RID: 67
	public GameObject lightL;

	// Token: 0x04000044 RID: 68
	public GameObject lightR;

	// Token: 0x04000045 RID: 69
	public Transform cameraPositionOne;

	// Token: 0x04000046 RID: 70
	public Transform cameraPositionTwo;

	// Token: 0x04000047 RID: 71
	public Transform cameraPositionThree;

	// Token: 0x04000048 RID: 72
	public Transform cameraPositionFour;

	// Token: 0x04000049 RID: 73
	public bool weAreWatching;

	// Token: 0x0400004A RID: 74
	public AudioClip switchCameraSound;

	// Token: 0x0400004B RID: 75
	public AudioClip screenOnSound;

	// Token: 0x0400004C RID: 76
	public AudioClip screenOffSound;

	// Token: 0x0400004D RID: 77
	public AudioClip switchButtonSound;

	// Token: 0x0400004E RID: 78
	public AudioClip doorMoveSound;

	// Token: 0x0400004F RID: 79
	public GameObject doorL;

	// Token: 0x04000050 RID: 80
	public GameObject doorR;

	// Token: 0x04000051 RID: 81
	public GameObject lightLbutton;

	// Token: 0x04000052 RID: 82
	public GameObject lightRbutton;

	// Token: 0x04000053 RID: 83
	public GameObject screen;

	// Token: 0x04000054 RID: 84
	public GameObject screenOfComputer;

	// Token: 0x04000055 RID: 85
	public GameObject darkness;

	// Token: 0x04000056 RID: 86
	public GameObject bear;

	// Token: 0x04000057 RID: 87
	public bool weAreGood;

	// Token: 0x04000058 RID: 88
	public int a;

	// Token: 0x04000059 RID: 89
	public bool mobileInput;

	// Token: 0x0400005A RID: 90
	public GameObject mobileDoorL;

	// Token: 0x0400005B RID: 91
	public GameObject mobileLightL;

	// Token: 0x0400005C RID: 92
	public GameObject mobileDoorR;

	// Token: 0x0400005D RID: 93
	public GameObject mobileLightR;

	// Token: 0x0400005E RID: 94
	public bool done;
}
