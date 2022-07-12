using System;
using UnityEngine;

// Token: 0x02000002 RID: 2
[Serializable]
public class DoorButton : MonoBehaviour
{
	// Token: 0x06000002 RID: 2 RVA: 0x000020F4 File Offset: 0x000002F4
	public virtual void Start()
	{
		this.doorStartPositionY = this.transform.position.y;
		this.doorEndPositionY = this.transform.position.y * (float)4;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002138 File Offset: 0x00000338
	public virtual void Update()
	{
		if (this.opened)
		{
			float y = this.door.transform.position.y + Time.deltaTime * (float)4;
			Vector3 position = this.door.transform.position;
			float num = position.y = y;
			Vector3 vector = this.door.transform.position = position;
			if (this.door.transform.position.y >= this.doorStartPositionY)
			{
				float y2 = this.doorStartPositionY;
				Vector3 position2 = this.door.transform.position;
				float num2 = position2.y = y2;
				Vector3 vector2 = this.door.transform.position = position2;
			}
		}
		if (!this.opened)
		{
			float y3 = this.door.transform.position.y + Time.deltaTime * (float)4;
			Vector3 position3 = this.door.transform.position;
			float num3 = position3.y = y3;
			Vector3 vector3 = this.door.transform.position = position3;
			if (this.door.transform.position.y >= this.doorEndPositionY)
			{
				float y4 = this.doorEndPositionY;
				Vector3 position4 = this.door.transform.position;
				float num4 = position4.y = y4;
				Vector3 vector4 = this.door.transform.position = position4;
			}
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x000022E8 File Offset: 0x000004E8
	public virtual void Main()
	{
	}

	// Token: 0x04000001 RID: 1
	public Transform door;

	// Token: 0x04000002 RID: 2
	public bool opened;

	// Token: 0x04000003 RID: 3
	private float doorStartPositionY;

	// Token: 0x04000004 RID: 4
	private float doorEndPositionY;
}
