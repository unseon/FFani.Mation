﻿using UnityEngine;
using System;
using System.Collections;
using System.Reflection;

// abstract PropertyInfo or FieldInfo
public abstract class FFaniMember {
	public object obj;

	public abstract Type getType();
	public abstract object getValue();
	public abstract void setValue(object value);
	public abstract string getName();
//	public abstract object blend(object valueFrom, object valueTo, float t);

	public bool isEqual(FFaniMember that) {
		if (this.obj == that.obj && this.getName () == that.getName ()) {
			return true;
		} else {
			return false;
		}
	}
}

public class FFaniMemberFromProperty : FFaniMember {
	PropertyInfo info;
	//object obj;

	public FFaniMemberFromProperty(object obj, MemberInfo memberInfo) {
		info = (PropertyInfo)memberInfo;
		this.obj = obj;
	}
	
	public override Type getType() {
		return info.PropertyType;
	}
	
	public override object getValue() {
		return info.GetValue(obj, null);
	}
	
	public override void setValue(object value) {
		try {
			info.SetValue(obj, value, null);
			//Debug.Log ("value: " + value);
		} catch(Exception e) {
			Debug.Log ("type:" + info.PropertyType + "<-" + value.GetType());
			Debug.Log (e);
		}
	}
	
	public override string getName() {
		return info.Name;
	}
}

public class FFaniMemberFromField : FFaniMember {
	FieldInfo info;
	//object obj;
	
	public FFaniMemberFromField(object obj, MemberInfo memberInfo) {
		info = (FieldInfo)memberInfo;
		this.obj = obj;
	}
	
	public override Type getType() {
		return info.FieldType;
	}
	
	public override object getValue() {
		return info.GetValue(obj);
	}
	
	public override void setValue(object value) {
		try {
			info.SetValue(obj, value);
			//Debug.Log (info.Name + ":" + value);
		} catch(Exception e) {
			Debug.Log (e);
		}
	}
	
	public override string getName() {
		return info.Name;
	}
}

	
	
