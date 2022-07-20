using UnityEngine;
using System.Data; 
using Mono.Data.Sqlite; // For using SQLite

public class DatabaseManager : MonoBehaviour
{
    // Player transform for access position
    [SerializeField]
    private Transform playerTransform;
    // Database name
    private string dbName = "CoordinateDatabase";
    // Database Connection
    IDbConnection connection;

    private void Start()
    {
        // Connect Database
        connection = new SqliteConnection(string.Format("URI=file:Assets/StreamingAssets/{0}.db", dbName));
    }

    void Update()
    {
        // When pressed E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Open database
            connection.Open();
            // Update Data in Save Slot
            PushCommand(string.Format("UPDATE Coordinates SET XAxis = {0}, YAxis = {1} , ZAxis = {2} WHERE Slot = 1;", playerTransform.position.x, playerTransform.position.y, playerTransform.position.z), connection);
        }

        // When pressed Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Open database
            connection.Open();

            // Read X , Y , Z Axis
            IDataReader dataReader = ReadSavedData();

            // Separate Float Data and assign to player position
            while (dataReader.Read())
            {
                // Assigning saved position
                playerTransform.position = new Vector3(dataReader.GetFloat(1), dataReader.GetFloat(2), dataReader.GetFloat(3));
            }
        }

        // Close database
        connection.Close();
    }

    // Create new command on opened database
    void PushCommand(string commandString, IDbConnection connection)
    {
        // Create new command
        IDbCommand command = connection.CreateCommand();
        // Add your comment text (queries)
        command.CommandText = string.Format("{0}", commandString);
        // Execute command reader - execute command
        command.ExecuteReader();
    }

    // Read last position from coordinates table
    IDataReader ReadSavedData()
    {
        // Create command (query)
        IDbCommand command = connection.CreateCommand();
        // Get all data in Slot = 1 from coordinates table
        command.CommandText = "SELECT * FROM Coordinates WHERE Slot = 1;";
        // Execute command
        IDataReader dataReader = command.ExecuteReader();
        return dataReader;
    }
}