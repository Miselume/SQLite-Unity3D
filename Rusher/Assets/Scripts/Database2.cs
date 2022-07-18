using UnityEngine;
using System.Data; // 1
using Mono.Data.Sqlite; // 1

public class Database2 : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IDbConnection connection = ConnectDatabase("CoordinateDatabase");
            PushCommand(string.Format("INSERT INTO Coordinates (XAxis,ZAxis) VALUES({0},{1});", playerTransform.position.x, playerTransform.position.z), connection);
            connection.Close();
        }
    }

    IDbConnection ConnectDatabase(string dbName)
    {
        IDbConnection connection = new SqliteConnection(string.Format("URI=file:Assets/StreamingAssets/{0}.db", dbName));
        connection.Open();
        return connection;
    }

    void PushCommand(string commandString, IDbConnection connection)
    {
        IDbCommand command = connection.CreateCommand();
        command.CommandText = string.Format("{0}", commandString);
        command.ExecuteReader();
    }
}