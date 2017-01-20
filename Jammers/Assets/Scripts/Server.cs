﻿using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

/*Other classes should get the GameManager by calling GameManager::instance()*/
public class Server : NetworkBehaviour
{
	private static Server s_instance = null;

	private IList<Player> m_playerList;
	
	private int m_nextPlayerNum;

	public class Exception : System.Exception
	{
		public Exception(string message) :base(message) {}
	}

	public static Server Instance()
	{
		if (s_instance == null)
			throw new Exception("GameManager hasn't been instantiated yet. It needs to be attached as a component!");

		return s_instance;
	}

	void Awake()
	{
		if (s_instance != null)
			throw new Exception ("GameManager has been used more than once.");

		s_instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		m_playerList = new List<Player> ();
		m_nextPlayerNum = 1;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void AddPlayer(Player newPlayer)
	{
		newPlayer.SetPlayerNum(NextPlayerNumber());
		m_playerList.Add(newPlayer);
	}

	public int NextPlayerNumber()
	{
		return m_nextPlayerNum++;
	}

	public void SendMessageTo(int playerNum, string message)
	{
		//LHF: ideally here we'd only actually send the message to the player with the right ID, but that's hard so screw it, leave it up to them.

	}

}