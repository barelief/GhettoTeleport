# GhettoTeleport
Transform/rotate object with WASD+ and save/load in Unity

Shortcuts:
```
wasd - move
rf - up/down
qe - rotate
k - save 
l - load
+- - sensitivity
p - display sensitivity
0 - set rotation to zero
8 - set rotation to 180
9 - set rotation to 90
```

if you have many Objects with this script, you can disable/enable Script from particular object this way:

```
public GameObject fooObject; // before Start()
(...)
GhettoTeleport temp = fooObject.GetComponent("GhettoTeleport") as GhettoTeleport;
temp.enabled = false;
```
