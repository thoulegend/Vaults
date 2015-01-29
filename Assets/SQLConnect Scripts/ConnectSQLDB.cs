using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Drawing;

public class ConnectSQLDB : MonoBehaviour {
	public MySqlConnection connection;
	// Use this for initialization
	void Start () {
		string DB_ADDR = "vaultstcgtest.db.10691928.hostedresource.com";
		string DB_NAME = "vaultstcgtest";
		string DB_UNAME = "vaultstcgtest";
		string DB_PWD = "vaultsT3st!";

		string connectionString;
		connectionString = "SERVER=" + DB_ADDR + ";" + "DATABASE=" + 
			DB_NAME + ";" + "UID=" + DB_UNAME + ";" + "PASSWORD=" + DB_PWD + ";";
		
		connection = new MySqlConnection(connectionString);

	}

	private bool OpenConnection()
	{
		try
		{
			connection.Open();
			return true;
		}
		catch (MySqlException ex)
		{
			//When handling errors, you can your application's response based 
			//on the error number.
			//The two most common error numbers when connecting are as follows:
			//0: Cannot connect to server.
			//1045: Invalid user name and/or password.
			switch (ex.Number)
			{
			case 0:
				Debug.Log("Cannot connect to server.  Contact administrator");
				break;
				
			case 1045:
				Debug.Log("Invalid username/password, please try again");
				break;
			}
			return false;
		}
	}

	private bool CloseConnection()
	{
		try
		{
			connection.Close();
			return true;
		}
		catch (MySqlException ex)
		{
			Debug.Log(ex.Message);
			return false;
		}
	}


	//Select statement
	public List< string >[] Select()
	{
		string query = "SELECT * FROM TCG_CARD";
		
		//Create a list to store the result
		List< string >[] list = new List< string >[3];
		list[0] = new List< string >();
		list[1] = new List< string >();
		list[2] = new List< string >();
		
		//Open connection
		if (this.OpenConnection() == true)
		{
			//Create Command
			MySqlCommand cmd = new MySqlCommand(query, connection);
			//Create a data reader and Execute the command
			MySqlDataReader dataReader = cmd.ExecuteReader();
			
			//Read the data and store them in the list
			while (dataReader.Read())
			{
				list[0].Add(dataReader["ID"] + "");
				list[1].Add(dataReader["CARD_NAME"] + "");
				list[2].Add(dataReader["ABILITY_ID"] + "");
			}
			
			//close Data Reader
			dataReader.Close();
			
			//close Connection
			this.CloseConnection();
			
			//return list to be displayed
			return list;
		}
		else
		{
			return list;
		}
	}

}
