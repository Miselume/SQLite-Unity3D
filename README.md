# Coordinate Database System

**Description**

This project utilizes SQLite to create a simple coordinate database system that allows for saving and retrieving player positions in a Unity game.

**Features**

* Saves the player's current position (X, Y, Z coordinates) to the database.
* Loads the previously saved position upon pressing the 'Q' key.
* Uses slots to differentiate between multiple saved positions.

**Instructions**

1. Attach the `DatabaseManager` script to the player's GameObject.
2. Create a SQLite database named "CoordinateDatabase.db" in the "Assets/StreamingAssets" folder.
3. Update the `dbName` variable in the `DatabaseManager` script to match the database file name.

**Controls**

* Save position: Press the 'E' key.
* Load position: Press the 'Q' key.

**Known Issues**

* Currently only supports one save slot.

**TODO**

* Implement multiple save slots.
* Add functionality to save and load additional information, such as rotation and orientation.
* Integrate the database system with a user interface for easier management.

**License**

This project is licensed under the MIT License.
