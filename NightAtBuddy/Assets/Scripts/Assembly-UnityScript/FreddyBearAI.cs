using System;
using UnityEngine;

// Token: 0x02000003 RID: 3
[Serializable]
public class FreddyBearAI : MonoBehaviour
{
	// Token: 0x06000005 RID: 5 RVA: 0x000022EC File Offset: 0x000004EC
	public FreddyBearAI()
	{
		this.weAreGood = true;
		this.b = 8;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00002304 File Offset: 0x00000504
	public virtual void SuddenAttack()
	{
		this.wasPlayed = this.isPlaying;
		this.wasStopped = this.notPlaying;
		if (((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).darkness.GetComponent<AudioSource>().isPlaying)
		{
			this.isPlaying = true;
			this.eyes.active = true;
		}
		if (!((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).darkness.GetComponent<AudioSource>().isPlaying && this.isPlaying)
		{
			this.notPlaying = true;
		}
		if (this.wasPlayed && this.wasStopped && !this.wasListened)
		{
			if (this.suddenAttackPosition == 1991)
			{
				this.speed = (float)15;
				this.whoToMove.transform.position = this.spawnPointTwo.transform.position;
				this.whoToMove.transform.rotation = this.spawnPointTwo.transform.rotation;
				((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).doorRcounter = 1;
				this.SuddenAttackFromRight();
			}
			if (this.suddenAttackPosition == 3 || this.suddenAttackPosition == 4 || this.suddenAttackPosition == 1 || this.suddenAttackPosition == 2)
			{
				this.speed = (float)15;
				this.whoToMove.transform.position = this.spawnPointFive.transform.position;
				this.whoToMove.transform.rotation = this.spawnPointFive.transform.rotation;
				this.SuddenAttackFromLeft();
			}
			this.wasListened = true;
		}
	}

	// Token: 0x06000007 RID: 7 RVA: 0x000024D0 File Offset: 0x000006D0
	public virtual void Start()
	{
		this.spawnPosition = UnityEngine.Random.Range(1, 5);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000024E0 File Offset: 0x000006E0
	public virtual void Update()
	{
		this.SuddenAttack();
		this.randomTime -= Time.deltaTime;
		if (this.randomTime < (float)0)
		{
			this.randomTime = (float)0;
			this.busy = false;
		}
		if (((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).weAreWatching && !this.enough)
		{
			this.ItIsSpawning();
		}
		if (!((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).weAreWatching && this.enough)
		{
			this.enough = false;
		}
		if (this.weAreGood)
		{
			this.ItIsWalking();
			this.ItEntersFromRight();
			this.ItEntersFromLeft();
		}
	}

	// Token: 0x06000009 RID: 9 RVA: 0x000025AC File Offset: 0x000007AC
	public virtual void ItIsSpawning()
	{
		this.spawnPosition = UnityEngine.Random.Range(1, 6);
		if (this.spawnPosition == 1)
		{
			this.whoToMove.transform.position = this.spawnPointOne.transform.position;
			this.whoToMove.transform.rotation = this.spawnPointOne.transform.rotation;
		}
		else if (this.spawnPosition == 2)
		{
			this.whoToMove.transform.position = this.spawnPointTwo.transform.position;
			this.whoToMove.transform.rotation = this.spawnPointTwo.transform.rotation;
		}
		else if (this.spawnPosition == 3)
		{
			this.whoToMove.transform.position = this.spawnPointThree.transform.position;
			this.whoToMove.transform.rotation = this.spawnPointThree.transform.rotation;
		}
		else if (this.spawnPosition == 4)
		{
			this.whoToMove.transform.position = this.spawnPointFour.transform.position;
			this.whoToMove.transform.rotation = this.spawnPointFour.transform.rotation;
		}
		else if (this.spawnPosition == 5 && !((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.whoToMove.transform.position = this.spawnPointFive.transform.position;
			this.whoToMove.transform.rotation = this.spawnPointFive.transform.rotation;
		}
		this.enough = true;
	}

	// Token: 0x0600000A RID: 10 RVA: 0x00002784 File Offset: 0x00000984
	public virtual void ItIsWalking()
	{
		if (!this.busy)
		{
			this.busy = true;
			this.randomTime = UnityEngine.Random.Range(10f, 20f);
			this.ItIsSpawning();
		}
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000027B4 File Offset: 0x000009B4
	public virtual void ItEntersFromRight()
	{
		if (this.whoToMove.transform.position == this.spawnPointTwo.transform.position && ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).doorRcounter == 1)
		{
			this.youAreDead = true;
		}
		if (this.youAreDead)
		{
			float maxDistanceDelta = this.speed * Time.deltaTime;
			this.whoToMove.transform.position = Vector3.MoveTowards(this.whoToMove.transform.position, this.spawnPreAttack.position, maxDistanceDelta);
		}
		if (this.whoToMove.transform.position == this.spawnPreAttack.transform.position && !((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.gameOver = false;
			this.done = true;
			this.jumpScareLight.GetComponent<Light>().enabled = true;
			this.eyes.active = false;
			((PowerUsage)this.playerCamera.GetComponent(typeof(PowerUsage))).battery = (float)0;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).position = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.position;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).rotation = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.rotation;
			this.youAreDead = false;
			this.GetComponent<AudioSource>().clip = this.bearSound;
			this.GetComponent<AudioSource>().Play();
			this.whoToMove.transform.position = this.spawnAttack.position;
			this.whoToMove.transform.rotation = this.spawnAttack.rotation;
		}
		if (this.whoToMove.transform.position == this.spawnPreAttack.transform.position && ((DoorButton)this.doorRbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.whoToMove.transform.position = this.spawnNeutral.position;
			this.whoToMove.transform.rotation = this.spawnNeutral.rotation;
			this.youAreDead = false;
		}
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00002A70 File Offset: 0x00000C70
	public virtual void ItEntersFromLeft()
	{
		if (this.whoToMove.transform.position == this.spawnPointFive.transform.position && !((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.youAreDeadTwo = true;
		}
		if (this.youAreDeadTwo)
		{
			float maxDistanceDelta = this.speed / (float)5 * Time.deltaTime;
			this.whoToMove.transform.position = Vector3.MoveTowards(this.whoToMove.transform.position, this.spawnPreAttackTwo.position, maxDistanceDelta);
			if (((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
			{
				this.whoToMove.transform.position = this.spawnNeutral.position;
				this.whoToMove.transform.rotation = this.spawnNeutral.rotation;
			}
		}
		if (this.whoToMove.transform.position == this.spawnPreAttackTwo.transform.position && !((DoorButton)this.doorLbutton.GetComponent(typeof(DoorButton))).opened)
		{
			this.gameOver = false;
			this.done = true;
			this.jumpScareLight.GetComponent<Light>().enabled = true;
			this.eyes.active = false;
			((PowerUsage)this.playerCamera.GetComponent(typeof(PowerUsage))).battery = (float)0;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).position = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.position;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).rotation = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.rotation;
			this.youAreDeadTwo = false;
			this.GetComponent<AudioSource>().clip = this.bearSound;
			this.GetComponent<AudioSource>().Play();
			this.whoToMove.transform.position = this.spawnAttack.position;
			this.whoToMove.transform.rotation = this.spawnAttack.rotation;
		}
	}

	// Token: 0x0600000D RID: 13 RVA: 0x00002CFC File Offset: 0x00000EFC
	public virtual void SuddenAttackFromRight()
	{
		float maxDistanceDelta = this.speed * Time.deltaTime;
		this.whoToMove.transform.position = Vector3.MoveTowards(this.whoToMove.transform.position, this.spawnPreAttack.position, maxDistanceDelta);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002D48 File Offset: 0x00000F48
	public virtual void SuddenAttackFromLeft()
	{
		float maxDistanceDelta = this.speed / (float)5 * Time.deltaTime;
		this.whoToMove.transform.position = Vector3.MoveTowards(this.whoToMove.transform.position, this.spawnPreAttackTwo.position, maxDistanceDelta);
		if (this.whoToMove.transform.position == this.spawnPreAttackTwo.transform.position)
		{
			this.gameOver = false;
		}
		this.done = true;
		this.jumpScareLight.GetComponent<Light>().enabled = true;
		this.eyes.active = false;
		((PowerUsage)this.playerCamera.GetComponent(typeof(PowerUsage))).battery = (float)0;
		((Transform)this.playerCamera.GetComponent(typeof(Transform))).position = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.position;
		((Transform)this.playerCamera.GetComponent(typeof(Transform))).rotation = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.rotation;
		this.youAreDeadTwo = false;
		this.GetComponent<AudioSource>().clip = this.bearSound;
		this.GetComponent<AudioSource>().Play();
		this.whoToMove.transform.position = this.spawnAttack.position;
		this.whoToMove.transform.rotation = this.spawnAttack.rotation;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002EF8 File Offset: 0x000010F8
	public virtual void Main()
	{
		if (this.whoToMove.transform.position == this.spawnPreAttack.transform.position)
		{
			this.gameOver = false;
			this.done = true;
			((PowerUsage)this.playerCamera.GetComponent(typeof(PowerUsage))).battery = (float)0;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).position = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.position;
			((Transform)this.playerCamera.GetComponent(typeof(Transform))).rotation = ((ShowHideCameraButton)this.playerCamera.GetComponent(typeof(ShowHideCameraButton))).cameraPositionOne.transform.rotation;
			this.youAreDead = false;
			this.GetComponent<AudioSource>().clip = this.bearSound;
			this.GetComponent<AudioSource>().Play();
			this.whoToMove.transform.position = this.spawnAttack.position;
			this.whoToMove.transform.rotation = this.spawnAttack.rotation;
		}
	}

	// Token: 0x04000005 RID: 5
	public GameObject playerCamera;

	// Token: 0x04000006 RID: 6
	public Transform spawnPointOne;

	// Token: 0x04000007 RID: 7
	public Transform spawnPointTwo;

	// Token: 0x04000008 RID: 8
	public Transform spawnPointThree;

	// Token: 0x04000009 RID: 9
	public Transform spawnPointFour;

	// Token: 0x0400000A RID: 10
	public Transform spawnPointFive;

	// Token: 0x0400000B RID: 11
	public Transform spawnPreAttack;

	// Token: 0x0400000C RID: 12
	public Transform spawnPreAttackTwo;

	// Token: 0x0400000D RID: 13
	public Transform spawnAttack;

	// Token: 0x0400000E RID: 14
	public Transform spawnNeutral;

	// Token: 0x0400000F RID: 15
	public GameObject whoToMove;

	// Token: 0x04000010 RID: 16
	public bool enough;

	// Token: 0x04000011 RID: 17
	public int spawnPosition;

	// Token: 0x04000012 RID: 18
	public bool youAreDead;

	// Token: 0x04000013 RID: 19
	public bool youAreDeadTwo;

	// Token: 0x04000014 RID: 20
	public AudioClip bearSound;

	// Token: 0x04000015 RID: 21
	public GameObject doorRbutton;

	// Token: 0x04000016 RID: 22
	public GameObject doorLbutton;

	// Token: 0x04000017 RID: 23
	public float speed;

	// Token: 0x04000018 RID: 24
	public float randomTime;

	// Token: 0x04000019 RID: 25
	public bool busy;

	// Token: 0x0400001A RID: 26
	public bool weAreGood;

	// Token: 0x0400001B RID: 27
	public bool gameOver;

	// Token: 0x0400001C RID: 28
	public int suddenAttackPosition;

	// Token: 0x0400001D RID: 29
	public int b;

	// Token: 0x0400001E RID: 30
	public bool done;

	// Token: 0x0400001F RID: 31
	public bool isPlaying;

	// Token: 0x04000020 RID: 32
	public bool notPlaying;

	// Token: 0x04000021 RID: 33
	public bool wasPlayed;

	// Token: 0x04000022 RID: 34
	public bool wasStopped;

	// Token: 0x04000023 RID: 35
	public bool wasListened;

	// Token: 0x04000024 RID: 36
	public GameObject jumpScareLight;

	// Token: 0x04000025 RID: 37
	public GameObject eyes;
}
