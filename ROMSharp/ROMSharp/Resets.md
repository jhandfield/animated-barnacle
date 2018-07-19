# Background
The ```#ROOMS``` section of files define the rooms that make up the area. The
```#OBJECTS``` section of the file defines the objects (flora) that fill the
area, and finally the ```#MOBILES``` section of area defines the mobs (fauna)
that fill the area. Even after all these definitions are loaded, however, the
area is just an empy collection of rooms. The ```#RESETS``` section defines
the rules used to populate the rooms of an area with mobiles and objects, put
objects into other objects, give objects to mobiles or equip mobiles with
objects, and set the state of doors throughout the area.

# Notes
* In the original source, resets are read and stored with only minor validation
performed at the time of reading.
* Resets are processed as part of the function ```reset_area()``` in
```merc.h:1213:1509```.
* Some reset types are dependent on being processed in a specific order, such
as the ```G```(ive) reset, which needs to have sort of a "context mobile"
defined; this is done by placing ```G``` and ```E```(quip) resets immediately
following the ```M```(obile) reset that it pertains to. It would not, however,
be safe to just include the objects given/equipped to a mobile in their
prototype, as various instances of a given mob may have different sets of items.
