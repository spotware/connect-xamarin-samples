using System;
using System.Collections;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

using OpenApiDeveloperLibrary;
using OpenApiLib.Proto;

namespace OpenTrader.Proto
{
	public class TradingAPI
	{
		#region Settings...
		static string clientPublicId = "7_5az7pj935owsss8kgokcco84wc8osk0g0gksow0ow4s4ocwwgc";
		static string clientSecret = "49p1ynqfy7c4sw84gwoogwwsk8cocg8ow8gc8o80c0ws448cs4";
		static long testAccountId = 62002;

		private string host;
		private int port;
		private string authToken;

		static long testPositionId = -1;
		//static Dictionary<long, string> testOrdersMap = new Dictionary<long,string>();
		static long testVolume = 1000000;

		static string clientMsgId = null;

		static uint sendMsgTimeout = 20;
		static DateTime lastSentMsgTimestamp = DateTime.Now.AddSeconds (sendMsgTimeout);

		static int MaxMessageSize = 1000000;
		static bool isDebugIsOn = true;

		#endregion Settings...

		#region Internal fields

		private SslStream apiSocket;

		private volatile static bool isShutdown;
		//private volatile static bool isRestart;

		private Queue writeQueue = Queue.Synchronized (new Queue ());
		private Queue readQueue = Queue.Synchronized (new Queue ());

		private OpenApiMessagesFactory incomingMsgFactory = new OpenApiMessagesFactory ();
		private OpenApiMessagesFactory outgoingMsgFactory = new OpenApiMessagesFactory ();
		#endregion Internal fields

		public TradingAPI (string host, int port, string authToken)
		{
			this.host = host;
			this.port = port;
			this.authToken = authToken;
		}

		#region Threads

		// timer thread
		private void Timer ()
		{
			isShutdown = false;
			while (!isShutdown) {
				Thread.Sleep (1000);
				if (DateTime.Now > lastSentMsgTimestamp) {
					SendPingRequest ();
				}
			}
		}

		// listener thread
		private void Listen ()
		{
			isShutdown = false;
			while (!isShutdown) {
				Thread.Sleep (1);

				byte[] _length = new byte[sizeof(int)];
				int readBytes = 0;
				do {
					Thread.Sleep (0);
					readBytes += apiSocket.Read (_length, readBytes, _length.Length - readBytes);
				} while (readBytes < _length.Length);

				int length = BitConverter.ToInt32 (_length.Reverse ().ToArray (), 0);
				if (length <= 0)
					continue;

				if (length > MaxMessageSize) {
					string exceptionMsg = "Message length " + length.ToString () + " is out of range (0 - " + MaxMessageSize.ToString () + ")";
					throw new System.IndexOutOfRangeException ();
				}

				byte[] _message = new byte[length];
				if (isDebugIsOn)
					Console.WriteLine ("Data received: {0}", GetHexadecimal (_length));
				readBytes = 0;
				do {
					Thread.Sleep (0);
					readBytes += apiSocket.Read (_message, readBytes, _message.Length - readBytes);
				} while (readBytes < length);
				if (isDebugIsOn)
					Console.WriteLine ("Data received: {0}", GetHexadecimal (_message));
				readQueue.Enqueue (_message);
			}
		}

		// sender thread
		private void Transmit (DateTime lastSentMsgTimestamp)
		{
			isShutdown = false;
			while (!isShutdown) {
				Thread.Sleep (1);

				if (writeQueue.Count <= 0)
					continue;

				byte[] _message = (byte[])writeQueue.Dequeue ();
				byte[] _length = BitConverter.GetBytes (_message.Length).Reverse ().ToArray ();

				apiSocket.Write (_length);
				if (isDebugIsOn)
					Console.WriteLine ("Data sent: {0}", GetHexadecimal (_length));
				apiSocket.Write (_message);
				if (isDebugIsOn)
					Console.WriteLine ("Data sent: {0}", GetHexadecimal (_message));
				lastSentMsgTimestamp = DateTime.Now.AddSeconds (sendMsgTimeout);
			}
		}

		// incoming data processing thread
		private void IncomingDataProcessing ()
		{
			isShutdown = false;
			while (!isShutdown) {
				Thread.Sleep (0);

				if (readQueue.Count <= 0)
					continue;

				byte[] _message = (byte[])readQueue.Dequeue ();
				ProcessIncomingDataStream (_message);
			}
		}
		#endregion Threads

		#region Handlers

		static bool ValidateServerCertificate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			if (sslPolicyErrors == SslPolicyErrors.None)
				return true;
			Console.WriteLine ("Certificate error: {0}", sslPolicyErrors);
			return false;
		}

		#endregion Handlers

		public void Start ()
		{
			//isRestart = false;
			#region open ssl connection
			Console.WriteLine ("Establishing trading SSL connection to {0}:{1}...", host, port);
			try {
				TcpClient client = new TcpClient (host, port);
				apiSocket = new SslStream (client.GetStream (), false,
					new RemoteCertificateValidationCallback (ValidateServerCertificate), null);
				apiSocket.AuthenticateAsClient (host);
			} catch (Exception e) {
				Console.WriteLine ("Establishing SSL connection error: {0}", e);
				return;
			}
			Console.WriteLine ("The connection is established successfully.");
			#endregion open ssl connection

			#region start incoming data processing thread
			Thread p = new Thread (() => {
				Thread.CurrentThread.IsBackground = true;
				try {
					IncomingDataProcessing ();
				} catch (Exception e) {
					Console.WriteLine ("DataProcessor throws exception: {0}", e);
				}
			});
			p.Start ();
			#endregion start incoming data processing thread

			#region start listener
			Thread tl = new Thread (() => {
				Thread.CurrentThread.IsBackground = true;
				try {
					Listen ();
				} catch (Exception e) {
					Console.WriteLine ("Listener throws exception: {0}", e);
				}
			});
			tl.Start ();
			#endregion start listener

			#region start sender
			Thread ts = new Thread (() => {
				Thread.CurrentThread.IsBackground = true;
				try {
					Transmit (lastSentMsgTimestamp);
				} catch (Exception e) {
					Console.WriteLine ("Transmitter throws exception: {0}", e);
				}
			});
			ts.Start ();
			#endregion start sender

			#region start timer
			Thread t = new Thread (() => {
				Thread.CurrentThread.IsBackground = true;
				try {
					Timer ();
				} catch (Exception e) {
					Console.WriteLine ("Listener throws exception: {0}", e);
				}
			});
			t.Start ();
			#endregion start timer

			SendAuthorizationRequest ();
			SendSubscribeForSpotsRequest ();
			SendSubscribeForTradingEventsRequest ();
		}

		public void Stop() {
			#region close ssl connection
			isShutdown = true;
			apiSocket.Close ();
			#endregion close ssl connection
		}

		#region Auxilary functions
		public static string GetHexadecimal (byte[] byteArray)
		{
			var hex = new StringBuilder (byteArray.Length * 2);
			foreach (var b in byteArray)
				hex.AppendFormat ("{0:X2} ", b);
			return hex.ToString ();
		}
		#endregion Auxilary functions

		#region Incoming data stream processing...
		public delegate void ExecutionEventHandler(ProtoOAExecutionEvent executionEvent);
		public delegate void SpotEventHandler(ProtoOASpotEvent executionEvent);

		public event ExecutionEventHandler ExecutionEvent;
		public event SpotEventHandler SpotEvent;

		private void ProcessIncomingDataStream (byte[] rawData)
		{
			var _msg = incomingMsgFactory.GetMessage (rawData);
			if (isDebugIsOn)
				Console.WriteLine ("ProcessIncomingDataStream() Message received:\n{0}", OpenApiMessagesPresentation.ToString (_msg));

			if (!_msg.payloadSpecified) {
				return;
			}

			switch (_msg.payloadType) {
			case (int)ProtoPayloadType.HEARTBEAT_EVENT:
				break;
			case (int)ProtoOAPayloadType.OA_EXECUTION_EVENT:
				var _payload_msg = incomingMsgFactory.GetExecutionEvent (rawData);
				if (ExecutionEvent != null) {
					ExecutionEvent (_payload_msg);
				}
				if (_payload_msg.position != null) {
					testPositionId = _payload_msg.position.positionId;
				}
				break;
			case (int)ProtoOAPayloadType.OA_SPOT_EVENT:
				if (SpotEvent != null) {
					SpotEvent (incomingMsgFactory.GetSpotEvent (rawData));
				}
				break;
			default:
					break;
			}
		}

		#endregion Incoming data stream processing...

		#region Outgoing ProtoBuffer objects to Raw data...
		private void SendPingRequest ()
		{
			var _msg = outgoingMsgFactory.CreatePingRequest ((ulong)DateTime.Now.Ticks);
			if (isDebugIsOn)
				Console.WriteLine ("SendPingRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendHeartbeatEvent ()
		{
			var _msg = outgoingMsgFactory.CreateHeartbeatEvent ();
			if (isDebugIsOn)
				Console.WriteLine ("SendHeartbeatEvent() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendAuthorizationRequest ()
		{
			var _msg = outgoingMsgFactory.CreateAuthorizationRequest (clientPublicId, clientSecret);
			if (isDebugIsOn)
				Console.WriteLine ("SendAuthorizationRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendSubscribeForTradingEventsRequest (long accountId)
		{
			var _msg = outgoingMsgFactory.CreateSubscribeForTradingEventsRequest (accountId, authToken);
			if (isDebugIsOn)
				Console.WriteLine ("SendSubscribeForTradingEventsRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendSubscribeForTradingEventsRequest ()
		{
			SendSubscribeForTradingEventsRequest (testAccountId);
		}

		private void SendUnsubscribeForTradingEventsRequest ()
		{
			var _msg = outgoingMsgFactory.CreateUnsubscribeForTradingEventsRequest (testAccountId);
			if (isDebugIsOn)
				Console.WriteLine ("SendUnsubscribeForTradingEventsRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendGetAllSubscriptionsForTradingEventsRequest ()
		{
			var _msg = outgoingMsgFactory.CreateAllSubscriptionsForTradingEventsRequest ();
			if (isDebugIsOn)
				Console.WriteLine ("SendGetAllSubscriptionsForTradingEventsRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendGetAllSubscriptionsForSpotEventsRequest ()
		{
			var _msg = outgoingMsgFactory.CreateGetAllSpotSubscriptionsRequest ();
			if (isDebugIsOn)
				Console.WriteLine ("SendGetAllSubscriptionsForSpotEventsRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SetClientMessageId ()
		{
			if (isDebugIsOn)
				Console.WriteLine ("SetClientMessageId() Current message ID:\"{0}\"", (clientMsgId == null ? "null" : clientMsgId));
			if (clientMsgId != null) {
				clientMsgId = null;
			} else {
				clientMsgId = "customClientMessageID";
			}
			if (isDebugIsOn)
				Console.WriteLine ("SetClientMessageId() New message ID:\"{0}\"", (clientMsgId == null ? "null" : clientMsgId));
		}

		public void SendMarketOrderRequest (string symbol, ProtoTradeSide tradeSide, long volume)
		{
			var _msg = outgoingMsgFactory.CreateMarketOrderRequest (testAccountId, authToken, symbol, tradeSide, volume, clientMsgId);
			if (isDebugIsOn)
				Console.WriteLine ("SendMarketOrderRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendLimitOrderRequest ()
		{
			var _msg = outgoingMsgFactory.CreateLimitOrderRequest (testAccountId, authToken, "EURUSD", ProtoTradeSide.BUY, 1000000, 1.8, clientMsgId);
			if (isDebugIsOn)
				Console.WriteLine ("SendLimitOrderRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendStopOrderRequest ()
		{
			var _msg = outgoingMsgFactory.CreateStopOrderRequest (testAccountId, authToken, "EURUSD", ProtoTradeSide.BUY, 1000000, 0.2, clientMsgId);
			if (isDebugIsOn)
				Console.WriteLine ("SendStopOrderRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendClosePositionRequest ()
		{
			var _msg = outgoingMsgFactory.CreateClosePositionRequest (testAccountId, authToken, testPositionId, testVolume, clientMsgId);
			if (isDebugIsOn)
				Console.WriteLine ("SendClosePositionRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void SendSubscribeForSpotsRequest ()
		{
			var _msg = outgoingMsgFactory.CreateSubscribeForSpotsRequest (testAccountId, authToken, "EURUSD", clientMsgId);
			if (isDebugIsOn)
				Console.WriteLine ("SendSubscribeForSpotsRequest() Message to be send:\n{0}", OpenApiMessagesPresentation.ToString (_msg));
			writeQueue.Enqueue (Utils.Serialize (_msg));
		}

		private void NotImplementedCommand ()
		{
			Console.WriteLine ("Action is NOT IMPLEMENTED!");
		}

		#endregion Outgoing ProtoBuffer objects to Raw data...
	}
}

